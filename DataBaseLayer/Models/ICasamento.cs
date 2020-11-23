using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseLayer.Models
{
    [DataBaseFlags.DBFlags(TableName = "tb_casamento")]
    public interface ICasamento : IOperation
    {
        [DataBaseFlags.DBFlags(PrimaryKey = true , ColumnName = "pk_protocolo", ForeignKey = typeof(IPessoa), UseDefaultNames = false, DataBaseValueType = "text")]
        string ProtocoloCasamento { get; set; }

        [DataBaseFlags.DBFlags(ColumnName = "dt_registro", UseDefaultNames = false, DataBaseValueType = "date")]
        DateTime DataRegistro { get; set; }

        [DataBaseFlags.DBFlags(ColumnName = "dt_casamento", UseDefaultNames = false, DataBaseValueType = "date")]
        DateTime DataCasamento { get; set; }

        [DataBaseFlags.DBFlags(ColumnName = "fk_cpf_conj1", ForeignKey = typeof(IPessoa), UseDefaultNames = false, DataBaseValueType = "text")]
        string Conjuge1 { get; set; }

        [DataBaseFlags.DBFlags(ColumnName = "fk_cpf_conj2", ForeignKey = typeof(IPessoa), UseDefaultNames = false, DataBaseValueType = "text")]
        string Conjuge2 { get; set; }


    }
}
