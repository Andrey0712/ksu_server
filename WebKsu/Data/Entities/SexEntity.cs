using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebKsu.Data.Entities
{
    [Table("tblSex")]
    public class SexEntity
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(10)]
        public string Name { get; set; }
        public virtual ICollection<ShowEntity> Shows { get; set; }
    }
}
