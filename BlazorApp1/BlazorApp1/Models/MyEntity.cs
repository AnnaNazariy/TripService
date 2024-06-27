using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp1.Models
{
    public class MyEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [NotMapped] 
        public string TransientProperty { get; set; }
    }
}
