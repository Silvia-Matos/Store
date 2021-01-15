﻿namespace Store.Web.Data
{
    using Store.Web.Data.Entities;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class SeedDb
    {
        private readonly DataContext context;

        private readonly Random random;

        public SeedDb(DataContext context)
        {
            this.context = context;

            this.random = new Random();
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            if (!this.context.Products.Any())
            {
                this.AddProducts("Equipamento oficial SLB");
                this.AddProducts("Chuteiras oficiais");
                this.AddProducts("Águia pequena");
                await this.context.SaveChangesAsync();
            }
        }

        private void AddProducts(string name)
        {
            this.context.Products.Add(new Product
            {
                Name = name,
                Price = this.random.Next(200),
                IsAvailable = true,
                Stock = this.random.Next(100),

            });
        }
    }
}
