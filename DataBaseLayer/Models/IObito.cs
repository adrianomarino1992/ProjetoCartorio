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

        [DataBaseFlags.DBFlags(ColumnName = "fk_id_falecido", ForeignKey = typeof(IPessoa), UseDefaultNames = false, DataBaseValueType = "text")]
        string Falecido { get; set; }

        [DataBaseFlags.DBFlags(ColumnName = "fk_cpf_pai", IsNullable = true, ForeignKey = typeof(IPessoa), UseDefaultNames = false, DataBaseValueType = "text")]
        string Pai { get; set; }

        [DataBaseFlags.DBFlags(ColumnName = "fk_cpf_mae", IsNullable = false, ForeignKey = typeof(IPessoa), UseDefaultNames = false, DataBaseValueType = "text")]
        string Mae { get; set; }
    }
}
