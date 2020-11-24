using System;
using System.Collections.Generic;
using System.Text;
using DataBaseLayer.Models;
using System.Reflection;
using DataBaseLayer;

namespace BusinessLayer.Models
{
    public class Operacao : IOperation
    {
        public int Id { get; set; }

        public bool Validar()
        {
            bool check = true;
            foreach (PropertyInfo pi in this.GetType().GetPublicProperties())
            {
                if (pi.Name != "Id")
                {
                    if (pi.GetValue(this).ToString().Trim() == "")
                    {
                        check = false;
                    }
                }
            }

            return check;

        }
    }
}
