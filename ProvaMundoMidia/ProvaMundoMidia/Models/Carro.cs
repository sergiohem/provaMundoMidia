using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProvaMundoMidia.Models
{
    public class Carro
    {
        public int IdCarro { get; set; }

        public string Descricao { get; set; }

        public string Modelo { get; set; }

        public int Ano { get; set; }
    }
}