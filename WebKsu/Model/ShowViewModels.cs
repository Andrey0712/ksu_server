using System.ComponentModel.DataAnnotations;

namespace WebKsu.Model
{
    public class ShowViewModels
    {
        /// <summary>
        /// Модель для створення show
        /// </summary>
        public class ShowAddViewModel { 
            [Display(Name = "Виставка"), Required(ErrorMessage = "Поле 'Виставка' не може бути пустим!")]
            public int ShowId { get; set; }
            [Display(Name = "Стать"), Required(ErrorMessage = "Поле 'Стать' не може бути пустим!")]
            public int SexId { get; set; }
            [Display(Name = "Клас"), Required(ErrorMessage = "Поле 'Клас' не може бути пустим!")]
            public int ClassId { get; set; }
        [Display(Name = "Порода"), Required(ErrorMessage = "Поле 'Порода' не може бути пустим!")]
            public string Breed { get; set; }
            [Display(Name = "Кличка"), Required(ErrorMessage = "Поле 'Кличка' не може бути пустим!")]
            public string NameDog { get; set; }
            [Display(Name = "Окрас"), Required(ErrorMessage = "Поле 'Окрас' не може бути пустим!")]
            public string Color { get; set; }
            
            [Display(Name = "Номер родоводу"), Required(ErrorMessage = "Поле 'Номер родоводу' не може бути пустим!")]
            public string Pedigree { get; set; }
            [Display(Name = "Чіп або тату"), Required(ErrorMessage = "Поле 'Чіп або тату' не може бути пустим!")]
            public string Chip { get; set; }
            [Display(Name = "Батько, кличка номер родоводу"), Required(ErrorMessage = "Поле 'Батько, кличка номер родоводу' не може бути пустим!")]
            public string Father { get; set; }
            [Display(Name = "Мати, кличка номер родоводу"), Required(ErrorMessage = "Поле 'Мати, кличка номер родоводу' не може бути пустим!")]
            public string Mather { get; set; }
            [Display(Name = "Власник"), Required(ErrorMessage = "Поле 'Власник' не може бути пустим!")]
            public string Owner { get; set; }
            [Display(Name = "Заводчик"), Required(ErrorMessage = "Поле 'Заводчик' не може бути пустим!")]
            public string Breeder { get; set; }
            [Display(Name = "Адреса"), Required(ErrorMessage = "Поле 'Адреса' не може бути пустим!")]
            public string Adress { get; set; }
            
            [Display(Name = "Телефон"), Required(ErrorMessage = "Поле 'Телефон' не може бути пустим!")]
            public string Phone { get; set; }
            [Display(Name = "email"), Required(ErrorMessage = "Поле 'email' не може бути пустим!")]
            public string Email { get; set; }
            
            [Display(Name = "Фотографія1")]
            public IFormFile StartPhoto1 { get; set; }
            [Display(Name = "Фотографія2")]
            public IFormFile StartPhoto2 { get; set; }
            [Display(Name = "Фотографія3")]
            public IFormFile StartPhoto3 { get; set; }
            [Display(Name = "Фотографія4")]
            public IFormFile StartPhoto4 { get; set; }
            [Display(Name = "Фотографія5")]
            public IFormFile StartPhoto5 { get; set; }
            [Display(Name = "Фотографія6")]
            public IFormFile StartPhoto6 { get; set; }
            [Display(Name = "Дата народженя"), Required(ErrorMessage = "Поле 'Дата народженя' не може бути пустим!")]
            public DateTime Date { get; set; }

        }


    }
}
