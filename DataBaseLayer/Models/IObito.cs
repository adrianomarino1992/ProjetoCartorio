using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseLayer.Models
{
    [DataBaseFlags.DBFlags(TableName = "tb_obito")]
    public interface IObito : IOperation
    {
        [DataBaseFlags.DBFlags(ColumnName = "dt_registro", UseDefaultNames = false, DataBaseValueType = "date")]
        DateTime DataRegistro { get; set; }

        [DataBaseFlags.DBFlags(ColumnName = "dt_obito", UseDefaultNames = false, DataBaseValueType = "date")]
        DateTime DataObito { get; set; }

        [DataBaseFlags.DBFlags(ColumnName = "fk_id_falecido", ForeignKey = typeof(IPessoa), UseDefaultNames = false, DataBaseValueType = "int")]
        IPessoa Falecido { get; set; }

        [DataBaseFlags.DBFlags(ColumnName = "fk_id_pai", IsNullable = true, ForeignKey = typeof(IPessoa), UseDefaultNames = false, DataBaseValueType = "int")]
        IPessoa Pai { get; set; }

        [DataBaseFlags.DBFlags(ColumnName = "fk_id_mae", IsNullable = false, ForeignKey = typeof(IPessoa), UseDefaultNames = false, DataBaseValueType = "int")]
        IPessoa Mae { get; set; }
    }
}
