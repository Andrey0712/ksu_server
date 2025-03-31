using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Security.Claims;
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
                    SeedRunLine(services);
                     SeedSex(services);
                    SeedSHowId(services);
                    SeedDogClases(services);
                    /*SeedProduct(services);;*/
                    SeedStatusesShow(services);

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

        private static void SeedStatusesShow(IServiceProvider service)
        {
            var context = service.GetRequiredService<AppEFContext>();
            if (!context.ValidateShowEntity.Any())
            {
                context.ValidateShowEntity
                        .Add(new ValidateShowEntity
                        {
                            Name = "Нова заявка"
                        });

                context.ValidateShowEntity
                    .Add(new ValidateShowEntity
                    {
                        Name = "Погоджено"
                    });

                context.ValidateShowEntity
                    .Add(new ValidateShowEntity
                    {
                        Name = "Відхилено"
                    });

                context.SaveChanges();
            }

        }

        private static void SeedDogClases(IServiceProvider service)
        {
            var context = service.GetRequiredService<AppEFContext>();
            if (!context.ClassIdEntity.Any())
            {
                context.ClassIdEntity.AddRange(new List<DogClasesEntity>
                {
                    new() {
                        Name="Клас бебі 3-6 місяців"
                    },
                    new() {
                        Name="Клас цуценят 6-9 місяців"
                    },
                    new() {
                        Name="Клас юніорів 9-18 місяців"
                    },
                    new() {
                        Name="Клас інтермедія 15 міс-2 роки"
                    },
                    new() {
                        Name="Клас відкритий 15 місяців"
                    },
                    new() {
                        Name="Робочий клас з 15 місяців"
                    },
                    new() {
                        Name="Клас чемпіонів 15 місяців"
                    },
                    new() {
                        Name="Клас ветеранів з 8 років"
                    }
                });
                context.SaveChanges();
            }

        }

        private static void SeedSex(IServiceProvider service)
        {
            var context = service.GetRequiredService<AppEFContext>();
            if (!context.SexEntity.Any())
            {
                context.SexEntity.AddRange(new List<SexEntity>
                {
                    new SexEntity
                    {
                        Name="Кобель"
                    },
                    new SexEntity
                    {
                        Name="Сука"
                    },

                });
                context.SaveChanges();
            }

        }
        private static void SeedSHowId(IServiceProvider service)
        {
            var context = service.GetRequiredService<AppEFContext>();
            if (!context.ShowIdEntity.Any())
            {
                context.ShowIdEntity.AddRange(new List<ShowIdEntity>
                {
                    new ShowIdEntity
                    {
                        Name="CAC-UA Червона калина"
                    },
                    new ShowIdEntity
                    {
                        Name="CACIB-FCI Бурштиновий кубок"
                    },

                });
                context.SaveChanges();
            }

        }

        private static void SeedRunLine(IServiceProvider service)
        {

            var context = service.GetRequiredService<AppEFContext>();

            if (!context.RunLine.Any())
            {

                RunLineEntity product = new RunLineEntity
                {

                  
                    Description = "     Надійшли нові документи, завітайте на вкладку НОВИНИ",
                   
                };

                context.RunLine.Add(product);

                context.SaveChanges();

            }

        }


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
