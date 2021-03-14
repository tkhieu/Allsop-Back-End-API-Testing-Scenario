using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Support.Common.Models
{
    [Table("Categories")]
    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string Id { get; init; }
        
        [Column(name: "Name")]
        public string Name { get; init; }
        
        [Column(name: "Code")]
        public string Code { get; init; }
    }
}