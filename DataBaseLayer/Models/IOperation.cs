using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseLayer.Models
{
    /// <summary>
    /// Tipo mais primitivo do ORM
    /// Qualquer classe que implementa a interface IOperation pode utilizar o ORM
    /// </summary>
    public interface IOperation
    {

        [DataBaseFlags.DBFlags(Private = true, IsNullable = false, Save = true, ColumnName = "id", DataBaseValueType = "serial")]
        int Id { get; set; }

        bool Validar();

    }
}
