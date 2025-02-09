using AutoMapper;
using System.Globalization;
using WebKsu.Data.Entities;
using WebKsu.Data.Entities.Identity;
using WebKsu.Model;
using static WebKsu.Model.BanerViewModel;

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




            //мепери для категорії
            /* CreateMap<CreateCategoryViewModel, CategoryEntity>();
             CreateMap<CategoryEntity, CategoryItemViewModel>();*/

            //мепери для блога
            CreateMap<BanerAddViewModel, BanerEntity>()
                //.ForMember(x => x.ProductImages, opt => opt.Ignore())
                .ForMember(x => x.DateCreated, opt => opt.MapFrom(x =>
                    DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc)))

               .ForMember(x => x.StartPhoto, opt => opt.Ignore())
               .ForMember(x => x.Name, opt => opt.MapFrom(opt => opt.Name))
               .ForMember(x => x.Description, opt => opt.MapFrom(opt => opt.Description));
               

            CreateMap<BanerEntity, BanerItemViewModel>()

                 .ForMember(x => x.Image, opt => opt.MapFrom(x => $"/uploads/{x.StartPhoto}"));

                      

           /* CreateMap<CartAddViewModel, CartEntity>();

            CreateMap<CartEntity, CartItemViewModel>()
                 .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Product.Id))
               .ForMember(x => x.ProductName, opt => opt.MapFrom(x => x.Product.Name))
               .ForMember(x => x.ProductImage, opt => opt.MapFrom(x => $"uploads/{x.Product.StartPhoto}"))
               .ForMember(x => x.ProductPrice, opt => opt.MapFrom(x => x.Product.Price))
             .ForMember(x => x.QuantityOLL, opt => opt.MapFrom(x => x.Product.Quantity));



            CreateMap<OrderStatusEntity, OrderStatusItemViewModel>();

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
