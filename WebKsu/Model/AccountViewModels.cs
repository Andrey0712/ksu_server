namespace WebKsu.Model
{
    public class RegisterViewModel
    {
        /// <summary>
        /// Емейл користувача
        /// </summary>
        /// <example>gg@gg.gg</example>
        public string Email { get; set; }
        /// <summary>
        /// ПІБ користувача
        /// </summary>
        /// <example>Остапенко Тарас Петрович</example>
        public string Owner { get; set; }
        /// <summary>
        /// Адреса користувача
        /// </summary>
        /// <example>м.Рівне вул.Корнаухова 15, кв 2</example>
        public string Address { get; set; }
        /// <summary>
        /// Телефон користувача
        /// </summary>
        /// <example>+38 097 846 2387</example>
        public string Phone { get; set; }
        /// <summary>
        /// Пароль користувача
        /// </summary>
        /// <example>12345</example>
        public string Password { get; set; }
        /// <summary>
        /// Пароль користувача
        /// </summary>
        /// <example>12345</example>
        public string ConfirmPassword { get; set; }
    }

    public class LoginUserModel
    {

        /// <summary>
        /// Емейл користувача
        /// </summary>
        /// <example>gg@gg.gg</example>
        public string Email { get; set; }
        /// <summary>
        /// Пароль користувача
        /// </summary>
        /// <example>12345</example>
        public string Password { get; set; }
    }


    public class UserItemViewModel
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string Owner { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
    //тип для токена в контролер логин Example Value Schema в документацию свагера

    public class TokenResponceViewModel
    {
        /// <summary>
        /// token
        /// </summary>
        /// <example>eyJpZCI6IjEzMzciLCJ1c2VybmFtZSI6ImJpem9uZSIsImlhdCI6MTU5NDIwOTYwMCwicm9sZSI6InVzZXIifQ</example>
        public string token { get; set; }
    }

    public class UserEditViewModel
    {
       /* /// <summary>
        /// id користувача
        /// </summary>
        /// <example>15</example>
        public long Id { get; set; }*/
        /// <summary>
        /// ПІБ користувача
        /// </summary>
        /// <example>Остапенко Тарас Петрович</example>
        public string Owner { get; set; }
        /// <summary>
        /// Емейл користувача
        /// </summary>
        /// <example>gg@gg.gg</example>
        public string Email { get; set; }
        /// <summary>
        /// Адреса користувача
        /// </summary>
        /// <example>м.Рівне вул.Корнаухова 15, кв 2</example>
        public string Address { get; set; }
        /// <summary>
        /// Телефон користувача
        /// </summary>
        /// <example>+38 097 846 2387</example>
        public string Phone { get; set; }
    }
    public class UserDelViewModel
    {
        /// <summary>
        /// id користувача
        /// </summary>
        /// <example>15</example>
        public long Id { get; set; }

    }

   /* public class ExternalLoginRequest
    {
        public string Provider { get; set; }
        public string Token { get; set; }
    }*/
}
