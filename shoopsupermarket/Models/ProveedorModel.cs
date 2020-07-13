using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace shoopsupermarket.Models
{
    public class Proveedor
    {
        //private static Regex _regex = new Regex(@"^(\+\s?)?((?<!\+.*)\(\+?\d+([\s\-\.]?\d+)?\)|\d+)([\s\-\.]?(\(\d+([\s\-\.]?\d+)?\)|\d+))*(\s?(x|ext\.?)\s?\d+)?$", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture);

        [Key]
        public int PROV_ID { get; set; }


        [MaxLength(50, ErrorMessage = "¡No más de 50 caracteres!")]
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "¡Este campo es requerido")]
        public string NAME { get; set; }


        [Required(ErrorMessage = "¡Se requiere al menos un número de teléfono!")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "¡Número de teléfono no valido!")]
        public string PHONE1 { get; set; }


        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "¡Número de teléfono no valido!")]
        public string PHONE2 { get; set; }
    }
}