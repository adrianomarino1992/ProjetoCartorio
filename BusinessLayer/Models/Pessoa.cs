using System;
using System.Collections.Generic;
using System.Text;
using DataBaseLayer.Models;

namespace BusinessLayer.Models
{
    public class Pessoa : IPessoa
    {
        public DateTime DataNascimento { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string NomePai { get; set; }
        public string NomeMae { get; set; }
        public DateTime DataPai { get; set; }
        public DateTime DataMae { get; set; }
        public string CPFPai { get; set; }
        public string CPFMae { get; set; }
        public int Id { get; set ; }
    }
}
