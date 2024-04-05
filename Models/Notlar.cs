using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCore8ApiDapper.Models
{
    [Table("Notlar")]
    public class Notlar
    {
        [Key]
        public int id { get; set; }
        public string ad { get; set; }
    }
}
