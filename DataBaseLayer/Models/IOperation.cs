using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseLayer.Models
{
    /// <summary>
    /// Interface mais primitiva que extiste
    /// </summary>
    public interface IOperation
    {
      
        [DataBaseFlags.DBFlags(Private = true,IsNullable = false, Save = true, ColumnName = "id" , DataBaseValueType = "serial")]
         int Id { get; set; }

        
    }
}
