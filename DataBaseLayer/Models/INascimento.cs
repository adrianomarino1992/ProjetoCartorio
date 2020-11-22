using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseLayer.Models
{
    [DataBaseFlags.DBFlags(TableName = "tb_nascimento")]
    public interface INascimento : IOperation
    {
        
        [DataBaseFlags.DBFlags(ColumnName = "dt_registro", UseDefaultNames = false, DataBaseValueType = "date")]
        DateTime DataRegistro { get; set; }

        [DataBaseFlags.DBFlags(ColumnName = "fk_id_nascido",  ForeignKey = typeof(IPessoa), UseDefaultNames = false, DataBaseValueType = "int")]
        IPessoa Nascido { get; set; }

        [DataBaseFlags.DBFlags(ColumnName = "fk_id_pai",IsNullable = true, ForeignKey = typeof(IPessoa), UseDefaultNames = false, DataBaseValueType = "int")]
        IPessoa Pai { get; set; }

        [DataBaseFlags.DBFlags(ColumnName = "fk_id_mae", IsNullable = false, ForeignKey = typeof(IPessoa), UseDefaultNames = false, DataBaseValueType = "int")]
        IPessoa Mae { get; set; }
    }
}
