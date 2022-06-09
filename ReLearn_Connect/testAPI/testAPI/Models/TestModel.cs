using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace testAPI.Models
{
    public class TestModel
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string? Name { get; set; }
        [Column(TypeName ="nvarchar(50)")]
        public string? Information { get; set; }
        [Range(1,100,ErrorMessage ="OOP number just only from 1 to 100")]
        public long numberMage { get; set; }
    }
}
