using Data.Repos.Abs;
using Domain;
using Domain.Models;
using Domain.ViewModels.Clients;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Data.Repos
{
    public class ClientsRepository : IClientsRepository
    {
        private readonly ApplicationDbContext _context;
        public ClientsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Client>> GetAll()
        {
            return await _context.Clients
                .Include(i => i.DaneOsobowe)
                .ToListAsync();
        }

        public async Task<Client> Get(string id)
        {
            return await _context.Clients
                .Include(i => i.DaneOsobowe)
                .FirstOrDefaultAsync(f => f.ClientId == id);
        }


        public async Task<CreateClientViewModel> Create(CreateClientViewModel model)
        {
            if (model != null && model.Client != null && model.Client.DaneOsobowe != null)
            {
                try
                {
                    DaneOsobowe daneOsobowe = new DaneOsobowe()
                    {
                        DaneOsoboweId = Guid.NewGuid().ToString(),
                        Imie = model.Client.DaneOsobowe.Imie,
                        Nazwisko = model.Client.DaneOsobowe.Nazwisko,
                        Ulica = model.Client.DaneOsobowe.Ulica,
                        NumerUlicy = model.Client.DaneOsobowe.NumerUlicy,
                        Miejscowosc = model.Client.DaneOsobowe.Miejscowosc,
                        KodPocztowy = model.Client.DaneOsobowe.KodPocztowy,
                        Wojewodztwo = model.Client.DaneOsobowe.Wojewodztwo,
                        Kraj = model.Client.DaneOsobowe.Kraj,
                        Pesel = model.Client.DaneOsobowe.Pesel,
                        DataUrodzenia = model.Client.DaneOsobowe.DataUrodzenia,
                        Email = model.Client.DaneOsobowe.Email,
                        Telefon = model.Client.DaneOsobowe.Telefon,
                        Plec = model.Client.DaneOsobowe.Plec,
                        RodzajOsoby = model.Client.DaneOsobowe.RodzajOsoby,

                        Firma_Nazwa = model.Client.DaneOsobowe.Firma_Nazwa,
                        Firma_NIP = model.Client.DaneOsobowe.Firma_NIP,
                        Firma_Regon = model.Client.DaneOsobowe.Firma_Regon,
                        Firma_Ulica = model.Client.DaneOsobowe.Firma_Ulica,
                        Firma_NumerUlicy = model.Client.DaneOsobowe.Firma_NumerUlicy,
                        Firma_Miejscowosc = model.Client.DaneOsobowe.Firma_Miejscowosc,
                        Firma_KodPocztowy = model.Client.DaneOsobowe.Firma_KodPocztowy,
                        Firma_Wojewodztwo = model.Client.DaneOsobowe.Firma_Wojewodztwo,
                        Firma_Kraj = model.Client.DaneOsobowe.Firma_Kraj,

                        Newsletter = false,
                        DataDodania = DateTime.Now.ToString()
                    };
                    _context.DaneOsobowes.Add(daneOsobowe);

                    Client client = new Client()
                    {
                        ClientId = Guid.NewGuid().ToString(),
                        DaneOsoboweId = daneOsobowe.DaneOsoboweId
                    };
                    _context.Clients.Add(client);
                    await _context.SaveChangesAsync();



                    // dodanie zdjęcia
                    await CreateNewPhoto(model.Files, client.ClientId);


                    model.Success = true;
                }
                catch (Exception ex)
                {
                    model.Result = "Catch exception.";
                }
            }
            else
            {
                model.Result = "Model is null.";
            }
            return model;
        }

        public async Task<EditClientViewModel> Update(EditClientViewModel model)
        {
            if (model != null && model.Client != null && model.Client.DaneOsobowe != null)
            {
                try
                {
                    var client = await _context.Clients
                        .Include(i => i.DaneOsobowe)
                        .FirstOrDefaultAsync(f => f.ClientId == model.Client.DaneOsobowe.DaneOsoboweId);


                    if (client != null)
                    {

                        // aktualizacja danych osobowych klienta

                        var daneOsobowe = client.DaneOsobowe;
                        if (daneOsobowe != null)
                        {

                            daneOsobowe.Imie = model.Client.DaneOsobowe.Imie;
                            daneOsobowe.Nazwisko = model.Client.DaneOsobowe.Nazwisko;
                            daneOsobowe.Ulica = model.Client.DaneOsobowe.Ulica;
                            daneOsobowe.NumerUlicy = model.Client.DaneOsobowe.NumerUlicy;
                            daneOsobowe.Miejscowosc = model.Client.DaneOsobowe.Miejscowosc;
                            daneOsobowe.KodPocztowy = model.Client.DaneOsobowe.KodPocztowy;
                            daneOsobowe.Wojewodztwo = model.Client.DaneOsobowe.Wojewodztwo;
                            daneOsobowe.Kraj = model.Client.DaneOsobowe.Kraj;
                            daneOsobowe.Pesel = model.Client.DaneOsobowe.Pesel;
                            daneOsobowe.DataUrodzenia = model.Client.DaneOsobowe.DataUrodzenia;
                            daneOsobowe.Email = model.Client.DaneOsobowe.Email;
                            daneOsobowe.Telefon = model.Client.DaneOsobowe.Telefon;
                            daneOsobowe.Plec = model.Client.DaneOsobowe.Plec;
                            daneOsobowe.RodzajOsoby = model.Client.DaneOsobowe.RodzajOsoby;

                            daneOsobowe.Firma_Nazwa = model.Client.DaneOsobowe.Firma_Nazwa;
                            daneOsobowe.Firma_NIP = model.Client.DaneOsobowe.Firma_NIP;
                            daneOsobowe.Firma_Regon = model.Client.DaneOsobowe.Firma_Regon;
                            daneOsobowe.Firma_Ulica = model.Client.DaneOsobowe.Firma_Ulica;
                            daneOsobowe.Firma_NumerUlicy = model.Client.DaneOsobowe.Firma_NumerUlicy;
                            daneOsobowe.Firma_Miejscowosc = model.Client.DaneOsobowe.Firma_Miejscowosc;
                            daneOsobowe.Firma_KodPocztowy = model.Client.DaneOsobowe.Firma_KodPocztowy;
                            daneOsobowe.Firma_Wojewodztwo = model.Client.DaneOsobowe.Firma_Wojewodztwo;
                            daneOsobowe.Firma_Kraj = model.Client.DaneOsobowe.Firma_Kraj;

                            daneOsobowe.DataDodania = model.Client.DaneOsobowe.DataDodania;


                            _context.Entry(daneOsobowe).State = EntityState.Modified;
                            await _context.SaveChangesAsync();


                            model.Success = true;
                        }
                    }
                    else
                    {
                        model.Result = "Data is null.";
                    }

                }
                catch (Exception ex)
                {
                    model.Result = "Catch exception.";
                }
            }
            else
            {
                model.Result = "Model is null.";
            }
            return model;
        }


        public async Task<bool> Delete(string id)
        {
            bool deleteResult = false;
            try
            {
                var client = await _context.Clients.FirstOrDefaultAsync(f => f.ClientId == id);
                if (client != null)
                {

                    // delete dane osobowe

                    var daneOsobowe = await _context.DaneOsobowes.FirstOrDefaultAsync(f => f.DaneOsoboweId == client.DaneOsoboweId);
                    if (daneOsobowe != null)
                        _context.DaneOsobowes.Remove(daneOsobowe);

                    // delete orders
                    var orders = await _context.Orders.Where(w => w.ClientId == client.ClientId).ToListAsync();
                    foreach (var order in orders)
                        _context.Orders.Remove(order);


                    // delete client
                    _context.Clients.Remove(client);


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



    }
}
