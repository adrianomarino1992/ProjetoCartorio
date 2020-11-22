using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseLayer.Models
{
    [DataBaseFlags.DBFlags(TableName = "tb_pessoa")]
    public interface IPessoa : IOperation
    {
        [DataBaseFlags.DBFlags(ColumnName = "dt_nascimento", UseDefaultNames = false, DataBaseValueType = "date")]
        DateTime DataNascimento { get; set; }       

        [DataBaseFlags.DBFlags(ColumnName = "txt_nome", UseDefaultNames = false, IsNullable = true, DataBaseValueType = "text")]
        string Nome { get; set; }

        [DataBaseFlags.DBFlags(ColumnName = "txt_cpf", Unique = true ,UseDefaultNames = false, IsNullable = true, DataBaseValueType = "text")]
        string CPF { get; set; }

        [DataBaseFlags.DBFlags(ColumnName = "txt_pai", UseDefaultNames = false, IsNullable = true, DataBaseValueType = "text")]
        string NomePai { get; set; }

        [DataBaseFlags.DBFlags(ColumnName = "txt_mae", UseDefaultNames = false, IsNullable = true, DataBaseValueType = "text")]
        string NomeMae { get; set; }

        [DataBaseFlags.DBFlags(ColumnName = "dt_nascimento_pai", UseDefaultNames = false, DataBaseValueType = "date")]
        DateTime DataPai { get; set; }

        [DataBaseFlags.DBFlags(ColumnName = "dt_nascimento_mae", UseDefaultNames = false, DataBaseValueType = "date")]
        DateTime DataMae { get; set; }

        [DataBaseFlags.DBFlags(ColumnName = "txt_cpf_pai", UseDefaultNames = false, IsNullable = true, DataBaseValueType = "text")]
        string CPFPai { get; set; }


        [DataBaseFlags.DBFlags(ColumnName = "txt_cpf_mae", UseDefaultNames = false, IsNullable = true, DataBaseValueType = "text")]
        string CPFMae { get; set; }
    }
}
