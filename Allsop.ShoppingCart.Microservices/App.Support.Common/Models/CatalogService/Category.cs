using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Support.Common.Models.CatalogService
{
    [Table("Categories")]
    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string Id { get; set; }
        
        [Column(name: "Name")]
        public string Name { get; set; }
        
        [Column(name: "Code")]
        public string Code { get; set; }
    }
}