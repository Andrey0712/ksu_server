using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebKsu.Data.Entities
{
    [Table("tblShow")]
    public class ShowEntity : BaseEntity<int>
    {
        
            [Display(Name = "Виставка"), Required(ErrorMessage = "Поле 'Виставка' не може бути пустим!")]
        [ForeignKey("ShowIdEntity")]
        public int? ShowId { get; set; }
            public virtual ShowIdEntity ShowIdEntity { get; set; }
        [Display(Name = "Клас"), Required(ErrorMessage = "Поле 'Клас' не може бути пустим!")]
        [ForeignKey("ClassIdEntity")]
        public int? ClassId { get; set; }
            public virtual DogClasesEntity ClassIdEntity { get; set; }
             [Display(Name = "Порода"), Required(ErrorMessage = "Поле 'Порода' не може бути пустим!")]
            public string Breed { get; set; }
        [Display(Name = "Окрас"), Required(ErrorMessage = "Поле 'Окрас' не може бути пустим!")]
            public string Color { get; set; }
[Display(Name = "Кличка"), Required(ErrorMessage = "Поле 'Кличка' не може бути пустим!")]
            public string NameDog { get; set; }
        [Display(Name = "Стать"), Required(ErrorMessage = "Поле 'Стать' не може бути пустим!")]
        [ForeignKey("SexEntity")]
        public int? SexId { get; set; }
            public virtual SexEntity SexEntity { get; set; }
        [Display(Name = "Дата народженя"), Required(ErrorMessage = "Поле 'Дата народженя' не може бути пустим!")]
        public DateTime Date { get; set; }



        [Display(Name = "Номер родоводу"), Required(ErrorMessage = "Поле 'Номер родоводу' не може бути пустим!")]
            public string Pedigree { get; set; }
            [Display(Name = "Чіп або тату"), Required(ErrorMessage = "Поле 'Чіп або тату' не може бути пустим!")]
            public string Chip { get; set; }
            [Display(Name = "Батько, кличка номер родоводу"), Required(ErrorMessage = "Поле 'Батько, кличка номер родоводу' не може бути пустим!")]
            public string Father { get; set; }
            [Display(Name = "Мати, кличка номер родоводу"), Required(ErrorMessage = "Поле 'Мати, кличка номер родоводу' не може бути пустим!")]
            public string Mather { get; set; }
            
            [Display(Name = "Заводчик"), Required(ErrorMessage = "Поле 'Заводчик' не може бути пустим!")]
            public string Breeder { get; set; }
        [Display(Name = "Власник"), Required(ErrorMessage = "Поле 'Власник' не може бути пустим!")]
            public string Owner { get; set; }
            [Display(Name = "Адреса"), Required(ErrorMessage = "Поле 'Адреса' не може бути пустим!")]
            public string Adress { get; set; }
            [Display(Name = "Телефон"), Required(ErrorMessage = "Поле 'Телефон' не може бути пустим!")]
            public string Phone { get; set; }
            [Display(Name = "email"), Required(ErrorMessage = "Поле 'email' не може бути пустим!")]
            public string Email { get; set; }

            [Display(Name = "Фотографія1")]
            public string StartPhoto1 { get; set; }
            [Display(Name = "Фотографія2")]
            public string StartPhoto2 { get; set; }
            [Display(Name = "Фотографія3")]
            public string StartPhoto3 { get; set; }
            [Display(Name = "Фотографія4")]
            public string StartPhoto4 { get; set; }
            [Display(Name = "Фотографія5")]
            public string StartPhoto5 { get; set; }
            [Display(Name = "Фотографія6")]
            public string StartPhoto6 { get; set; }
            
        [Display(Name = "Валідація")]
        [ForeignKey("ValidateShowEntity")]
        public int? ValidateShowId { get; set; }
        public virtual ValidateShowEntity ValidateShowEntity { get; set; }
    }
    
}
