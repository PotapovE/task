using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyMvcUI.Data;
using System;
using System.Linq;

namespace MyMvcUI.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MyMvcUIContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MyMvcUIContext>>()))
            {
                // Look for any movies.
                if (context.TestModel.Any())
                {
                    return;   // DB has been seeded
                }

                context.TestModel.AddRange(
                    new TestModel
                    {
                        Title = "When Harry Met Sally",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Desc = "Romantic Comedy",
                        Price = 7.99M
                    },

                    new TestModel
                    {
                        Title = "Ghostbusters ",
                        ReleaseDate = DateTime.Parse("1984-3-13"),
                        Desc = "Comedy",
                        Price = 8.99M
                    },

                    new TestModel
                    {
                        Title = "Ghostbusters 2",
                        ReleaseDate = DateTime.Parse("1986-2-23"),
                        Desc = "Comedy",
                        Price = 9.99M
                    },

                    new TestModel
                    {
                        Title = "Rio Bravo",
                        ReleaseDate = DateTime.Parse("1959-4-15"),
                        Desc = "Western",
                        Price = 3.99M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}