using System.ComponentModel.DataAnnotations;

namespace FirstCatering.API.Models
{
    public class EmployeeDataForRetrievalDto
    {
        [Required]
        public string Pin { get; set; }

        [Required]
        public string CardId { get; set; }

    }
}
