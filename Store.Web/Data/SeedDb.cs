namespace Store.Web.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Entities;
    using Helpers;

    public class SeedDb
    {
        private readonly DataContext context;
        private readonly IUserHelper userHelper;
        private readonly Random random;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            this.context = context;
            this.userHelper = userHelper;
            this.random = new Random();
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            var user = await this.userHelper.GetUserByEmailAsync("silviamatos@testemail.pt");
            if(user == null)
            {
                user = new User
                {
                    FirstName = "Silvia",
                    LastName = "Matos",
                    Email = "silviamatos@testemail.pt",
                    UserName = "silviamatos@testemail.pt",
                    PhoneNumber = "211836962"
                };

                var result = await this.userHelper.AddUserAsync(user, "123456");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }
            }


            if (!this.context.Products.Any())
            {
                this.AddProducts("Equipamento oficial SLB", user);
                this.AddProducts("Chuteiras oficiais", user);
                this.AddProducts("Águia pequena", user);
                await this.context.SaveChangesAsync();
            }
        }

        private void AddProducts(string name, User user)
        {
            this.context.Products.Add(new Product
            {
                Name = name,
                Price = this.random.Next(200),
                IsAvailable = true,
                Stock = this.random.Next(100),
                User = user

            });
        }
    }
}
