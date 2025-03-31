using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace WebKsu.Data.Entities
{
    [Table("tblDogClases")]
    public class DogClasesEntity
    {
        [Key]
        public int Id
        {
            get; set;
        }
        [Required, StringLength(100)]
        public string Name
        {
            get; set;
        }
        public virtual ICollection<ShowEntity> Shows { get; set; }
    }
}
