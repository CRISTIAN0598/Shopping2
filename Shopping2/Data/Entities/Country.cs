using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Shopping2.Data.Entities
{
    public class Country
    {
        public int Id { get; set; }

        [Display(Name = "Pais")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; }

        public ICollection<State> States { get; set; }

        [Display(Name = "Departamentos/Estados")]
        public int StatesNumber => States== null? 0 : States.Count;
    }
}
