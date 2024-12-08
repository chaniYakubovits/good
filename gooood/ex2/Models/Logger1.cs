using System.ComponentModel.DataAnnotations;

namespace ex2.Models
{
    public class Logger1
    {
        [Key]
        public string Messege { get; set; } = null!;

        public DateTime? Date { get; set; }
    }
}
