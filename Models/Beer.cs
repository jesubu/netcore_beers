using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apibeers.Models
{
    public class Beer:IValidatableObject

    {
        [Required]
        //[Range(typeof(decimal), "0", "79228162514264337593543950335",ErrorMessage = "Introduzca un valor mayor que {1}")]
        //[Range(1, int.MaxValue, ErrorMessage = "Introduzca un valor mayor que {1}")]
        public int Id { get; set; }
        public string Name { get; set; }
        [Range(0.0,99.0)]
        public double Abv { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var list = new List<ValidationResult>();
            if (Name.Contains("Free") && Abv > 0.0)
            {
                var result = new ValidationResult("Abv debe ser 0.0", new[] { "Abv" });
                list.Add(result);
            }
            return list;
        }
    }
}
