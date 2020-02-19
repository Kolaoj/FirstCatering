using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace FirstCatering.API.Entities
{

    public class EmployeeData
    {
        [Required(ErrorMessage = "A Card Id is required")]
        [RegularExpression(@"\A(?i)[a-z0-9]{16}\z")]
        public string CardId { get; set; }

        [Key]
        [Required]
        [MinLength(6)]
        [MaxLength(120)]
        public string EmployeeId { get; set; }

        [Required(ErrorMessage = "A first name is required")]
        [MaxLength(50)] 
        public string FirstName { get; set; }
        
        [Required(ErrorMessage = "A last name is required")]
        [MaxLength(50)]
        public string LastName { get; set; }
        
        [Required(ErrorMessage = "An email address is required")]
        [MaxLength(200)]
        [RegularExpression(@"^(?i)(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$")]
        public string Email { get; set; }
       
        [Required(ErrorMessage = "A 4 digit pin is required")]
        [RegularExpression(@"\A\d{4}\z")]
        public string Pin { get; set; }
        
        public decimal Balance { get; set; }
        
        [RegularExpression(@"\A(07|\+?447)\d{9}\z")]
        [Required(ErrorMessage = "A mobile number is required")]
        public string MobileNumber { get; set; }
    }
}
