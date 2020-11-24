using System;
using System.Collections.Generic;
using System.Text;
using DataBaseLayer.ORM;
using DataBaseLayer;
using System.Data;
using System.Reflection;
using Flags = DataBaseLayer.DataBaseFlags;

namespace BusinessLayer
{
   public class ORMBusiness : DefaultORM
    {
        public ORMBusiness(IConnection connection) : base(connection)
        {

        }

        public List<T> SearchAll<T,O>(string query)
        {
            Error = false;
            Message = "Sem Erros";

            object result = _connection.ExecuteQuery(query);

            if (result.GetType() == typeof(bool))
            {
                Error = false;
                Message = "Nada foi encontrado";
                throw new Exception("Nada foi encontrado");

            }
            else
            {
               DataTable dt = (DataTable)result;

                DataTableReader reader = new DataTableReader(dt);

                T objReturns = (T)Activator.CreateInstance(typeof(T));

                List<T> listObjResult = (List<T>)Activator.CreateInstance(typeof(List<T>));

                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        foreach (PropertyInfo pi in typeof(O).GetPublicProperties())
                        {
                            try
                            {
                                Flags.DBFlags piAttr = (Flags.DBFlags)pi.GetCustomAttribute(typeof(Flags.DBFlags));

                                if (pi.PropertyType == typeof(int))
                                    pi.SetValue(objReturns, Convert.ToInt32(reader[piAttr.ColumnName]));
                                if (pi.PropertyType == typeof(double))
                                    pi.SetValue(objReturns, Convert.ToDouble(reader[piAttr.ColumnName]));
                                if (pi.PropertyType == typeof(string))
                                    pi.SetValue(objReturns, Convert.ToString(reader[piAttr.ColumnName]));
                                if (pi.PropertyType == typeof(DateTime))
                                    pi.SetValue(objReturns, Convert.ToDateTime(reader[piAttr.ColumnName]));
                            }
                            catch
                            {

                            }

                        }

                        listObjResult.Add(objReturns);
                    }
                }
                Error = false;
                Message = "Sucesso";
                return listObjResult;

            }

        }

    }
}
