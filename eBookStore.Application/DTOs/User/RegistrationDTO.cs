using System.ComponentModel.DataAnnotations;

namespace eBookStore.DTOs.Authentication;

public class RegistrationDTO
{
    [Required]
    public string FirstName { get; set; }
    
    [Required]
    public string LastName { get; set; }
    
    [Required]
    public string UserName { get; set; }


    [DataType(DataType.EmailAddress)]
    [Required]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}

