using DataBaseLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Data;

namespace DataBaseLayer.ORM
{
    public class DefaultORM : IORM
    {
        private IConnection _connection;

        public bool Error { get; set; } = false;

        public string Message { get; set; }
        public bool Add<T>(T obj)
        {
            throw new NotImplementedException();
        }

        public virtual bool CreateTable<T>()
        {
            try
            {
                DataBaseFlags.DBFlags attr = (DataBaseFlags.DBFlags)
                        typeof(T).GetCustomAttribute(typeof(DataBaseFlags.DBFlags));

                string SQL = "CREATE TABLE IF NOT EXISTS " + attr.TableName + " ( ";

                foreach (PropertyInfo pi in typeof(T).GetPublicProperties())
                {


                    DataBaseFlags.DBFlags piAttr = (DataBaseFlags.DBFlags)pi.GetCustomAttribute(typeof(DataBaseFlags.DBFlags));

                    if (piAttr.Save)
                    {

                        if (piAttr.PrimaryKey)
                        {
                            SQL += $"\r\n{piAttr.ColumnName} {piAttr.DataBaseValueType},\r\nPRIMARY KEY ({piAttr.ColumnName}),\r\n";
                        }
                        else if (piAttr.ForeignKey != null)
                        {

                            DataBaseFlags.DBFlags attrForeign = (DataBaseFlags.DBFlags)
                                 piAttr.ForeignKey.GetCustomAttribute(typeof(DataBaseFlags.DBFlags));

                            foreach (PropertyInfo pf in piAttr.ForeignKey.GetPublicProperties())
                            {

                                DataBaseFlags.DBFlags pfAttr = (DataBaseFlags.DBFlags)pf.GetCustomAttribute(typeof(DataBaseFlags.DBFlags));


                                if (pfAttr.PrimaryKey)
                                {
                                    string IsNull;

                                    if (!piAttr.IsNullable)
                                    {
                                        IsNull = " NOT NULL ";
                                    }
                                    else
                                    {
                                        IsNull = "";
                                    }

                                    SQL += $"\r\n{piAttr.ColumnName} {piAttr.DataBaseValueType}{IsNull},\r\n" +
                                        $"FOREIGN KEY ({piAttr.ColumnName})" +
                                        $"REFERENCES {attrForeign.TableName} ({pfAttr.ColumnName}),\r\n";

                                }
                            }


                        }
                        else
                        {

                            if (!piAttr.IsNullable)
                            {

                                SQL += $"\r\n{piAttr.ColumnName} {piAttr.DataBaseValueType} NOT NULL, \r\n";

                            }
                            else
                            {
                                if (piAttr.Unique)
                                {
                                    SQL += $"\r\n{piAttr.ColumnName} {piAttr.DataBaseValueType} UNIQUE,\r\n";
                                }
                                else
                                {

                                    SQL += $"\r\n{piAttr.ColumnName} {piAttr.DataBaseValueType},\r\n";
                                }

                            }


                        }


                    }

                }

                SQL = SQL.Remove(SQL.LastIndexOf(','));

                SQL += "\r\n );";


                return _connection.ExecuteScript(SQL);

            }
            catch
            {
                return false;
            }



        }

        /// <summary>
        /// Não será implementado neste projeto
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public virtual bool UpdateTable<T>()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Não implemente validações nessa classe, Validações devem ser implementadas na camada de negocios
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public virtual bool Edit<T>(T obj)
        {
            try
            {
                DataBaseFlags.DBFlags attr = (DataBaseFlags.DBFlags)
                        typeof(T).GetCustomAttribute(typeof(DataBaseFlags.DBFlags));

                string updates = "";

                string where = "";
                


                foreach (PropertyInfo pi in typeof(T).GetPublicProperties())
                {


                    DataBaseFlags.DBFlags piAttr = (DataBaseFlags.DBFlags)pi.GetCustomAttribute(typeof(DataBaseFlags.DBFlags));

                    if(piAttr.PrimaryKey)
                    {
                        where = $" WHERE {piAttr.ColumnName} = {pi.GetValue(obj)} ";
                    }
                    else
                    {
                        if (piAttr.Save)
                        {
                            

                            if (new List<string> { "integer", "float" }.Contains(piAttr.DataBaseValueType))
                            {
                                updates += $" {piAttr.ColumnName} = {pi.GetValue(obj)} ,\r\n";

                            }
                            else if (new List<string> { "date", "text" }.Contains(piAttr.DataBaseValueType))
                            {
                                updates += $" {piAttr.ColumnName} = '{pi.GetValue(obj)}' ,\r\n";
                            }
                        }

                    }

                   

                }

                string SQL = $"  UPDATE " + attr.TableName + $" SET {updates}{where};";




                return _connection.ExecuteScript(SQL);

            }
            catch
            {
                return false;
            }

        }


        public virtual bool Remove<T>(T obj)
        {
            try
            {
                DataBaseFlags.DBFlags attr = (DataBaseFlags.DBFlags)
                        typeof(T).GetCustomAttribute(typeof(DataBaseFlags.DBFlags));               

                string where = "";



                foreach (PropertyInfo pi in typeof(T).GetPublicProperties())
                {


                    DataBaseFlags.DBFlags piAttr = (DataBaseFlags.DBFlags)pi.GetCustomAttribute(typeof(DataBaseFlags.DBFlags));

                    if (piAttr.PrimaryKey)
                    {
                        where = $" WHERE {piAttr.ColumnName} = '{pi.GetValue(obj)}' ";
                    }                   



                }

                string SQL = $"  DELETE FROM " + attr.TableName + $" {where} ;";



                return _connection.ExecuteScript(SQL);

            }
            catch
            {
                return false;
            }
        }

        public virtual bool Save<T>(T obj)
        {
            Error = false;
            Message = "Sem erros";
            try
            {
                DataBaseFlags.DBFlags attr = (DataBaseFlags.DBFlags)
                        typeof(T).GetCustomAttribute(typeof(DataBaseFlags.DBFlags));

                string cols = "";
                string values = "";


                foreach (PropertyInfo pi in typeof(T).GetPublicProperties())
                {


                    DataBaseFlags.DBFlags piAttr = (DataBaseFlags.DBFlags)pi.GetCustomAttribute(typeof(DataBaseFlags.DBFlags));

                    if (piAttr.Save)
                    {
                        if(piAttr.DataBaseValueType != "serial")
                            cols += $"{piAttr.ColumnName} ,\r\n";

                        if (new List<string> { "integer", "float" }.Contains(piAttr.DataBaseValueType))
                        {
                            values += $"{pi.GetValue(obj)},\r\n";

                        }
                        else if (new List<string> { "date", "text" }.Contains(piAttr.DataBaseValueType))
                        {
                            values += $"'{pi.GetValue(obj)}',\r\n";
                        }
                    }

                }

                cols = cols.Remove(cols.LastIndexOf(','));
                values = values.Remove(values.LastIndexOf(','));
                string SQL = $"  INSERT INTO " + attr.TableName + $" ({cols})VALUES ({values});";

               

                bool result = _connection.ExecuteScript(SQL);

                if(result)
                {
                    Message = "Salvo com sucesso !";
                }
                else
                {
                    Message = "Não foi possivel salvar !";
                }

                return result;
               
            }
            catch(Exception ex)
            {
                Error = true;
                Message = ex.Message;
                return false;
            }
        }

        public virtual O Search<T,O>(object Id)
        {
            try
            {
                DataBaseFlags.DBFlags attr = (DataBaseFlags.DBFlags)
                        typeof(T).GetCustomAttribute(typeof(DataBaseFlags.DBFlags));

                string where = "";
               


                foreach (PropertyInfo pi in typeof(T).GetPublicProperties())
                {


                    DataBaseFlags.DBFlags piAttr = (DataBaseFlags.DBFlags)pi.GetCustomAttribute(typeof(DataBaseFlags.DBFlags));

                    if (piAttr.PrimaryKey)
                    {                        
                        where = $" WHERE {piAttr.ColumnName} = '{Id}' ";
                    }



                }

                string SQL = $"  SELECT * FROM " + attr.TableName + $" {where} ;";

                DataTable dt;

                object result = _connection.ExecuteQuery(SQL);

                if(result.GetType() == typeof(bool))
                {
                    throw new Exception("Nada foi encontrado");
                }
                else
                {
                    dt = (DataTable)result;

                    DataTableReader reader = new DataTableReader(dt);

                    O objReturns = (O)Activator.CreateInstance(typeof(O));

                    while(reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            foreach (PropertyInfo pi in typeof(T).GetPublicProperties())
                            {
                                try
                                {
                                    DataBaseFlags.DBFlags piAttr = (DataBaseFlags.DBFlags)pi.GetCustomAttribute(typeof(DataBaseFlags.DBFlags));

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
                        }
                    }

                    return objReturns;

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            
        }

        public DefaultORM(IConnection connection)
        {
            _connection = connection;

        }
    }
}
