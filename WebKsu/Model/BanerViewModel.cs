

using System.ComponentModel.DataAnnotations;

namespace WebKsu.Model
{
    public class BanerViewModel
    {
        /// <summary>
        /// Модель для створення банера
        /// </summary>
        public class BanerAddViewModel
        {
            [Required, StringLength(500)]
            public string Name { get; set; }
            [Display(Name = "Титульна фотографія")]
            public IFormFile? StartPhoto { get; set; }
            [Display(Name = "Опис оголошеня"), Required(ErrorMessage = "Поле 'Опис' не може бути пустим!")]
            public string Description { get; set; }

        }

       
        public class BanerItemViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string? Image { get; set; }
           
        }

        public class BanerDelViewModel
        {
            public int Id { get; set; }
           

        }

        public class BanerViewModelImages
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string StartPhoto { get; set; }
            public string DateCreate { get; set; }
           
        }
        
        /// <summary>
        /// Модель для зміни товару
        /// </summary>
        public class BanerToEdit
        {
            [Display(Name = "Id")]
            public int Id { get; set; }
            [Display(Name = "Назва")]
            public string Name { get; set; }
            [Display(Name = "Опис товару")]
            public string Description { get; set; }
            [Display(Name = "Титульна фотографія")]
            public IFormFile? StartPhoto { get; set; }
           
        }
    }
}
