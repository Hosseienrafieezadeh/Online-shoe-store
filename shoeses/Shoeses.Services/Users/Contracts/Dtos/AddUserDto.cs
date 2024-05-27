using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shoeses.Services.Addresses.Contracts.Dtos;

namespace Shoeses.Services.Users.Contracts.Dtos
{
   public class AddUserDto
    {
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public List<AddAdressDto> Addresses { get; set; }
    }
}
