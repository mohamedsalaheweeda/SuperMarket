using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.BL
{
    public class RegisterDto
    {
        public RegisterDto(
            string name,
            string username,
            string email,
            string password,
            string phonenumber,
            string role
            )
        {
            Name = name;
            UserName = username;
            Email = email;
            Password = password;
            PhoneNumber = phonenumber;
            Role = role;
        }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(100)]
        public required string UserName { get; set; }
        [StringLength(200)]
        public required string Email { get; set; }
        [StringLength(50)]
        public required string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }


    }
}
