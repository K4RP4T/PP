using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MvcMovieContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MvcMovieContext>>()))
        {
            // Look for any movies.
            if (context.User.Any())
            {
                return;   // DB has been seeded
            }
            context.User.AddRange(
                new User
                {
                    Name = "Natalia",
                    Surname = "Srebnicka",
                    DateOfBirth = DateTime.Parse("2002-09-23"),
                    Login = "ns@gmail.com",
                    IsDeleted = false
                },
                new User
                {
                    Name = "Kacper",
                    Surname = "Topolski",
                    DateOfBirth = DateTime.Parse("2002-06-24"),
                    Login = "kt@gmail.com",
                    IsDeleted = false
                },
                new User
                {
                    Name = "Jan",
                    Surname = "Kowalski",
                    DateOfBirth = DateTime.Parse("2020-12-12"),
                    Login = "jk@gmail.com",
                    IsDeleted = true
                },
                new User
                {
                    Name = "Mariusz",
                    Surname = "Nowak",
                    DateOfBirth = DateTime.Parse("2010-01-20"),
                    Login = "mn@gmail.com",
                    IsDeleted = false
                },
                new User
                {
                    Name = "Elon",
                    Surname = "Musk",
                    DateOfBirth = DateTime.Parse("1971-06-28"),
                    Login = "em@gmail.com",
                    IsDeleted = true
                }
            );
            context.SaveChanges();
        }
    }
}