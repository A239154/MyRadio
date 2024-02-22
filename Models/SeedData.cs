using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyRadio.Data;
using System;
using System.Linq;

namespace MyRadio.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MyRadioContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MyRadioContext>>()))
        {
            // Look for any movies.
            if (context.Radio.Any())
            {
                return;   // DB has been seeded
            }
            context.Radio.AddRange(
                new Radio
                {
                    Title = "Harm Radio",
                    TypeOfRadio = "frequency",
                    Price = 7.99M
                },
                new Radio
                {
                    Title = "Satelite radio ",
                    TypeOfRadio = "better Visulization",
                    Price = 8.99M
                },
                new Radio
                {
                    Title = "ShortWave Radio",
                    TypeOfRadio= "Connectivity",
                    Price = 9.99M
                },
                new Radio
                {
                    Title = "Rio Bravo",
                    TypeOfRadio = "Western",
                    Price = 3.99M
                }
            );
            context.SaveChanges();
        }
    }
}
