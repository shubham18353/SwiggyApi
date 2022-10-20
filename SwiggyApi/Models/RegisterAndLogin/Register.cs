using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace SwiggyApi.Models.RegisterAndLogin
{
    public class Register 
    {
        //public int UserId { get; set; }

        [Required, MaxLength(50)]
        public string Username { get; set; }

        [Required,DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [Required,DataType(DataType.Password)]
        public string Password { get; set; }

        [Required, DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }


    }
}
