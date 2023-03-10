using System.ComponentModel.DataAnnotations;

namespace Shopping2023.Data.Entities
{
    public class Country
    {
        public int Id { get; set; }


        [Required(ErrorMessage ="El campo {0} es obligatorio.")]
        [MaxLength(50,ErrorMessage ="El campo {0} debe tener maximo {1} caracteres.")]
        [Display(Name="País")]
        public string Name { get; set; }

        public ICollection<State> States { get; set; }

        [Display(Name="Departamentos/Estados")]
        public int StatesNumber =>  States== null ? 0 : States.Count;
    }
}
