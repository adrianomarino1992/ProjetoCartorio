using DataBaseLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models
{
    public class Casamento : ICasamento
    {
        public string ProtocoloCasamento { get; set; }
        public DateTime DataRegistro { get; set; }
        public DateTime DataCasamento { get; set; }
        public string Conjuge1 { get; set; }
        public string Conjuge2 { get; set; }
        public int Id { get; set; }
    }
}
