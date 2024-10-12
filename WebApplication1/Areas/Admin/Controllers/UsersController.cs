using Application.Services;
using Data.Services;
using Domain.Models;
using Domain.Models.Enums;
using Domain.ViewModels.Account;
using Domain.ViewModels.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace WebApplication1.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = "Administrator")]
    public class UsersController : Controller
    {
        //private readonly IUserAccountService _accountService;
        private readonly UsersService _usersService;

        public UsersController(UsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(UsersViewModel model)
        {
            NI.Navigation = Navigation.UsersIndex;
            var users = await _usersService.GetAll();

            return View(new UsersViewModel()
            {
                Users = users,
                Paginator = Paginator<ApplicationUser>.CreateAsync(users, model.PageIndex, model.PageSize),
                PageIndex = model.PageIndex,
                PageSize = model.PageSize,
                Start = model.Start,
                End = model.End,
                q = model.q,
                SortowanieOption = model.SortowanieOption
            });
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(string s, UsersViewModel model)
        {
            NI.Navigation = Navigation.UsersIndex;
            var users = await _usersService.GetAll();

            try
            {
                // Wyszukiwanie
                if (!string.IsNullOrEmpty(model.q))
                    users = users.Where(w =>
                        w.DaneOsobowe.Imie.Contains(model.q, StringComparison.OrdinalIgnoreCase) ||
                        w.DaneOsobowe.Nazwisko.Contains(model.q, StringComparison.OrdinalIgnoreCase) ||
                        w.Email.Contains(model.q, StringComparison.OrdinalIgnoreCase)
                    ).ToList();


                // Sortowanie 
                switch (model.SortowanieOption)
                {
                    case "Użytkownicy":
                        users = await _usersService.GetUsersInRole("User");
                        break;

                    case "Administratorzy":
                        users = await _usersService.GetUsersInRole("Administrator");
                        break;

                    case "Zarząd":
                        users = await _usersService.GetUsersInRole("Zarząd");
                        break;

                    case "Marketing":
                        users = await _usersService.GetUsersInRole("Marketing");
                        break;

                    case "Wszyscy":
                        break;
                }
            }
            catch { }

            model.Users = users;
            model.Paginator = Paginator<ApplicationUser>.CreateAsync(users, model.PageIndex, model.PageSize);
            return View(model);
        }




        [HttpGet]
        public IActionResult Create()
        {
            NI.Navigation = Navigation.UsersCreate;
            return View(new CreateUserViewModel() { SelectedRoles = new List<string>() { }, Result = "" });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateUserViewModel model)
        {
            NI.Navigation = Navigation.UsersCreate;
            if (ModelState.IsValid)
            {
                //model.Password = "SDG%$@5423sdgagSDert";
                if ((await _usersService.Create(model)).Success)
                    return RedirectToAction("Index", "Users");
            }

            return View(model);
        }




        [HttpGet]
        public async Task<IActionResult> Edit(string userId)
        {
            NI.Navigation = Navigation.UsersEdit;

            if (string.IsNullOrEmpty(userId))
                return View("NotFound");

            var user = await _usersService.GetUserById(userId);
            var daneOsobowe = user.DaneOsobowe;
            var photosDaneOsobowe = daneOsobowe?.PhotosDaneOsobowe;

            var userRoles = await _usersService.GetUserRoles(userId);

            if (user == null || daneOsobowe == null)
                return View("NotFound");


            return View(new EditUserViewModel()
            {
                User = user,
                SelectedRoles = userRoles,
                PhotosDaneOsobowe = photosDaneOsobowe,
                Result = ""
            });
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditUserViewModel model)
        {
            NI.Navigation = Navigation.UsersEdit;

            if (model == null || model.User == null || string.IsNullOrEmpty(model.User.Id))
                return View("NotFound");

            if (ModelState.IsValid)
            {
                if ((await _usersService.Update(model)).Success)
                    return RedirectToAction("Index", "Users");
            }

            model.PhotosDaneOsobowe = model.User.DaneOsobowe?.PhotosDaneOsobowe;

            return View(model);
        }






        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
                return View("NotFound");

            var user = await _usersService.GetUserById(id);

            if (user == null)
                return View("NotFound");

            return View(user);
        }




        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (string.IsNullOrEmpty(id))
                return View("NotFound");

            await _usersService.Delete(id);

            return RedirectToAction("Index", "Users");
        }







        [HttpGet]
        public async Task <IActionResult> ChangeEmail (string userId)
        {
            if (string.IsNullOrEmpty(userId))
                return View("NotFound");

            ChangeEmailViewModel changeEmailViewModel = new ChangeEmailViewModel();
            var user = await _usersService.GetUserById(userId);
            if (user != null)
            {
                changeEmailViewModel.UserId = user.Id;
                changeEmailViewModel.ObecnyEmail = user.Email;
            }

            return View(changeEmailViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeEmail(ChangeEmailViewModel model)
        {
            /*if (string.IsNullOrEmpty(model.UserId))
                return View("NotFound");
*/
            var result = await _usersService.ChangeEmail(model);
            if (result.Success)
                return RedirectToAction("Edit", "Users", new { userId = model.UserId });

            //return RedirectToAction("Edit", "Users", new { userId = model.UserId });
            return View(model);
        }






        [HttpGet]
        public IActionResult ChangePassword (string userId)
        {
            if (string.IsNullOrEmpty(userId))
                return View("NotFound"); 

            return View(new ChangePasswordViewModel() { Result = "" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword (ChangePasswordViewModel model)
        {
            if (string.IsNullOrEmpty(model.UserId))
                return View("NotFound");

            var result = await _usersService.ChangePassword (model);
            if (result.Success)
                return RedirectToAction("Edit", "Users", new { userId = model.UserId });

            return View(model);
        }



        [HttpGet]
        public async Task<IActionResult> DeletePhotoDaneOsobowe(string userId, string photoDaneOsoboweId)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(photoDaneOsoboweId))
                return View("NotFound");

            await _usersService.DeletePhotoDaneOsobowe(photoDaneOsoboweId);
            return RedirectToAction("Edit", "Users", new { userId = userId });
        }



    }
}
