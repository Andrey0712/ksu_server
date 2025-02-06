using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace WebKsu.Data.Entities
{
    [Table("tblBaners")]
    public class BanerEntity:BaseEntity<int>
    {
        [Required, StringLength(500)]
        public string Name { get; set; }
        [Display(Name = "Титульна фотографія")]
        public string? StartPhoto { get; set; }
        [Display(Name = "Опис оголошеня"), Required(ErrorMessage = "Поле 'Опис' не може бути пустим!")]
        public string Description { get; set; }     
        //public virtual ICollection<ProductImageEntity> ProductImages { get; set; }
        
    }
}
