using Shopping2023.Data.Entities;
using Shopping2023.Data.Enums;
using Shopping2023.Helpers;
using System.Runtime.Loader;

namespace Shopping2023.Data
{
    public class SeedDB
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public SeedDB( DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public  async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckCategoriesAsync();
            await CheckCountriesAsync();
            await CheckRolesAsync();
            await CheckUserAsync("1010", "Heber", "Ochoa Prieto", "heber76@yopmail.com", "614 140 21 25", "Paseos de Balleza 14188", UserType.Admin);

        }

        private async Task<User> CheckUserAsync(string document, string firstName, string lastName, string email, string phone, string address, UserType userType)
        {
            User user = await _userHelper.GetUserAsync(email);

            if (user == null) 
            {
                user = new User
                {
                    UserName = email,
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    Address= address,
                    PhoneNumber = phone,
                    Document = document,
                    City=_context.Cities.FirstOrDefault(),
                    UserType = userType

                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user,userType.ToString());
            }
            return user;
        }

        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());
        }

        private async Task CheckCountriesAsync()
        {
            if (!_context.Countries.Any())
            {
                _context.Countries.Add(new Country
                {
                    Name = "Colombia",
                    States = new List<State>()
                    {
                        new State()
                        {
                            Name = "Antioquia",
                            Cities = new List<City>() {
                                new City() { Name = "Medellín" },
                                new City() { Name = "Itagüí" },
                                new City() { Name = "Envigado" },
                                new City() { Name = "Bello" },
                                new City() { Name = "Rionegro" },
                            }
                        },
                        new State()
                        {
                            Name = "Bogotá",
                            Cities = new List<City>() {
                                new City() { Name = "Usaquen" },
                                new City() { Name = "Champinero" },
                                new City() { Name = "Santa fe" },
                                new City() { Name = "Useme" },
                                new City() { Name = "Bosa" },
                            }
                        },
                    }
                });
                _context.Countries.Add(new Country
                {
                    Name = "Estados Unidos",
                    States = new List<State>()
                    {
                        new State()
                        {
                            Name = "Florida",
                            Cities = new List<City>() {
                                new City() { Name = "Orlando" },
                                new City() { Name = "Miami" },
                                new City() { Name = "Tampa" },
                                new City() { Name = "Fort Lauderdale" },
                                new City() { Name = "Key West" },
                            }
                        },
                        new State()
                        {
                            Name = "Texas",
                            Cities = new List<City>() {
                                new City() { Name = "Houston" },
                                new City() { Name = "San Antonio" },
                                new City() { Name = "Dallas" },
                                new City() { Name = "Austin" },
                                new City() { Name = "El Paso" },
                            }
                        },
                    }
                });
            }

            await _context.SaveChangesAsync();
        }


        private async Task CheckCategoriesAsync()
        {
            if (!_context.Categories.Any())
            {


                _context.Categories.Add(new Entities.Category { Name = "Tecnología" });
                _context.Categories.Add(new Entities.Category { Name = "Ropa" });
                _context.Categories.Add(new Entities.Category { Name = "Calzado" });
                _context.Categories.Add(new Entities.Category { Name = "Belleza" });
                _context.Categories.Add(new Entities.Category { Name = "Deportes" });
                _context.Categories.Add(new Entities.Category { Name = "Apple" });
                _context.Categories.Add(new Entities.Category { Name = "Mascotas" });

                await _context.SaveChangesAsync();  

            }
            
        }
    }
}
