﻿using System.ComponentModel.DataAnnotations;

namespace Shopping2023.Data.Entities
{
    public class Category
    {


        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres.")]
        [Display(Name = "Categoria")]
        public string Name { get; set; }
    }
}
