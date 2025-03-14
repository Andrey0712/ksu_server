using System.ComponentModel.DataAnnotations;

namespace WebKsu.Model
{
    public class RunLineViewModel
    {
        /// <summary>
        /// Модель для створення runLine
        /// </summary>
        public class RunLineAddViewModel
        {
           
            [Display(Name = "Опис новини"), Required(ErrorMessage = "Поле 'Опис' не може бути пустим!")]
            public string Description { get; set; }

        }


        public class RunLineItemViewModel
        {
            public int Id { get; set; }
           
            public string Description { get; set; }
           

        }

        public class RunLineDelViewModel
        {
            public int Id { get; set; }


        }
        /// <summary>
        /// Модель для зміни 
        /// </summary>
        public class RunLineToEdit
        {
            [Display(Name = "Id")]
            public int Id { get; set; }
            
            [Display(Name = "Опис товару")]
            public string Description { get; set; }
            

        }
    }
}
