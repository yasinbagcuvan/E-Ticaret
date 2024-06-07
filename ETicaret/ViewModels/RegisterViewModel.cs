using Common;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace WepAPI.Models
{

        public class RegisterViewModel
        {
            public string Name { get; set; }
            public string Surname { get; set; }

            [DataType(DataType.Date)]
            public DateOnly BirthDate { get; set; } = new DateOnly(1980, 1, 1);
            public Gender Gender { get; set; }
            public string UserName { get; set; }

            [DataType(DataType.EmailAddress)]
            public string Email { get; set; }

            [DataType(DataType.Password)]
            public string Password { get; set; }
        }
    
}
