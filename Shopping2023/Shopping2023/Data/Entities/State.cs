﻿using System.ComponentModel.DataAnnotations;

namespace Shopping2023.Data.Entities
{
    public class State
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres.")]
        [Display(Name = "Departamento/Estado")]
        public string Name { get; set; }


        public Country Country { get; set; }

        public ICollection<City> Cities { get; set; }

        [Display(Name="Ciudades")]
        public int CitiesNumber =>  Cities == null ? 0 :  Cities.Count;

    }
}
