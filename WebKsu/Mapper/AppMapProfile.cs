using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.Globalization;
using WebKsu.Data.Entities;
using WebKsu.Data.Entities.Identity;
using WebKsu.Model;
using static WebKsu.Model.BanerViewModel;
using static WebKsu.Model.RunLineViewModel;
/*using static WebKsu.Model.ShowViewModels;*/

namespace WebKsu.Mapper
{
    public class AppMapProfile : Profile
    {
        public AppMapProfile()
        {
            var cultureInfo = new CultureInfo("ua-UA");

            CreateMap<RegisterViewModel, AppUser>()
                .ForMember(x => x.UserName, opt => opt.MapFrom(x => x.Email))
                .ForMember(x => x.Owner, opt => opt.MapFrom(opt => opt.Owner))
                .ForMember(x => x.Address, opt => opt.MapFrom(opt => opt.Address))
                .ForMember(x => x.Email, opt => opt.MapFrom(opt => opt.Email))
                .ForMember(x => x.Phone, opt => opt.MapFrom(opt => opt.Phone));
               

            //мепер для вівода юзера
            CreateMap<AppUser, UserItemViewModel>()
                .ForMember(x => x.Owner, opt => opt.MapFrom(opt => opt.Owner))
                .ForMember(x => x.Email, opt => opt.MapFrom(opt => opt.Email));


            CreateMap<UserEditViewModel, AppUser>()

                .ForMember(x => x.UserName, opt => opt.MapFrom(x => x.Email))
                .ForMember(x=>x.Id, opt => opt.Ignore())
                .ForMember(x => x.Owner, opt => opt.MapFrom(opt => opt.Owner))
                .ForMember(x => x.Address, opt => opt.MapFrom(opt => opt.Address))
                .ForMember(x => x.Email, opt => opt.MapFrom(opt => opt.Email))
                .ForMember(x => x.Phone, opt => opt.MapFrom(opt => opt.Phone));


            CreateMap<AppUser, ProfileViewModel>();


            //мепери для класів собак
            CreateMap<CreateDogsClasessViewModel, DogClasesEntity>();
            CreateMap<DogClasesEntity, DogsClasessItemViewModel>();

            //мепери для радіобатона виставок
            CreateMap<CreateShowIdViewModel, ShowIdEntity>();
            CreateMap<ShowIdEntity, ShowIdItemViewModel>();

            //мепери для радіобатона статі
            CreateMap<CreateSexViewModel, SexEntity>();
            CreateMap<SexEntity, SexItemViewModel>();
            //мепери для малидності заповненя форми
            CreateMap<CreateValidateViewModel, ValidateShowEntity>();
            CreateMap<ValidateShowEntity, ValidateItemViewModel>();

            //мепери для блога
            CreateMap<BanerAddViewModel, BanerEntity>()
                //.ForMember(x => x.ProductImages, opt => opt.Ignore())
                .ForMember(x => x.DateCreated, opt => opt.MapFrom(x =>
                    DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc)))

               .ForMember(x => x.StartPhoto, opt => opt.Ignore())
               .ForMember(x => x.Name, opt => opt.MapFrom(opt => opt.Name))
               .ForMember(x => x.Description, opt => opt.MapFrom(opt => opt.Description));
               

            CreateMap<BanerEntity, BanerItemViewModel>()
                .ForMember(x => x.DateCreate, opt => opt.MapFrom(x => x.DateCreated.ToString("dd.MM.yyyy")))
                 .ForMember(x => x.Image, opt => opt.MapFrom(x => $"uploads/{x.StartPhoto}"));

            //мепери для runline
            CreateMap<RunLineAddViewModel, RunLineEntity>()
                        .ForMember(x => x.DateCreated, opt => opt.MapFrom(x =>
                   DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc)))
                                     
              .ForMember(x => x.Description, opt => opt.MapFrom(opt => opt.Description));

            CreateMap<RunLineEntity, RunLineItemViewModel>();

            CreateMap<ValidateShowEntity, ValidateItemViewModel>();

            //мепери для show
            CreateMap<ShowAddViewModel, ShowEntity>()
               
                .ForMember(x => x.DateCreated, opt => opt.MapFrom(x =>
                    DateTime.SpecifyKind(DateTime.Now.AddHours(-3), DateTimeKind.Utc)))

               .ForMember(x => x.StartPhoto1, opt => opt.Ignore())
               .ForMember(x => x.StartPhoto2, opt => opt.Ignore())
               .ForMember(x => x.StartPhoto3, opt => opt.Ignore())
               .ForMember(x => x.StartPhoto4, opt => opt.Ignore())
               .ForMember(x => x.StartPhoto5, opt => opt.Ignore())
               .ForMember(x => x.StartPhoto6, opt => opt.Ignore())
               
               .ForMember(x => x.ClassId, opt => opt.MapFrom(opt => opt.ClassId))
                .ForMember(x => x.ShowId, opt => opt.MapFrom(opt => opt.ShowId))
                 .ForMember(x => x.SexId, opt => opt.MapFrom(opt => opt.SexId))

               .ForMember(x => x.Breed, opt => opt.MapFrom(opt => opt.Breed))
               .ForMember(x => x.Color, opt => opt.MapFrom(opt => opt.Color))
               .ForMember(x => x.NameDog, opt => opt.MapFrom(opt => opt.NameDog))
                .ForMember(x => x.Pedigree, opt => opt.MapFrom(opt => opt.Pedigree))
                .ForMember(x => x.Chip, opt => opt.MapFrom(opt => opt.Chip))
               .ForMember(x => x.Father, opt => opt.MapFrom(opt => opt.Father))
               .ForMember(x => x.Mather, opt => opt.MapFrom(opt => opt.Mather))
               .ForMember(x => x.Date, opt => opt.Ignore())

                //.ForMember(x => x.Date, opt => opt.MapFrom(opt => opt.Date))
                /*.ForMember(x => x.Date, opt => opt.MapFrom(x =>
                DateTime.ParseExact(x.Date, "D", cultureInfo)))*/
                //DateTime.SpecifyKind(DateTime.Parse(x.Date, cultureInfo), DateTimeKind.Utc)))
                .ForMember(x => x.Breeder, opt => opt.MapFrom(opt => opt.Breeder))
                 .ForMember(x => x.Owner, opt => opt.MapFrom(opt => opt.Owner))
               .ForMember(x => x.Adress, opt => opt.MapFrom(opt => opt.Adress))
               .ForMember(x => x.Phone, opt => opt.MapFrom(opt => opt.Phone))
                .ForMember(x => x.Email, opt => opt.MapFrom(opt => opt.Email))
            .ForMember(x => x.ValidateShowId, opt => opt.MapFrom(opt => 1));



            /*CreateMap<ProductEntity, ProductItemViewModel>()

               .ForMember(x => x.Price, opt => opt.MapFrom(x => x.Price.ToString(cultureInfo)))
               .ForMember(x => x.StartPhoto, opt => opt.MapFrom(x => $"/uploads/{x.StartPhoto}"));*/

           
            CreateMap<ShowEntity, ShowItemViewModel>()
               .ForMember(x => x.StartPhoto1, opt => opt.MapFrom(x => $"uploads/{x.StartPhoto1}"))
               .ForMember(x => x.StartPhoto2, opt => opt.MapFrom(x => $"uploads/{x.StartPhoto2}"))
               .ForMember(x => x.StartPhoto3, opt => opt.MapFrom(x => $"uploads/{x.StartPhoto3}"))
               .ForMember(x => x.StartPhoto4, opt => opt.MapFrom(x => $"uploads/{x.StartPhoto4}"))
               .ForMember(x => x.StartPhoto5, opt => opt.MapFrom(x => $"uploads/{x.StartPhoto5}"))
               .ForMember(x => x.StartPhoto6, opt => opt.MapFrom(x => $"uploads/{x.StartPhoto6}"))
               .ForMember(x => x.ShowIdEntity, opt => opt.MapFrom(x => x.ShowIdEntity.Name))
               .ForMember(x => x.ClassIdEntity, opt => opt.MapFrom(x => x.ClassIdEntity.Name))
               .ForMember(x => x.SexEntity, opt => opt.MapFrom(x => x.SexEntity.Name))
               .ForMember(x => x.Breed, opt => opt.MapFrom(x => x.Breed))
                .ForMember(x => x.NameDog, opt => opt.MapFrom(x => x.NameDog))
                 .ForMember(x => x.Color, opt => opt.MapFrom(x => x.Color))
                  .ForMember(x => x.Pedigree, opt => opt.MapFrom(x => x.Pedigree))
                   .ForMember(x => x.Chip, opt => opt.MapFrom(x => x.Chip))
                    .ForMember(x => x.Father, opt => opt.MapFrom(x => x.Father))
                     .ForMember(x => x.Mather, opt => opt.MapFrom(x => x.Mather))
                     /* .ForMember(x => x.Date, opt => opt.MapFrom(x => x.Date))*/
                      .ForMember(x => x.Date, opt => opt.MapFrom(x => x.Date.ToString("dd.MM.yyyy")))
                       .ForMember(x => x.Owner, opt => opt.MapFrom(x => x.Owner))
                        .ForMember(x => x.Breeder, opt => opt.MapFrom(x => x.Breeder))
                         .ForMember(x => x.Adress, opt => opt.MapFrom(x => x.Adress))
                          .ForMember(x => x.Phone, opt => opt.MapFrom(x => x.Phone))
                         .ForMember(x => x.Email, opt => opt.MapFrom(x => x.Email))
            .ForMember(x => x.ValidateShowEntity, opt => opt.MapFrom(x => x.ValidateShowEntity.Name));


            /* CreateMap<CartAddViewModel, CartEntity>();

             CreateMap<CartEntity, CartItemViewModel>()
                  .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Product.Id))
                .ForMember(x => x.ProductName, opt => opt.MapFrom(x => x.Product.Name))
                .ForMember(x => x.ProductImage, opt => opt.MapFrom(x => $"uploads/{x.Product.StartPhoto}"))
                .ForMember(x => x.ProductPrice, opt => opt.MapFrom(x => x.Product.Price))
              .ForMember(x => x.QuantityOLL, opt => opt.MapFrom(x => x.Product.Quantity));



            

             CreateMap<OrderAddViewModel, OrderEntity>()
                 .ForMember(x => x.DateCreated, opt => opt.MapFrom(x =>
                     DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc)))
                 .ForMember(x => x.OrderItems, opt => opt.Ignore());
             //.ForMember(x => x.OrderStatus, opt => opt.MapFrom(x => "Нове замовленя"));

             CreateMap<OrderItemAddViewModel, OrderItemEntity>()
                 .ForMember(x => x.DateCreated, opt => opt.MapFrom(x =>
                     DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc)));

             CreateMap<OrderItemEntity, OrderItemViewModel>()
                 .ForMember(x => x.Product, opt => opt.MapFrom(x => x.Product.Name))
                  .ForMember(x => x.Price, opt => opt.MapFrom(x => x.BuyPrice));
             //.ForMember(x => x.Suma, opt => opt.MapFrom(x => { x.BuyPrice}*{x.q)) 
             //.ForMember(x => x.ProductImage, opt => opt.MapFrom(x => x.Product.ProductImages.Select(x => x.Name)));

             CreateMap<OrderEntity, OrderViewModel>()
                 .ForMember(x => x.DateCreated, opt => opt.MapFrom(x => x.DateCreated.ToString("dd.MM.yyyy HH:mm:ss")))
                 .ForMember(x => x.StatusName, opt => opt.MapFrom(x => x.OrderStatus.Name))
                 .ForMember(x => x.Items, opt => opt.MapFrom(x => x.OrderItems));*/
        }


    }
}
