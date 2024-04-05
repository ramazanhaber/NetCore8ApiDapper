using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCore8ApiDapper.Models
{
    [Table("Ogrenciler")]
    public class Ogrenciler
    {
        [Key]
        public int id { get; set; }
        public string ad { get; set; }
        public int yas { get; set; }
    }
}
