using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebKsu.Data.Entities
{
    [Table("tblValidateShow")]
    public class ValidateShowEntity
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
