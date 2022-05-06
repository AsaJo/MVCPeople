using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPeople.Models.ViewModels
{
    public class CreatePersonViewModel
    {
        [Required]
        [StringLength(32, ErrorMessage = "The name is too long", MinimumLength = 1)]
        public string Name { get; set; }

        [Required]
        [StringLength(32, ErrorMessage = "The city name is too long", MinimumLength = 1)]
        public string City { get; set; }
        public string PhoneNumber { get; set; }
    }
}
