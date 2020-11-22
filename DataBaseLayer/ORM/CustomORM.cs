using DataBaseLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;


namespace DataBaseLayer.ORM
{
    public class CustomORM : ICustomORM
    {
        private IConnection _connection;


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

        public virtual bool UpdateTable<T>()
        {
            throw new NotImplementedException();
        }

        public virtual bool Edit<T>(T obj)
        {
            try
            {
                DataBaseFlags.DBFlags attr = (DataBaseFlags.DBFlags)
                        typeof(T).GetCustomAttribute(typeof(DataBaseFlags.DBFlags));
                string Cols = "";
                string Values = "";
                

                foreach (PropertyInfo pi in typeof(T).GetPublicProperties())
                {


                    DataBaseFlags.DBFlags piAttr = (DataBaseFlags.DBFlags)pi.GetCustomAttribute(typeof(DataBaseFlags.DBFlags));

                    if (piAttr.Save)
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

                string SQL = $"  INSERT INTO " + attr.TableName + $" ({Cols})VALUES (${Values});";

               


                return _connection.ExecuteScript(SQL);

            }
            catch
            {
                return false;
            }

        }

        public virtual bool Remove<T>(object Id)
        {
            throw new NotImplementedException();
        }

        public virtual bool Save<T>(T obj)
        {
            throw new NotImplementedException();
        }

        public virtual T Search<T>(object Id)
        {
            throw new NotImplementedException();
        }

        public CustomORM(IConnection connection)
        {
            _connection = connection;

        }
    }
}
