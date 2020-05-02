using LinkaBack.DAL.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkaBack.DAL
{
    public class SeederDB
    {

        public static void SeedProducts(EFDbContext context)
        {
            List<Product> products = new List<Product>();

            products.Add(new Product
            {
                Title = "Salo",
                Text = "Just salo",
                Image = "https://www.astromeridian.ru/assets/images/sonnik/kaban2.jpg"
            });
            products.Add(new Product
            {
                Title = "Ogirok",
                Text = "Just Ogirok",
                Image = "https://agrostory.com/upload/medialibrary/e45/e45527318c526f857bc5f9ddfb1de972.jpg"
            });
            products.Add(new Product
            {
                Title = "Kartoplia",
                Text = "Just Kartoplia",
                Image = "https://radiotrek.rv.ua/media/gallery/intxt/a/r/article359094.jpg"
            });

            context.Products.AddRange(products);
            context.SaveChanges();
        }

        public static void SeedData(IServiceProvider services)
        {
            using (var scope = services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<EFDbContext>();
       
                SeederDB.SeedProducts(context);
            }
        }
    }
}
