using System;
using System.Collections.Generic;
using System.Text;
using DataBaseLayer.Models;

namespace BusinessLayer.Models
{
    public class Nascimento : Operacao , INascimento
    {
        public DateTime DataRegistro { get; set; }
        public string Nascido { get; set; }
        public string Pai { get; set; }
        public string Mae { get; set; }
        
    }
}
