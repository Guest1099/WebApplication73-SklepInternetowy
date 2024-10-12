using Data;
using Domain;
using Domain.Models;
using Domain.ViewModels.Account;
using Domain.ViewModels.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Application.Services
{
    public class UsersService //: IUsersService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        //private readonly UserSupportService _userSupportService;

        public UsersService(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }



        public async Task<List<ApplicationUser>> GetAll()
        {
            var users = await _context.Users
                .Include(i => i.DaneOsobowe)
                .ToListAsync();
            return users;
        }



        public async Task<ApplicationUser> GetUserById(string id)
        {
            var user = await _context.Users
                .Include(i => i.DaneOsobowe)
                    .ThenInclude (t=> t.PhotosDaneOsobowe)
                .FirstOrDefaultAsync(f => f.Id == id);
            if (user != null)
                return user;
            else
                return new ApplicationUser();
        }


        public async Task<ApplicationUser> GetUserByEmail(string email)
        {
            var user = await _context.Users
                .Include(i => i.DaneOsobowe)
                    .ThenInclude(t => t.PhotosDaneOsobowe)
                .FirstOrDefaultAsync(f => f.Email == email);
            if (user != null)
                return user;
            else
                return new ApplicationUser();
        }



        public async Task<CreateUserViewModel> Create(CreateUserViewModel model)
        {
            if (model != null)
            {
                try
                {
                    // utworzenie nowego użytkownika

                    // sprzewdzenie na podstawie maila czy użytkownik już istnieje
                    var findUser = await _context.Users.FirstOrDefaultAsync(f => f.Email == model.User.Email);
                    // jeżeli użytkownik nie istnieje to tworzone jest nowe konto
                    if (findUser == null)
                    {

                        // stworzenie danych osobowych użytkownika
                        DaneOsobowe daneOsobowe = new DaneOsobowe()
                        {
                            DaneOsoboweId = Guid.NewGuid().ToString(),

                            Imie = model.User.DaneOsobowe.Imie,
                            Nazwisko = model.User.DaneOsobowe.Nazwisko,
                            Ulica = model.User.DaneOsobowe.Ulica,
                            NumerUlicy = model.User.DaneOsobowe.NumerUlicy,
                            Miejscowosc = model.User.DaneOsobowe.Miejscowosc,
                            KodPocztowy = model.User.DaneOsobowe.KodPocztowy,
                            Wojewodztwo = model.User.DaneOsobowe.Wojewodztwo,
                            Kraj = model.User.DaneOsobowe.Kraj,
                            Pesel = model.User.DaneOsobowe.Pesel,
                            DataUrodzenia = model.User.DaneOsobowe.DataUrodzenia,
                            Email = model.User.DaneOsobowe.Email,
                            Telefon = model.User.DaneOsobowe.Telefon,
                            Plec = model.User.DaneOsobowe.Plec,
                            RodzajOsoby = model.User.DaneOsobowe.RodzajOsoby,

                            Firma_Nazwa = model.User.DaneOsobowe.Firma_Nazwa,
                            Firma_NIP = model.User.DaneOsobowe.Firma_NIP,
                            Firma_Regon = model.User.DaneOsobowe.Firma_Regon,
                            Firma_Ulica = model.User.DaneOsobowe.Firma_Ulica,
                            Firma_NumerUlicy = model.User.DaneOsobowe.Firma_NumerUlicy,
                            Firma_Miejscowosc = model.User.DaneOsobowe.Firma_Miejscowosc,
                            Firma_KodPocztowy = model.User.DaneOsobowe.Firma_KodPocztowy,
                            Firma_Wojewodztwo = model.User.DaneOsobowe.Firma_Wojewodztwo,
                            Firma_Kraj = model.User.DaneOsobowe.Firma_Kraj,

                            Newsletter = false,
                            DataDodania = DateTime.Now.ToString()
                        };
                        _context.DaneOsobowes.Add(daneOsobowe);
                        await _context.SaveChangesAsync();


                        // stworzenie użytkownika
                        var user = new ApplicationUser
                        {
                            Id = Guid.NewGuid().ToString(),
                            Email = model.User.Email,
                            UserName = model.User.Email,
                            ConcurrencyStamp = Guid.NewGuid().ToString(),
                            SecurityStamp = Guid.NewGuid().ToString(),
                            NormalizedEmail = model.User.Email.ToUpper(),
                            NormalizedUserName = model.User.Email.ToUpper(),
                            DaneOsoboweId = daneOsobowe.DaneOsoboweId,
                            DataOstatniegoZalogowania = DateTime.Now.ToString(),
                            EmailConfirmed = false,
                        };
                        var result = await _userManager.CreateAsync(user, model.Password);


                        if (result.Succeeded)
                        {
                            //string token = _userSupportService.GenerateJwtToken(user, model.RoleName);


                            // jeżeli żadna rola nie jest wybrana podczas tworzenia nowego użytkownika, wtedy dodawana jest standardowa rola
                            if (model.SelectedRoles.Count == 0)
                            {
                                await _userManager.AddToRoleAsync(user, "User");
                                await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "User"));
                            }

                            // dodanie nowozarejestrowanego użytkownika do ról 
                            foreach (var selectedRole in model.SelectedRoles)
                            {
                                await _userManager.AddToRoleAsync(user, selectedRole);
                                await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, selectedRole));
                            }



                            // dodanie zdjęcia
                            await CreateNewPhoto(model.Files, daneOsobowe.DaneOsoboweId);



                            // zalogowanie
                            //await _signInManager.SignInAsync(user, false);


                            model.Success = true;
                            model.Result = "Zarejestrowano nowego użytkownika. Sprawdź pocztę aby dokończyć rejestrację";
                        }
                    }
                    else
                    {
                        model.Result = "Użytkownik o podanym adresie email już istnieje";
                    }
                }
                catch (Exception ex)
                {
                    model.Result = "Catch exception. " + ex.Message;
                }
            }
            else
            {
                model = new CreateUserViewModel() { Result = "Model is null" };
            }
            return model;
        }




        public async Task<EditUserViewModel> Update(EditUserViewModel model)
        {
            if (model != null && model.User != null && model.User.DaneOsobowe != null)
            {
                try
                {
                    var user = await _context.Users
                        .Include(i => i.DaneOsobowe)
                        .FirstOrDefaultAsync(f => f.Id == model.User.Id);


                    if (user != null)
                    {

                        // aktualizacja danych osobowych klienta

                        var daneOsobowe = user.DaneOsobowe;
                        if (daneOsobowe != null)
                        {

                            daneOsobowe.Imie = model.User.DaneOsobowe.Imie;
                            daneOsobowe.Nazwisko = model.User.DaneOsobowe.Nazwisko;
                            daneOsobowe.Ulica = model.User.DaneOsobowe.Ulica;
                            daneOsobowe.NumerUlicy = model.User.DaneOsobowe.NumerUlicy;
                            daneOsobowe.Miejscowosc = model.User.DaneOsobowe.Miejscowosc;
                            daneOsobowe.KodPocztowy = model.User.DaneOsobowe.KodPocztowy;
                            daneOsobowe.Wojewodztwo = model.User.DaneOsobowe.Wojewodztwo;
                            daneOsobowe.Kraj = model.User.DaneOsobowe.Kraj;
                            daneOsobowe.Pesel = model.User.DaneOsobowe.Pesel;
                            daneOsobowe.DataUrodzenia = model.User.DaneOsobowe.DataUrodzenia;
                            daneOsobowe.Email = model.User.DaneOsobowe.Email;
                            daneOsobowe.Telefon = model.User.DaneOsobowe.Telefon;
                            daneOsobowe.Plec = model.User.DaneOsobowe.Plec;
                            daneOsobowe.RodzajOsoby = model.User.DaneOsobowe.RodzajOsoby;

                            daneOsobowe.Firma_Nazwa = model.User.DaneOsobowe.Firma_Nazwa;
                            daneOsobowe.Firma_NIP = model.User.DaneOsobowe.Firma_NIP;
                            daneOsobowe.Firma_Regon = model.User.DaneOsobowe.Firma_Regon;
                            daneOsobowe.Firma_Ulica = model.User.DaneOsobowe.Firma_Ulica;
                            daneOsobowe.Firma_NumerUlicy = model.User.DaneOsobowe.Firma_NumerUlicy;
                            daneOsobowe.Firma_Miejscowosc = model.User.DaneOsobowe.Firma_Miejscowosc;
                            daneOsobowe.Firma_KodPocztowy = model.User.DaneOsobowe.Firma_KodPocztowy;
                            daneOsobowe.Firma_Wojewodztwo = model.User.DaneOsobowe.Firma_Wojewodztwo;
                            daneOsobowe.Firma_Kraj = model.User.DaneOsobowe.Firma_Kraj;

                            daneOsobowe.DataDodania = model.User.DaneOsobowe.DataDodania;


                            _context.Entry(daneOsobowe).State = EntityState.Modified;
                            await _context.SaveChangesAsync();


                            model.Success = true;
                        }


                        // await _userManager.UpdateAsync(user);


                        // Usunięcie ze wszystkich rół
                        foreach (var role in await _context.Roles.ToListAsync())
                            await _userManager.RemoveFromRoleAsync(user, role.Name);



                        // Przypisanie nowych ról do użytkownika,
                        // jeżeli lista nie ma żadnej roli to przypisywana jest standarodowa rola "User", w przeciwnym razie pobierane są wybrane role
                        if (!model.SelectedRoles.Any ())
                        {
                            await _userManager.AddToRoleAsync(user, "User");
                            await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "User"));
                        } 
                        else
                        {
                            foreach (var selectedRole in model.SelectedRoles)
                            {
                                await _userManager.AddToRoleAsync(user, selectedRole);
                                await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, selectedRole));
                            }
                        }



                        // dodanie zdjęcia
                        await CreateNewPhoto(model.Files, daneOsobowe.DaneOsoboweId);



                        model.Result = "Dane zostały zaktualizowane poprawnie";
                        model.Success = true;

                    }
                    else
                    {
                        model.Result = "Data is null";
                    }

                }
                catch (Exception ex)
                {
                    model.Result = "Catch exception";
                }
            }
            else
            {
                model = new EditUserViewModel() { Result = "Model is null" };
            }
            return model;
        }





        public async Task<bool> Delete(string id)
        {
            bool deleteResult = false;
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(f => f.Id == id);
                if (user != null)
                {

                    var daneOsobowe = await _context.DaneOsobowes.FirstOrDefaultAsync(f => f.DaneOsoboweId == user.DaneOsoboweId);
                    if (daneOsobowe != null)
                    {
                        // delete photos dane osobowe
                        var photosDaneOsobowe = await _context.PhotosDaneOsobowe.Where(w => w.DaneOsoboweId == daneOsobowe.DaneOsoboweId).ToListAsync ();
                        foreach (var photoDaneOsobowe in photosDaneOsobowe)
                            _context.PhotosDaneOsobowe.Remove(photoDaneOsobowe);


                        // delete dane osobowe
                        _context.DaneOsobowes.Remove(daneOsobowe);
                    }


                    // delete orders
                    var orders = await _context.Orders.Where(w => w.UserId == user.Id).ToListAsync();
                    foreach (var order in orders)
                        _context.Orders.Remove(order);


                    // delete favourites
                    var favourites = await _context.Favourites.Where(w => w.UserId == user.Id).ToListAsync();
                    foreach (var favourite in favourites)
                        _context.Favourites.Remove(favourite);


                    // delete likes
                    var likes = await _context.Likes.Where(w => w.UserId == user.Id).ToListAsync();
                    foreach (var like in likes)
                        _context.Likes.Remove(like);


                    // delete likes
                    var loggingErrors = await _context.LoggingErrors.Where(w => w.UserId == user.Id).ToListAsync();
                    foreach (var loggingError in loggingErrors)
                        _context.LoggingErrors.Remove(loggingError);



                    // delete user
                    _context.Users.Remove(user);


                    // zapisanie zmodyfikowanych danych w bazie
                    await _context.SaveChangesAsync();

                    deleteResult = true;
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
            }

            return deleteResult;
        }




        /// <summary>
        /// Pobiera wszystkich użytkowników będących w danej roli
        /// </summary>
        public async Task<List<ApplicationUser>> GetUsersInRole(string roleName)
        {
            return (await _userManager.GetUsersInRoleAsync(roleName)).ToList();
        }


         

        /// <summary>
        /// Pobiera wszystkie role danego użytkownika
        /// </summary>
        public async Task<List<string>> GetUserRoles(string userId)
        {
            List<string> userRoles = new List<string>();
            var user = await _userManager.FindByIdAsync(userId);

            if (user != null)
            {
                userRoles = (await _userManager.GetRolesAsync(user)).ToList();
            }
            return userRoles;
        }






        public async Task<ChangeEmailViewModel> ChangeEmail(ChangeEmailViewModel model)
        {
            model = new ChangeEmailViewModel() { Success = false, Result = "XXX" };

            try
            {
                var user = await _userManager.FindByNameAsync(model.UserId);
                if (user != null)
                {
                    string token = await _userManager.GenerateChangeEmailTokenAsync(user, model.NewEmail);
                    var result = await _userManager.ChangeEmailAsync(user, model.NewEmail, token);
                    if (result.Succeeded)
                    {

                        // zaktualizowanie nazwy użytkownika 
                        user.Email = model.NewEmail;
                        user.UserName = model.NewEmail;
                        await _userManager.UpdateAsync(user);

                        // zaktualizowanie danych w danych osobowych użytkownika


                        //await _userManager.UpdateAsync(user);
                        //await _signInManager.SignOutAsync();

                        model.Result = "Email zmieniony poprawnie";
                        model.Success = true;
                    }
                    else
                    {
                        model.Result = "Email nie został zaktualizowany";
                    }
                }
                else
                {
                    model.Result = "User was null";
                } 
            }
            catch (Exception ex)
            {
                model.Result = "Catch exception. " + ex.Message;
            }
            return model;
        }





        /// <summary>
        /// Zmienia hasło użytkownika
        /// </summary>
        public async Task<ChangePasswordViewModel> ChangePassword(ChangePasswordViewModel model)
        {
            model = new ChangePasswordViewModel() { Success = false };

            try
            {
                var user = await _userManager.FindByNameAsync(model.UserId);
                if (user != null)
                {
                    var changePasswordResult = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
                    if (changePasswordResult.Succeeded)
                    {
                        model.Result = "Hasło zmienione poprawnie.";
                        model.Success = true;

                        // wylogowanie użytkownika
                        // await _signInManager.SignOutAsync();
                    }
                    else
                    {
                        model.Result = "Błędne hasło";
                    }
                }
                else
                {
                    model.Result = "Wskazany użytkownik nie istnieje";
                }

            }
            catch (Exception ex)
            {
                model.Result = "Catch exception. " + ex.Message;
            }
            return model;
        }



        /*
                /// <summary>
                /// Zmienia hasło użytkownika systemu
                /// </summary>
                public async Task<ChangePasswordViewModel> ChangePassword(ChangePasswordViewModel model)
                { 
                    if (model != null)
                    {
                        try
                        {
                            var user = await _userManager.FindByNameAsync(model.UserId);
                            if (user != null)
                            {
                                var changePasswordResult = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
                                if (changePasswordResult.Succeeded)
                                {
                                    model.Result = "Hasło zmienione poprawnie.";
                                    model.Success = true;

                                    // wylogowanie użytkownika
                                    // await _signInManager.SignOutAsync();
                                }
                                else
                                {
                                    model.Result = "Błędne hasło";
                                }
                            }
                            else
                            {
                                model.Result = "Wskazany użytkownik nie istnieje";
                            }
                        }
                        catch (Exception ex)
                        {
                            model = new ChangePasswordViewModel() { Success = false, Result = "Catch exception. " + ex.Message };
                        }
                    }
                    else
                    {
                        model = new ChangePasswordViewModel() { Success = false, Result = "Model was null" };
                    }
                    return model;
                }
        */






        private async Task CreateNewPhoto(List<IFormFile> files, string daneOsoboweId)
        {
            try
            {
                if (files != null && files.Count > 0 && !string.IsNullOrEmpty(daneOsoboweId))
                {
                    foreach (var file in files)
                    {
                        if (file.Length > 0)
                        {
                            byte[] photoData;
                            using (var stream = new MemoryStream())
                            {
                                file.CopyTo(stream);
                                photoData = stream.ToArray();

                                PhotoDaneOsobowe photoDaneOsobowe = new PhotoDaneOsobowe()
                                {
                                    PhotoDaneOsoboweId = Guid.NewGuid().ToString(),
                                    PhotoData = photoData,
                                    DaneOsoboweId = daneOsoboweId
                                };
                                _context.PhotosDaneOsobowe.Add(photoDaneOsobowe);
                                await _context.SaveChangesAsync();
                            }
                        }
                    }
                }
            }
            catch { }
        }



        /// <summary>
        /// Usuwa zdjęcie użytkownika z DaneOsobowe
        /// </summary>
        public async Task <bool> DeletePhotoDaneOsobowe (string photoDaneOsoboweId)
        {
            bool result = false;
            try
            {
                if (!string.IsNullOrEmpty (photoDaneOsoboweId))
                {
                    var photoDaneOsobowe = await _context.PhotosDaneOsobowe.FirstOrDefaultAsync(f => f.PhotoDaneOsoboweId == photoDaneOsoboweId);
                    if (photoDaneOsobowe != null)
                    {
                        _context.PhotosDaneOsobowe.Remove(photoDaneOsobowe);
                        await _context.SaveChangesAsync();
                        result = true;
                    }
                }
            }
            catch { }
            return result;
        }



    }
}
