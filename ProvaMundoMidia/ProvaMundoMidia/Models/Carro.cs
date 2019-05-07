using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProvaMundoMidia.Models
{
    public class Carro
    {
        public int IdCarro { get; set; }

        [Required(ErrorMessage = "Descrição é um campo obrigatório.")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Modelo é um campo obrigatório.")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "Ano é um campo obrigatório.")]
        public int Ano { get; set; }
    }
}