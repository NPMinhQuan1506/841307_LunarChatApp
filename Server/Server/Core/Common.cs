using DevExpress.XtraEditors;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server.Core
{
    class Common
    {
        
        public static string ymdhms_To_dmyhms(string time)
        {
            try
            {
                var date = DateTimeDMY_To_YMDHHMM(time);
                return DateTimeTo_dmyHms(date);
            }
            catch
            {
                return "";
            }
        }
        public static string BigIntToDateTime_dmyhms(string time)
        {
            time = time.ToString();
            if (time == "" || time == "0") return "";
            string result = "";
            var year = time.Substring(0, 4);
            var month = time.Substring(4, 6);
            var day = time.Substring(6, 8);
            var hour = time.Substring(8, 10);
            var minute = time.Substring(10, 12);
            var second = time.Substring(12, 14);
            result = $"{day}-{month}-{year} {hour}:{minute}:{second}";
            return result;
        }

        public static string BigIntToLive(string time)
        {
            try
            {
                time = time.ToString();
                if (time == "" || time == "0") return "";
                string result = "";
                var year = time.Substring(0, 4);
                var month = time.Substring(4, 6);
                var day = time.Substring(6, 8);
                var hour = time.Substring(8, 10);
                var minute = time.Substring(10, 12);
                var second = time.Substring(12, 14);
                var date = new DateTime(Convert.ToInt16(year), Convert.ToInt16(month), Convert.ToInt16(day), Convert.ToInt16(hour), Convert.ToInt16(minute), Convert.ToInt16(second));
                var dateNow = DateTime.Now;
                var seconds = DurationBetween2TimeSec(date, dateNow);
                var interval = seconds / 604800;
                if (dateNow.Year > date.Year)
                {
                    result = $"{day}-{month}-{year}";
                    return result;
                }
                else if (interval >= 1)
                {
                    result = $"{day}-{month}";
                    return result;
                }
                else if (seconds / 86400 >= 1)
                {
                    result = Math.Floor(seconds / 86400) + " days";
                    return result;
                }
                if (seconds / 3600 >= 1)
                {
                    result = Math.Floor(seconds / 3600) + " hours";
                    return result;
                }
                else if (seconds / 60 >= 1)
                {
                    result = Math.Floor(seconds / 60) + " mins";
                    return result;
                }
                else
                {
                    result = " few sec";
                    return result;
                }
            }
            catch
            {
                return "times ago";
            }
        }
        public static DateTime DateTimeDMY_To_YMD(string date)
        {
            try
            {

                date = date.Trim();
                string[] A = date.Split(' ');
                string[] B = A[0].Split('-');
                return new DateTime(Convert.ToInt32(B[2]), Convert.ToInt32(B[1]), Convert.ToInt32(B[0]), 0, 0, 0);
            }
            catch (Exception ex)
            {
                return new DateTime(1900, 01, 01);
            }


        }
        public static DateTime DateTimeDMY_To_YMD_FirstDay(string date)
        {
            try
            {

                date = date.Trim();
                string[] A = date.Split(' ');
                string[] B = A[0].Split('-');
                return new DateTime(Convert.ToInt32(B[2]), Convert.ToInt32(B[1]), 1, 0, 0, 0);
            }
            catch (Exception ex)
            {
                return new DateTime(1900, 01, 01);
            }


        }
        public static String DateTimeYMD_To_DMY(DateTime date)
        {
            try
            {
                string DMY = date.ToString("dd-MM-yyyy");

                return DMY;
            }
            catch (Exception ex)
            {
                return "01-01-1990";
            }
        }
        public static int DateTimeDMY_To_Month(string date)
        {
            try
            {

                date = date.Trim();
                string[] A = date.Split(' ');
                string[] B = A[0].Split('-');
                return Convert.ToInt32(B[1]);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public static DateTime DateTimeMY_To_YM(string date)
        {
            try
            {

                date = date.Trim();
                string[] A = date.Split(' ');
                string[] B = A[0].Split('-');
                return new DateTime(Convert.ToInt32(B[1]), Convert.ToInt32(B[0]), 01, 0, 0, 0);
            }
            catch (Exception ex)
            {
                return new DateTime(1900, 01, 01);
            }


        }
        public static DateTime DateTimeDMY_To_YMDHHMM(string date)
        {
            try
            {
                date = date.Trim();
                string[] A = date.Split(' ');
                string[] C = A[1].Split(':');
                string[] B = A[0].Split('-');
                return new DateTime(Convert.ToInt32(B[2]), Convert.ToInt32(B[1]), Convert.ToInt32(B[0]), Convert.ToInt32(C[0]), Convert.ToInt32(C[1])
                    , (C.Length > 2) ? Convert.ToInt32(C[2]) : 0
                    );
            }
            catch (Exception ex)
            {
                return DateTime.MinValue;
            }


        }
        public static DateTime DateTimeDMY_To_YMDHHMMSS(string date)
        {
            try
            {
                date = date.Trim();
                string[] A = date.Split(' ');
                string[] C = A[1].Split(':');
                string[] B = A[0].Split('-');
                return new DateTime(Convert.ToInt32(B[2]), Convert.ToInt32(B[1]), Convert.ToInt32(B[0]), Convert.ToInt32(C[0]), Convert.ToInt32(C[1]), Convert.ToInt32(C[2]));
            }
            catch (Exception ex)
            {
                return DateTime.MinValue;
            }


        }
        public static DateTime StringDMY_To_DateTime(string date)
        {
            try
            {
                date = date.Trim();
                string[] A = date.Split('-');
                return new DateTime(Convert.ToInt32(A[2]), Convert.ToInt32(A[1]), Convert.ToInt32(A[0]), 0, 0, 0);
            }
            catch (Exception ex)
            {
                return DateTime.MinValue;
            }
        }
        public static DateTime StringYMDHM_To_DateTime(string date)
        {
            try
            {
                date = date.Trim();
                string[] A = date.Split(' ');
                string[] B = A[0].Split('-');
                if (A.Length == 2)
                {
                    string[] C = A[1].Split(':');
                    return new DateTime(Convert.ToInt32(B[2]), Convert.ToInt32(B[1]), Convert.ToInt32(B[0]), Convert.ToInt32(C[0]), Convert.ToInt32(C[1]), Convert.ToInt32(C[2]));
                }
                else
                {
                    return new DateTime(Convert.ToInt32(B[2]), Convert.ToInt32(B[1]), Convert.ToInt32(B[0]), 0, 0, 0);
                }
            }
            catch (Exception ex)
            {
                return DateTime.MinValue;
            }
        }

        public static string DateTimeTo_dmyHms(DateTime dt)
        {
            try
            {
                return Convert.ToDateTime(dt).ToString("dd-MM-yyyy HH:mm:ss");
            }
            catch (Exception ex)
            {
                return "01-01-1900 00:00:00";
            }
        }

        public static string DateTimeNowToBigInt()
        {
            try
            {
                return DateTime.UtcNow.ToString("yyyyMMddHHmmssfff");
            }
            catch (Exception ex)
            {
                return "19000101000000000";
            }

        }
        public static string DateTimeTo_ymdhms(DateTime dt)
        {
            try
            {
                return Convert.ToDateTime(dt).ToString("yyyy-MM-dd HH:mm:ss");
            }
            catch (Exception ex)
            {
                return "1900-01-01 00:00:00";
            }

        }

        //public DateTime StringToDateTime(string s)
        //{
        //    if (s == null || s == "") return DateTime.MinValue;
        //    return Convert.ToDateTime(s);
        //}
        public static double DurationBetween2TimeSec(DateTime dtFrom, DateTime dtTo)
        {
            if (dtTo == null || dtFrom == null || dtFrom == DateTime.MinValue || dtTo == DateTime.MinValue) return 0;
            DateTime dt1 = new DateTime(dtFrom.Year, dtFrom.Month, dtFrom.Day, dtFrom.Hour, dtFrom.Minute, 0);
            DateTime dt2 = new DateTime(dtTo.Year, dtTo.Month, dtTo.Day, dtTo.Hour, dtTo.Minute, 0);
            TimeSpan Time = dt2 - dt1;
            return Time.TotalSeconds;
        }
        public static double DurationBetween2TimeDe(DateTime dtFrom, DateTime dtTo)
        {
            if (dtTo == null || dtFrom == null || dtFrom == DateTime.MinValue || dtTo == DateTime.MinValue) return 0;
            DateTime dt1 = new DateTime(dtFrom.Year, dtFrom.Month, dtFrom.Day, dtFrom.Hour, dtFrom.Minute, 0);
            DateTime dt2 = new DateTime(dtTo.Year, dtTo.Month, dtTo.Day, dtTo.Hour, dtTo.Minute, 0);
            TimeSpan Time = dt2 - dt1;
            return Time.TotalMinutes;
        }

        public static int DurationBetween2Date(DateTime dtFrom, DateTime dtTo)
        {
            return (int)(dtTo - dtFrom).TotalDays;
        }

        public string removeUnicode(string strInput)
        {
            string stFormD = strInput.Normalize(System.Text.NormalizationForm.FormD);
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            string str = "";
            for (int i = 0; i <= stFormD.Length - 1; i++)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(stFormD[i]);
                if (uc == UnicodeCategory.NonSpacingMark == false)
                {
                    if (stFormD[i] == 'đ')
                        str = "d";
                    else if (stFormD[i] == 'Đ')
                        str = "D";
                    else
                        str = stFormD[i].ToString();
                    sb.Append(str);
                }
            }
            return sb.ToString();
        }

        public bool checkNumber(string strInput)
        {
            foreach (Char c in strInput)
            {
                if (!Char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }

        public byte[] imgToByteConverter(PictureBox pePic)
        {
            MemoryStream stream = new MemoryStream();
            //through the instruction below, we save the
            //image to byte in the object "stream".
            pePic.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);

            //Below is the most important part, actually you are
            //transferring the bytes of the array
            //to the pic which is also of kind byte[]
            byte[] pic = stream.ToArray();
            return pic;
        }

        public static bool Operator(string logic, decimal x, decimal y)
        {
            switch (logic)
            {
                case ">": return x > y;
                case "<": return x < y;
                case "==": return x == y;
                case ">=": return x >= y;
                case "<=": return x >= y;
                case "!=": return x >= y;
                default: throw new Exception("invalid logic");
            }
        }

        #region //Code create placeholder Control
        public void createPlaceHolderControl(Control control, string placeholder)
        {
            control.Enter += (sender, e) => control_Enter(sender, e, placeholder);
            control.Leave += (sender, e) => control_Leave(sender, e, placeholder);
        }

        private void control_Enter(object sender, EventArgs e, string placeholder)
        {
            Control controlTemp = (Control)sender;
            controlTemp.ForeColor = Color.FromArgb(0, 0, 20);
        }

        private void control_Leave(object sender, EventArgs e, string placeholder)
        {
            Control controlTemp = (Control)sender;

            if (controlTemp.Text == "" || controlTemp.Text == placeholder)
            {
                controlTemp.ForeColor = Color.FromArgb(144, 142, 144);
            }
        }
        #endregion

        public DataTable LinqQueryToDataTable(IEnumerable<dynamic> v)
        {
            var firstRecord = v.FirstOrDefault();
            if (firstRecord == null)
                return null;
            PropertyInfo[] infos = firstRecord.GetType().GetProperties();
            DataTable table = new DataTable();
            foreach (var info in infos)
            {

                Type propType = info.PropertyType;

                if (propType.IsGenericType
                    && propType.GetGenericTypeDefinition() == typeof(Nullable<>)) //Nullable types should be handled too
                {
                    table.Columns.Add(info.Name, Nullable.GetUnderlyingType(propType));
                }
                else
                {
                    table.Columns.Add(info.Name, info.PropertyType);
                }
            }

            DataRow row;

            foreach (var record in v)
            {
                row = table.NewRow();
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    row[i] = infos[i].GetValue(record) != null ? infos[i].GetValue(record) : DBNull.Value;
                }

                table.Rows.Add(row);
            }

            //Table is ready to serve.
            table.AcceptChanges();

            return table;
        }

    }
}
