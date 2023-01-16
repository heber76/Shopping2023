using System.ComponentModel.DataAnnotations;

namespace Shopping2023.Models
{
    public class StateVievModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres.")]
        [Display(Name = "Departamento/Estado")]
        public string Name { get; set; }
        public int CountryId { get; set; }


    }
}
