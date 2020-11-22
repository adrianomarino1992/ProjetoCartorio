using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace DataBaseLayer
{
   
        public static class Validacoes
        {
           
            public static void ValidaPropriedades<T>(T obj)
            {
                foreach (PropertyInfo pi in typeof(T).GetProperties())
                {
                    try
                    {
                        if (pi.PropertyType == typeof(string))
                        {
                            if (pi.GetValue(obj) == null)
                            {
                                pi.SetValue(obj, "");
                            }
                        }

                        if (pi.PropertyType == typeof(int) || pi.PropertyType == typeof(double) || pi.PropertyType == typeof(float))
                        {
                            if (pi.GetValue(obj) == null)
                            {
                                pi.SetValue(obj, 0);
                            }
                        }
                    }
                    catch { }
                }
            }

            public static int BoolToInt(bool entrada)
            {
                if (entrada)
                    return 1;
                else
                    return 0;
            }

            public static bool IntToBool(int entrada)
            {
                if (entrada == 1)
                    return true;
                else
                    return false;
            }
            public static bool Validar<T>(T field)
            {
                if (field.GetType() == typeof(string))
                {
                    if (field.ToString().Trim() == String.Empty)
                    {
                        return false;
                    }
                }

                return true;
            }

            
            public static string Entrada<T>(T entrada)
            {
                string retorno;

                if (typeof(T) == typeof(int) || typeof(T) == typeof(double))
                {
                    try
                    {
                        retorno = entrada.ToString();
                    }
                    catch
                    {
                        retorno = "0";
                    }
                }
                else
                {
                    try
                    {
                        if (entrada != null)
                            retorno = entrada.ToString();
                        else
                            retorno = "";

                    }
                    catch
                    {
                        retorno = "";
                    }
                }

                return retorno;
            }


          
            public static object Saida<T>(object saida)
            {
                object retorno;

                if (typeof(T) == typeof(int))
                {
                    try
                    {
                        retorno = Convert.ToInt64(saida.ToString());
                    }
                    catch
                    {
                        retorno = 0;
                    }
                }
                else if (typeof(T) == typeof(double))
                {
                    try
                    {
                        retorno = Convert.ToDouble(saida.ToString());
                    }
                    catch
                    {
                        retorno = 0;
                    }
                }
                else
                {
                    try
                    {
                        retorno = saida.ToString();
                    }
                    catch
                    {
                        retorno = "";
                    }
                }

                return retorno;
            }

            public static void Integer_Validation(object sender, KeyPressEventArgs e)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                    (e.KeyChar != '.'))
                {
                    e.Handled = true;
                }

                if ((e.KeyChar == '.'))
                {
                    e.Handled = true;
                }
            }

            public static void Double_Validation(object sender, KeyPressEventArgs e)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                    (e.KeyChar != ','))
                {
                    e.Handled = true;
                }

                if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
                {
                    e.Handled = true;
                }
            }


            public static void Product_filter(object sender, KeyPressEventArgs e)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                    (e.KeyChar != '>') && (e.KeyChar != '<') && (e.KeyChar != '=') && (e.KeyChar != ','))
                {
                    e.Handled = true;
                }
                if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
                {
                    e.Handled = true;
                }

                if ((e.KeyChar == '>') && ((sender as TextBox).Text.IndexOf('>') > -1) && ((sender as TextBox).Text.Length > 0))
                {
                    e.Handled = true;
                }

                if ((e.KeyChar == '<') && ((sender as TextBox).Text.IndexOf('<') > -1) && ((sender as TextBox).Text.Length > 0))
                {
                    e.Handled = true;
                }

                if ((e.KeyChar == '=') && ((sender as TextBox).Text.IndexOf('=') > -1) && ((sender as TextBox).Text.Length > 0))
                {
                    e.Handled = true;
                }
            }

            public static string DataToString(DateTime data)
            {
                try
                {
                    return $"{data.Year}-{data.Month}-{data.Day}";
                }
                catch (Exception)
                {
                    return "2020-1-1";
                }
            }




        }
    }
