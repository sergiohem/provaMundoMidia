using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProvaMundoMidia.Models
{
    public enum TipoNotificacao
    {
        Estatico,
        SumirSozinha
    };

    public enum TemaNotificacao
    {
        Sucesso,
        Erro,
        Informacao
    }

    public class Notificacao
    {
        public string Mensagem { get; set; }
        public TemaNotificacao Tema { get; set; }
        public TipoNotificacao Tipo { get; set; }
    }
}