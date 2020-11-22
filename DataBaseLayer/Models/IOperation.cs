using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseLayer.Models
{
    public interface IOperation
    {
        /// <summary>
        /// chave primaria ARTIFICIAL, pois a natural(CPF) podera se repetir em algumas tabelas
        /// nestas tabelas , o CPF será marcado com o UNIQUE , assim impedindo que o CPF se repita
        /// </summary>
        [DataBaseFlags.DBFlags(PrimaryKey = true, IsNullable = false, Save = true, ColumnName = "id" , DataBaseValueType = "serial")]
         int Id { get; set; }

        
    }
}
