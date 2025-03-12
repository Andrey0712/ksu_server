using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebKsu.Data.Entities
{
    [Table("tblRunLine")]
    public class RunLineEntity : BaseEntity<int>
    {
        
        public string Description { get; set; }
        //public virtual ICollection<ProductImageEntity> ProductImages { get; set; }

    }
}
