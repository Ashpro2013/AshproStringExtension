using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
namespace AshproStringExtension
{
    public static class StringExtension
    {
        public static T Cast<T>(this Object obj, T typeHolder)
        {
            return (T)obj;
        }
        public static bool IsArabic(this string input)
        {
            return Regex.IsMatch(input, @"\p{IsArabic}");
        }
        public static bool toBool(this Boolean? obj)
        {
            try
            {
                return Convert.ToBoolean(obj);
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool ToBool(this String obj)
        {
            try
            {
                if (obj != "")
                {
                    return Convert.ToBoolean(obj);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static Int32 ToInt32(this String obj)
        {
            try
            {
                if (obj == null || obj.Trim() == "")
                    return 0;
                else
                    return Convert.ToInt32(obj);
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public static Int16 ToInt16(this String obj)
        {
            try
            {
                if (obj == null || obj.Trim() == "")
                    return 0;
                else
                    return Convert.ToInt16(obj);
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public static Decimal ToDecimal(this String obj)
        {
            try
            {
                Decimal dcm = 0;
                if (Decimal.TryParse(obj, out dcm))
                    return dcm;
                else
                    return 0;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public static Decimal? ToDecimal2(this object obj) {
            try {
                if (obj != null) {
                    return obj.ToString().ToDecimal();
                }
                else {
                    return null;
                }
            }
            catch (Exception) {
                return null;
            }
        }
        public static double ToDouble(this Decimal? obj)
        {
            return Convert.ToDouble(obj);
        }
        public static string getFormattedValue(string Format, decimal _value)
        {
            string _FormattedValue;
            if (Format != null && Format != "" && Format.Length > 1)
            {
                _FormattedValue = _value.ToString(Format);
            }
            else
            {
                _FormattedValue = _value.ToString();
            }
            return _FormattedValue;
        }

        public static string RoundFormatted(this decimal? obj, string Format)
        {
            if (obj == null) { return (0).ToString(Format); }
            return getFormattedValue(Format, obj.ToDecimal());
        }
        public static Double ToDouble(this String obj)
        {
            try
            {
                if (obj == null || obj.Trim() == "")
                    return 0;
                else
                    return Convert.ToDouble(obj);
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public static DateTime toDateTime(this String Obj, IFormatProvider provider = null)
        {
            DateTime dt = DateTime.Now;
            if (provider == null)
            {
                System.Globalization.CultureInfo enCul = new System.Globalization.CultureInfo("en-US");
                provider = enCul;
            }
            try
            {
                try
                {
                    dt = Convert.ToDateTime(Obj,provider);
                }
                catch (Exception)
                {

                    dt = DateTime.ParseExact(Obj, "yyyy-MM-ddTHH:mm:ss", provider);
                }
               
            }
            catch (Exception)
            {
                try
                {
                    if (Obj.Contains("-"))
                    {
                        if (Obj.Length > 10)
                        {
                            int iIndex = Obj.IndexOf("T");
                            Obj = Obj.Remove(iIndex);
                        }
                        string[] sString = Obj.Split('-');
                        toDateTime(sString[2] + "-" + sString[1] + "-" + sString[0] + "T00:00:00", provider);
                    }
                    else if (Obj.Contains("/") && Obj.Length == 10)
                    {
                        string[] sString = Obj.Split('/');
                        string val = sString[2].Trim() + "-" + sString[1].Trim() + "-" + sString[0].Trim() + "T00:00:00";
                        toDateTime(val, provider);
                    }
                    else
                    {
                        dt = Convert.ToDateTime(Obj);
                    }
                }
                catch (Exception)
                {
                    dt = Convert.ToDateTime(Obj);
                }
            }
            return dt;
        }
        public static DateTime ToDateTime(this DateTime? Obj, IFormatProvider provider = null)
        {
            if (provider == null)
            {
                System.Globalization.CultureInfo enCul = new System.Globalization.CultureInfo("en-US");
                provider = enCul;
            }
            string sDate = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
            if (Obj != null)
            {
                sDate = ((DateTime)Obj).ToString("yyyy-MM-ddTHH:mm:ss");
            }
            return sDate.toDateTime();
        }
        public static bool isNumeric(this Object Expression)
        {
            double retNum;
            bool isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }
        /// <summary>
        /// Used To Convert Any Object To String Even Null
        /// </summary>
        /// <param name="_obj"></param>
        /// <returns></returns>
        public static string ToString2(this Object _obj)
        {

            if (_obj != null)
            {
                return _obj.ToString();
            }
            else
            {
                return "";
            }

        }
        public static Int32 ToInt32(this Object _obj)
        {

            if (_obj != null)
            {
                return _obj.ToString().ToInt32();
            }
            else
            {
                return 0;
            }

        }
        public static int toInt32(this int? _obj)
        {
            if (_obj != null)
            {
                return Convert.ToInt32(_obj);
            }
            else
            {
                return 0;
            }

        }
        public static int? ToIntiger(this Object _obj)
        {
            if (_obj != null)
            {
                return _obj.ToString().ToInt32();
            }
            else
            {
                return null;
            }
        }
        public static Decimal ToDecimal(this decimal? obj)
        {
            return Convert.ToDecimal(obj);
        }
        public static Decimal ToDecimal(this double obj)
        {
            return Convert.ToDecimal(obj);
        }
        public static Decimal toDecimal(this object _obj)
        {
            try
            {
                if (_obj != null)
                {
                    return _obj.ToString().ToDecimal();
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public static Decimal Round(this decimal? obj, int NoofDecimals)
        {
            return Math.Round(obj.ToDecimal(), NoofDecimals);
        }
        public static string ToString(this decimal? obj, string sFormat)
        {
            return (obj.ToDecimal()).ToString(sFormat);
        }
        public static string GetDateAndTime(DateTime dateTime)
        {
            try
            {
                return dateTime.ToString("yyyy-MM-ddTHH:mm:ss");
            }
            catch (Exception)
            {
                throw;
            }
        }
        private static bool isValidDataType(string dataType)
        {
            bool isValid = false;
            switch (dataType)
            {
                case "System.Nullable`1[System.Double]":
                    isValid = true;
                    break;
                case "System.Nullable`1[System.Decimal]":
                    isValid = true;
                    break;
                case "System.Nullable`1[System.Int16]":
                    isValid = true;
                    break;
                case "System.Nullable`1[System.Int32]":
                    isValid = true;
                    break;
                case "System.Nullable`1[System.Int64]":
                    isValid = true;
                    break;
                case "System.Nullable`1[System.Boolean]":
                    isValid = true;
                    break;
                case "System.Nullable`1[System.DateTime]":
                    isValid = true;
                    break;
                case "System.Boolean":
                    isValid = true;
                    break;
                case "System.Int16":
                    isValid = true;
                    break;
                case "System.Int32":
                    isValid = true;
                    break;
                case "System.Int64":
                    isValid = true;
                    break;
                case "System.String":
                    isValid = true;
                    break;
                case "System.Decimal":
                    isValid = true;
                    break;
                case "System.Double":
                    isValid = true;
                    break;
            }
            return isValid;
        }

        public static void CopyData(Object source, Object target, bool CopyID = false)
        {
            Type sourceType = source.GetType();
            Type targetType = target.GetType();
            PropertyInfo[] srcProps = sourceType.GetProperties();
            foreach (PropertyInfo srcProp in srcProps)
            {
                PropertyInfo targetProperty = targetType.GetProperty(srcProp.Name);
                if (targetProperty != null)
                {
                    if (srcProp.PropertyType.Name == "DateTime")
                    {
                        targetProperty.SetValue(target, (GetDate((DateTime)(srcProp.GetValue(source, null)))).toDateTime());
                    }
                    else if (srcProp.PropertyType.Name == "Boolean")
                    {
                        targetProperty.SetValue(target, ((srcProp.GetValue(source, null))).ToString().ToBool());
                    }
                    else if (srcProp.PropertyType.Name == "Nullable`1")
                    {
                        if (srcProp.PropertyType.FullName.Contains("System.Boolean"))
                        {
                            try
                            {
                                targetProperty.SetValue(target, ((srcProp.GetValue(source, null))).ToString().ToBool());
                            }
                            catch (Exception)
                            {
                            }
                        }
                    }
                    else if (!isValidDataType(srcProp.PropertyType.ToString()))
                    {
                        continue;
                    }
                    if (srcProp.Name == "id" && CopyID == false)
                    {
                        continue;
                    }
                    if (!srcProp.CanRead)
                    {
                        continue;
                    }

                    if (targetProperty == null)
                    {
                        continue;
                    }
                    if (!targetProperty.CanWrite)
                    {
                        continue;
                    }
                    if (targetProperty.GetSetMethod(true) != null && targetProperty.GetSetMethod(true).IsPrivate)
                    {
                        continue;
                    }
                    if ((targetProperty.GetSetMethod().Attributes & MethodAttributes.Static) != 0)
                    {
                        continue;
                    }
                    if (!targetProperty.PropertyType.IsAssignableFrom(srcProp.PropertyType))
                    {
                        continue;
                    }
                    // Passed all tests, lets set the value
                    try
                    {
                        targetProperty.SetValue(target, srcProp.GetValue(source, null), null);
                    }
                    catch (Exception) { }
                }
            }

        }

        public static T CopyTo<T>(this object source)
        {
            T target = Activator.CreateInstance<T>();
            if (source != null)
                CopyData(source, target);
            return target;
        }
        public static string ToBase64(this string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        public static string FromBase64(this string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
        public static string ToArabic(this string input)
        {
            return input.Replace('0', '\u06f0')
                       .Replace('1', '\u06f1')
                       .Replace('2', '\u06f2')
                       .Replace('3', '\u06f3')
                       .Replace('4', '\u06f4')
                       .Replace('5', '\u06f5')
                       .Replace('6', '\u06f6')
                       .Replace('7', '\u06f7')
                       .Replace('8', '\u06f8')
                       .Replace('9', '\u06f9');
        }
        public static void ToCSV(this DataTable dtDataTable, string strFilePath)
        {
            StreamWriter sw = new StreamWriter(strFilePath, false,System.Text.Encoding.BigEndianUnicode);
            //headers    
            for (int i = 0; i < dtDataTable.Columns.Count; i++)
            {
                sw.Write(dtDataTable.Columns[i]);
                if (i < dtDataTable.Columns.Count - 1)
                {
                    sw.Write(",");
                }
            }
            sw.Write(sw.NewLine);
            foreach (DataRow dr in dtDataTable.Rows)
            {
                for (int i = 0; i < dtDataTable.Columns.Count; i++)
                {
                    if (!Convert.IsDBNull(dr[i]))
                    {
                        string value = dr[i].ToString();
                        if (value.Contains(","))
                        {
                            value = String.Format("\"{0}\"", value);
                            sw.Write(value);
                        }
                        else
                        {
                            sw.Write(dr[i].ToString());
                        }
                    }
                    if (i < dtDataTable.Columns.Count - 1)
                    {
                        sw.Write(",");
                    }
                }
                sw.Write(sw.NewLine);
            }
            sw.Close();
        }
        public static List<string> GetProperties(this object myObject)
        {
            List<string> list = new List<string>();
            Type type = myObject.GetType();
            PropertyInfo[] props = type.GetProperties();
            foreach (var prop in props)
            {
                try
                {
                    if (!list.Contains(prop.Name))
                        list.Add(prop.Name);
                }
                catch
                {
                    continue;
                }
            }
            return list;
        }
        public static string FirstLetterToUpperCase(this string inputString)
        {
            //First we changing the input string to lower
            inputString = inputString.ToLower().Trim();
            if (inputString.Length > 0)
            {
                char[] charArray = inputString.ToCharArray();
                //This make first letter of string to upper
                charArray[0] = char.ToUpper(charArray[0]);
                //Following code make letter coming after space to Upper case Like Ashpro Technologies
                for (int i = 0; i < charArray.Length; i++)
                {
                    if (charArray[i].ToString() == " ")
                    {
                        charArray[i + 1] = char.ToUpper(charArray[i + 1]);
                    }
                }
                return new string(charArray);
            }
            return inputString;
        }
        public static string GetTime(this DateTime dateTime)
        {
            try
            {
                return dateTime.ToString("HH:mm:ss");
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static string GetDate(this DateTime dateTime)
        {
            try
            {
                System.Globalization.CultureInfo enCul = new System.Globalization.CultureInfo("en-US");
                string sVal = dateTime.ToString("dd-MM-yyyy", enCul);
                return sVal;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static System.Data.DataTable ListToDataTable<T>(this List<T> items)
        {
            System.Data.DataTable dataTable = new System.Data.DataTable(typeof(T).Name);
            //Get all the properties by using reflection   
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names  
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    if (Props[i].PropertyType.Name == "Decimal")
                    {
                        values[i] = Props[i].GetValue(item, null).toDecimal().ToString().ToDecimal();
                    }
                    else if (Props[i].PropertyType.Name == "Byte[]")
                    {
                        if (Props[i].GetValue(item, null) != null)
                        {
                            values[i] = (byte[])Props[i].GetValue(item, null);
                        }
                        else
                        {
                            values[i] = null;
                        }
                    }
                    else
                    {
                        values[i] = Props[i].GetValue(item, null);
                    }
                }
                dataTable.Rows.Add(values);
            }
            return dataTable;
        }
        public static System.Data.DataTable ToDataTable<T>(this T item)
        {
            System.Data.DataTable dataTable = new System.Data.DataTable(typeof(T).Name);
            //Get all the properties by using reflection   
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names  
                dataTable.Columns.Add(prop.Name);
            }
            var values = new object[Props.Length];
            for (int i = 0; i < Props.Length; i++)
            {
                if (Props[i].PropertyType.Name == "Decimal")
                {
                    values[i] = Props[i].GetValue(item, null).toDecimal().ToString();
                }
                else
                {
                    values[i] = Props[i].GetValue(item, null);
                }
            }
            dataTable.Rows.Add(values);
            return dataTable;
        }
        public static List<T> DataTableToList<T>(this System.Data.DataTable data)
        {
            List<T> list = new List<T>();
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();
            foreach (DataRow row in data.Rows)
            {
                obj = GetTItem<T>(row);
                list.Add(obj);
            }
            return list;
        }
        public static T GetTItem<T>(this DataRow dr)
        {
            try
            {
                Type temp = typeof(T);
                T obj = Activator.CreateInstance<T>();
                foreach (DataColumn column in dr.Table.Columns)
                {
                    foreach (PropertyInfo pro in temp.GetProperties())
                    {
                        if (pro.Name == column.ColumnName)

                            if (dr[column.ColumnName] != DBNull.Value)
                            {
                                if (pro.PropertyType.Name == "Boolean")
                                {
                                    if (dr[column.ColumnName].ToString() != string.Empty)
                                        pro.SetValue(obj, dr[column.ColumnName].ToString().ToBool(), null);
                                }
                                else if (pro.PropertyType.Name == "Int32")
                                {
                                    if (dr[column.ColumnName].ToString() != string.Empty)
                                    {
                                        pro.SetValue(obj, dr[column.ColumnName].ToInt32(), null);
                                    }
                                }
                                else if (pro.PropertyType.Name == "Decimal")
                                {
                                    if (dr[column.ColumnName].ToString() != string.Empty)
                                        pro.SetValue(obj, dr[column.ColumnName].toDecimal(), null);
                                }
                                else if (pro.PropertyType.Name == "Nullable`1")
                                {
                                    if (pro.PropertyType.FullName.Contains("System.Int32"))
                                    {
                                        if (dr[column.ColumnName].ToString() != string.Empty)
                                        {
                                            pro.SetValue(obj, dr[column.ColumnName].ToInt32(), null);
                                        }
                                    }
                                    else if (pro.PropertyType.FullName.Contains("System.Boolean"))
                                    {
                                        if (dr[column.ColumnName].ToString() != string.Empty)
                                        {
                                            pro.SetValue(obj, dr[column.ColumnName].ToString().ToBool(), null);
                                        }
                                    }
                                    else if (pro.PropertyType.FullName.Contains("System.DateTime"))
                                    {
                                        if (dr[column.ColumnName].ToString() != string.Empty)
                                        {
                                            pro.SetValue(obj, Convert.ToDateTime(dr[column.ColumnName].ToString()), null);
                                        }
                                    }
                                    else if (pro.PropertyType.FullName.Contains("System.Decimal"))
                                    {
                                        if (dr[column.ColumnName].ToString() != string.Empty)
                                        {
                                            pro.SetValue(obj, dr[column.ColumnName].toDecimal(), null);
                                        }
                                    }
                                }
                                else if (pro.PropertyType.Name == "DateTime")
                                {
                                    if (dr[column.ColumnName].ToString() != string.Empty)
                                        pro.SetValue(obj, Convert.ToDateTime(dr[column.ColumnName].ToString()), null);
                                }
                                else
                                {
                                    pro.SetValue(obj, dr[column.ColumnName].ToString(), null);
                                }
                            }
                            else
                            {
                                pro.SetValue(obj, null, null);
                            }
                        else
                            continue;
                    }
                }
                return obj;

            }
            catch (Exception ex)
            {
                string s = ex.Message;
                throw;
            }
        }
        public static void DataTabletoFile(this System.Data.DataTable datatable, string file)
        {
            StreamWriter str = new StreamWriter(file, true, System.Text.Encoding.Unicode);
            string Columns = string.Empty;
            foreach (DataColumn column in datatable.Columns)
            {
                Columns += column.ColumnName;
            }
            str.WriteLine(Columns.Remove(Columns.Length - 1, 1));
            foreach (DataRow datarow in datatable.Rows)
            {
                string row = string.Empty;
                foreach (object items in datarow.ItemArray)
                {
                    row += items.ToString();
                }
                str.WriteLine(row.Remove(row.Length - 1, 1), 0);
            }
            str.Close();
        }
    }
}
