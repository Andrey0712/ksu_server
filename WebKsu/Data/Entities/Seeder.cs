﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WebKsu.Constants;
using WebKsu.Data.Entities.Identity;

namespace WebKsu.Data.Entities
{
    public static class Seeder
    {
        public static void SeederData(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var logger = services.GetRequiredService<ILogger<Program>>();
                try
                {
                    logger.LogInformation("Seeding Databases");//в консоль сообщает что сидится DB
                    var context = scope.ServiceProvider.GetRequiredService<AppEFContext>();//создаем контекст и дальще накатіваем миграцию
                    context.Database.Migrate();

                    SeedRole(services);//сидим роли
                    SeedBaner(services);
                   /* SeedCateory(services);
                    SeedInventoryStatus(services);
                    SeedProduct(services);
                    SeedOrderStatuses(services);*/

                }
                catch (Exception)
                {

                    throw;
                }

            }
        }


        private static void SeedRole(IServiceProvider service)
        {
            var roleManeger = service.GetRequiredService<RoleManager<AppRole>>();
            var userManeger = service.GetRequiredService<UserManager<AppUser>>();

            if (!roleManeger.Roles.Any())
            {
                var rez = roleManeger.CreateAsync(new AppRole
                {
                    Name = Roles.Admin
                }).Result;
                rez = roleManeger.CreateAsync(new AppRole
                {
                    Name = Roles.User
                }).Result;
                rez = roleManeger.CreateAsync(new AppRole
                {
                    Name = Roles.Owner
                }).Result;
            }

            if (!userManeger.Users.Any())
            {
                var user = new AppUser
                {
                    Email = "admin@gmail.com",
                    UserName = "admin@gmail.com",
                    Owner = "Luda",
                    Phone = "+38098839384",
                    Address= "м.Рівне вул.Корнаухова 15, кв 2"

                };
                var result = userManeger.CreateAsync(user, "qwerty1").Result;
                if (result.Succeeded)
                {
                    result = userManeger.AddToRoleAsync(user, Roles.Admin).Result;
                }
            }

        }

        /*private static void SeedOrderStatuses(IServiceProvider service)
        {
            var context = service.GetRequiredService<AppEFContext>();
            if (!context.OrderStatuses.Any())
            {
                context.OrderStatuses
                        .Add(new OrderStatusEntity
                        {
                            Name = "Нове замовленя"
                        });

                context.OrderStatuses
                    .Add(new OrderStatusEntity
                    {
                        Name = "Відправлено"
                    });

                context.OrderStatuses
                    .Add(new OrderStatusEntity
                    {
                        Name = "Відхилено"
                    });

                context.SaveChanges();
            }

        }*/

        /*private static void SeedCateory(IServiceProvider service)
        {
            var context = service.GetRequiredService<AppEFContext>();
            if (!context.Categories.Any())
            {
                context.Categories.AddRange(new List<CategoryEntity>
                {
                    new CategoryEntity
                    {
                        Name="Корм"
                    },
                    new CategoryEntity
                    {
                        Name="Вітаміни"
                    },
                    new CategoryEntity
                    {
                        Name="Іграшки"
                    },
                    new CategoryEntity
                    {
                        Name="Ветеринарні препарати"
                    }
                });
                context.SaveChanges();
            }

        }*/

        /*private static void SeedInventoryStatus(IServiceProvider service)
        {
            var context = service.GetRequiredService<AppEFContext>();
            if (!context.InventoryStatus.Any())
            {
                context.InventoryStatus.AddRange(new List<InventoryStatusEntity>
                {
                    new InventoryStatusEntity
                    {
                        Name="У наявності"
                    },
                    new InventoryStatusEntity
                    {
                        Name="Очікуєм"
                    },

                });
                context.SaveChanges();
            }

        }*/




        private static void SeedBaner(IServiceProvider service)
        {

            var context = service.GetRequiredService<AppEFContext>();

            if (!context.Baner.Any())
            {
                
                BanerEntity product = new BanerEntity
                {
                   
                    Name = "Royal Canin",
                    Description = "Корм для дорослих собак середніх порід (чия доросла вага становить від 11 до 25 кг) у віці від 12 місяців до 7 років",
                    //DateCreate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc),
                    
                   
                    StartPhoto = "https://zoolove.com.ua/components/com_jshopping/files/img_products/full_royal_canin_medium_adult_sostav_4_kg_zoolove_com_ua.jpg"
                         

                };

                context.Baner.Add(product);

                context.SaveChanges();

            }

        }
    }
}
