using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseLayer.Models
{
    [DataBaseFlags.DBFlags(TableName = "tb_casamento")]
    public interface ICasamento : IOperation
    {
        [DataBaseFlags.DBFlags(ColumnName = "dt_registro", UseDefaultNames = false, DataBaseValueType = "date")]
        DateTime DataRegistro { get; set; }

        [DataBaseFlags.DBFlags(ColumnName = "dt_casamento", UseDefaultNames = false, DataBaseValueType = "date")]
        DateTime DataObito { get; set; }

        [DataBaseFlags.DBFlags(ColumnName = "fk_id_conj1", ForeignKey = typeof(IPessoa), UseDefaultNames = false, DataBaseValueType = "int")]
        IPessoa Conjuge1 { get; set; }

        [DataBaseFlags.DBFlags(ColumnName = "fk_id_conj2", ForeignKey = typeof(IPessoa), UseDefaultNames = false, DataBaseValueType = "int")]
        IPessoa Conjuge2 { get; set; }


    }
}
