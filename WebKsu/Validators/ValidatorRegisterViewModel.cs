using FluentValidation;
using Microsoft.AspNetCore.Identity;
using WebKsu.Data.Entities.Identity;
using WebKsu.Model;

namespace WebKsu.Validators
{
    public class ValidatorRegisterViewModel : AbstractValidator<RegisterViewModel>
    {
        private readonly UserManager<AppUser> _userManager;
        public ValidatorRegisterViewModel(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            RuleFor(x => x.Email)
               .NotEmpty().WithMessage("Поле пошта є обов'язковим!")
               .EmailAddress().WithMessage("Пошта є не коректною!")
               .DependentRules(() =>
               {
                   RuleFor(x => x.Email).Must(BeUniqueEmail)

                    .WithMessage("Дана пошта уже зареєстрована!");
               });
            RuleFor(x => x.Password)
                .NotEmpty().WithName("Password").WithMessage("Поле пароль є обов'язковим!")
                .MinimumLength(5).WithName("Password").WithMessage("Поле пароль має містити міннімум 5 символів!");

            //.Matches("[A-Z]").WithName("Password").WithMessage("Password must contain one or more capital letters.")
            //.Matches("[a-z]").WithName("Password").WithMessage("Password must contain one or more lowercase letters.")
            //.Matches(@"\d").WithName("Password").WithMessage("Password must contain one or more digits.")
            //.Matches(@"[][""!@$%^&*(){}:;<>,.?/+_=|'~\\-]").WithName("Password").WithMessage("Password must contain one or more special characters.")
            //.Matches("^[^£# “”]*$").WithName("Password").WithMessage("Password must not contain the following characters £ # “” or spaces.");

            RuleFor(x => x.Owner)
                .NotEmpty().WithMessage("Поле є обов'язковим!")
                .MinimumLength(2).WithMessage("Поле має мати міннімум 2 символів!");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Поле є обов'язковим!")
                .MinimumLength(3).WithMessage("Поле має мати міннімум 3 символів!");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Поле  є обов'язковим!")
                .Matches(@"^(\+0?38\s)?\(?\d{3}\)?[\s.-]\d{3}[\s.-]\d{4}$")
                //.MinimumLength(10)
                .WithMessage("Поле має мати вигляд +38 097 846 2387");

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty().WithName("ConfirmPassword").WithMessage("Поле є обов'язковим!")
                 .Equal(x => x.Password).WithMessage("Поролі не співпадають!");
        }
        private bool BeUniqueEmail(string email)
        {
            return _userManager.FindByEmailAsync(email).Result == null;
        }
    }

    public class ValidatorLoginViewModel : AbstractValidator<LoginUserModel>
    {
        private UserManager<AppUser> _userManager;
        public ValidatorLoginViewModel(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            RuleFor(x => x.Email)
               .NotEmpty().WithMessage("Поле пошта є обов'язковим!")
               .EmailAddress().WithMessage("Пошта є не коректною!")
               .DependentRules(() =>
               {
                   RuleFor(x => x.Email).Must(AvailableEmail)

                    .WithMessage("Дана пошта уже зареєстрована!");
               });
            RuleFor(x => x.Password)
                .NotEmpty().WithName("Password").WithMessage("Поле пароль є обов'язковим!")
                .MinimumLength(5).WithName("Password").WithMessage("Поле пароль має містити міннімум 5 символів!");
        }

        private bool AvailableEmail(string email)
        {
            return _userManager.FindByEmailAsync(email).Result != null;
        }

    }

    public class ValidatorEditViewModel : AbstractValidator<UserEditViewModel>
    {
        private readonly UserManager<AppUser> _userManager;
        public ValidatorEditViewModel(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            RuleFor(x => x.Email)
               .NotEmpty().WithMessage("Поле пошта є обов'язковим!")
               .EmailAddress().WithMessage("Пошта є не коректною!");
               /*.DependentRules(() =>
               {
                   RuleFor(x => x.Email).Must(BeUniqueEmail)

                    .WithMessage("Дана пошта уже зареєстрована!");
               });*/
            
            RuleFor(x => x.Owner)
                .NotEmpty().WithMessage("Поле є обов'язковим!")
                .MinimumLength(2).WithMessage("Поле має мати міннімум 2 символів!");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Поле є обов'язковим!")
                .MinimumLength(3).WithMessage("Поле має мати міннімум 3 символів!");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Поле  є обов'язковим!")
                .Matches(@"^(\+0?38\s)?\(?\d{3}\)?[\s.-]\d{3}[\s.-]\d{4}$")
                //.MinimumLength(10)
                .WithMessage("Поле має мати вигляд +38 097 846 2387");

           
        }
       /* private bool BeUniqueEmail(string email)
        {
            return _userManager.FindByEmailAsync(email).Result == null;
        }*/
    }

}
