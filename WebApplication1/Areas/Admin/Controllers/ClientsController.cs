using Application.Services.Abs;
using Data.Services;
using Domain.Models;
using Domain.Models.Enums;
using Domain.ViewModels.Clients;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = "Administrator")]
    public class ClientsController : Controller
    {
        private readonly IClientsService _clientsService;

        public ClientsController(IClientsService clientsService)
        {
            _clientsService = clientsService;
        }


        [HttpGet]
        public async Task<IActionResult> Index(ClientsViewModel model)
        {
            NI.Navigation = Navigation.ClientsIndex;
            var clients = await _clientsService.GetAll();

            return View(new ClientsViewModel()
            {
                Clients = clients,
                Paginator = Paginator<Client>.CreateAsync(clients, model.PageIndex, model.PageSize),
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
        public async Task<IActionResult> Index(string s, ClientsViewModel model)
        {
            var clients = await _clientsService.GetAll();

            // Wyszukiwanie
            if (!string.IsNullOrEmpty(model.q))
                clients = clients.Where(w =>
                    w.DaneOsobowe.Imie.Contains(model.q, StringComparison.OrdinalIgnoreCase) ||
                    w.DaneOsobowe.Nazwisko.Contains(model.q, StringComparison.OrdinalIgnoreCase) ||
                    w.DaneOsobowe.Firma_Nazwa.Contains(model.q, StringComparison.OrdinalIgnoreCase)
                ).ToList();


            // Sortowanie 
            switch (model.SortowanieOption)
            {
                case "Nazwisko A-Z":
                    clients = clients.OrderBy(o => o.DaneOsobowe.Nazwisko).ToList();
                    break;

                case "Nazwisko Z-A":
                    clients = clients.OrderByDescending(o => o.DaneOsobowe.Nazwisko).ToList();
                    break;

                case "Data dodania rosnąco":
                    clients = clients.OrderBy(o => o.DaneOsobowe.DataDodania).ToList();
                    break;

                case "Data dodania malejąco":
                    clients = clients.OrderByDescending(o => o.DaneOsobowe.DataDodania).ToList();
                    break;
            }

            model.Clients = clients;
            model.Paginator = Paginator<Client>.CreateAsync(clients, model.PageIndex, model.PageSize);
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            NI.Navigation = Navigation.ClientsCreate;
            return View(new CreateClientViewModel() { Result = "" });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateClientViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _clientsService.Create(model);
                if (result.Success)
                    return RedirectToAction("Index", "Clients");
            }

            return View(model);
        }



        [HttpGet]
        public async Task<IActionResult> Edit(string clientId)
        {
            NI.Navigation = Navigation.ClientsEdit;

            if (string.IsNullOrEmpty(clientId))
                return View("NotFound");

            var client = await _clientsService.Get(clientId);

            if (client == null || client.DaneOsobowe == null)
                return View("NotFound");

            return View(new EditClientViewModel()
            {
                Client = client,
                Result = ""
            });
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditClientViewModel model)
        {
            if (ModelState.IsValid)
            {
                if ((await _clientsService.Update(model)).Success)
                    return RedirectToAction("Index", "Clients");
            }

            return View(model);
        }



        [HttpGet]
        public async Task<IActionResult> Details(string clientId)
        {
            var client = await _clientsService.Get(clientId);

            if (client == null)
                return View("NotFound");

            return View(client);
        }



        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var client = await _clientsService.Get(id);

            if (client == null)
                return View("NotFound");

            return View(client);
        }


        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _clientsService.Delete(id);

            return RedirectToAction("Index", "Clients");
        }



    }
}
