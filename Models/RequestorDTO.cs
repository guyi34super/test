using System.ComponentModel.DataAnnotations;

namespace ELCAStock.Models
{
    public class RequestorDTO
    {
        [Required]
        public string Visa { get; set; } = string.Empty;

        [Required]
        public string FullName { get; set; } = string.Empty;
    }
}
