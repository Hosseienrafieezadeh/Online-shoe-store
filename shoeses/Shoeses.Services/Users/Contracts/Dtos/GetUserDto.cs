using Shoeses.Services.Addresses.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoeses.Services.Users.Contracts.Dtos
{
  public class GetUserDto
    {
        public string Id { get; set; }
        public string? FirstName { get; set; }
        
        public string? LastName { get; set; }
        
        public string? Email { get; set; }
        public GetAdressDto Adress { get; set; }
    }
}
