using System;
using System.Collections.Generic;
using System.Text;
using DataBaseLayer.Models;

namespace BusinessLayer.Models
{
    public class Obito : IObito
    {
        public DateTime DataRegistro { get; set; }
        public DateTime DataObito { get; set; }
        public string Falecido { get; set; }
        public string Pai { get; set; }
        public string Mae { get; set; }
        public int Id { get; set; }
    }
}
