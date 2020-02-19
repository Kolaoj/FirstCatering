using System.ComponentModel.DataAnnotations;

namespace FirstCatering.API.Models
{
    public class EmployeeDataForBalanceChangeDto
    {

        [Required]
        public decimal Balance { get; set; }
    }
}
