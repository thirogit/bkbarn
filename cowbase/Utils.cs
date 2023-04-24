namespace cowbase
{
    public class Utils
    {
        public static System.IFormatProvider m_numberFormat;

        public static float ParseFloat(string sFloat)
        {
            return float.Parse(sFloat, System.Globalization.NumberStyles.AllowDecimalPoint, GetFormatProvider());
        }

        public static int ParseInteger(string sInteger)
        {
            return int.Parse(sInteger);
        }

        public static string FormatFloatSQL(System.Nullable<double> dValue,int precision)
        {
            if (dValue.HasValue)
                return FormatFloat(dValue.Value, 5);
            else
                return GetSQLNull();
        }

        public static string FormatMoney(double dValue)
        {
            return FormatFloat(dValue,2);
        }

        public static string FormatMoneySQL(System.Nullable<double> money)
        {
            return FormatFloatSQL(money, 5);
        }

        
        public static string FormatIntegerSQL(System.Nullable<int> iValue)
        {
            if (iValue.HasValue)
                return iValue.Value.ToString();
            else
                return GetSQLNull();
        }

        public static string FormatWeightSQL(System.Nullable<double> weight)
        {
            return FormatFloatSQL(weight,5);
        }

        public static string FormatWeightSQL(double weight)
        {
            return FormatFloat(weight,5);
        }

        public static string FormatFloat(double dValue,int precision)
        {
            string format = "{0:F" + precision.ToString() + "}";

            return string.Format(GetFormatProvider(), format, dValue);
        }

        public static string FormatDayDate(System.DateTime date)
        {
            if (date == null)
                return string.Empty;

            string dayDateFormat = "{0:0000}-{1:00}-{2:00}";
            return string.Format(GetFormatProvider(), dayDateFormat, date.Year,date.Month,date.Day);
        }

        public static string FormatActionSQL(Action action)
        {
            return action.GetId().ToString();
        }

        public static string GetSQLNull()
        {
            return "NULL";
        }

        public static int GetAssemblyBuildNo()
        {
            return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Build;
        }

        public static System.IFormatProvider GetFormatProvider()
        {
            if (m_numberFormat == null)
            {
                System.Globalization.NumberFormatInfo nfi = new System.Globalization.NumberFormatInfo();
                nfi.NumberDecimalSeparator = GetDecimalSeparator().ToString();
                m_numberFormat = nfi;
            }
            return m_numberFormat;
        }

        public static char GetDecimalSeparator()
        {
            return '.';
        }

        public static string GetApplicationDirectory()
        {
            return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName);
        }

        public static bool IsStrValidEAN(string toValidate)
        {
            string strCopy = toValidate.ToUpper();

            char[] chars = strCopy.ToCharArray();

            if (chars[0] >= 'A' && chars[0] <= 'Z' &&
                chars[1] >= 'A' && chars[1] <= 'Z')
            {
                for (int i = 2; i < chars.Length; i++)
                    if (!(chars[i] >= '0' && chars[i] <= '9'))
                        return false;

                return true;
            }
            return false;
        }

        public static bool IsEANValid(string toValidate)
        {
            if (!IsStrValidEAN(toValidate)) return false;
            int cksum = 0;

            char[] chars = toValidate.Substring(2, 12).ToCharArray();
            for (int i = 0; i < 11; i++)
            {
                if (chars[i] > '9' || chars[i] < '0') return false;
                cksum += (chars[i] - 0x30) * ((i % 2 == 1) ? 1 : 3);
            }
            cksum = 10 - (cksum % 10);
            if ((cksum) == (int)chars[11] - 0x30) return true;

            return false;
        }

        public static bool IsNumeric(string s)
        {
            char[] chars = s.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
                if (!(chars[i] >= '0' && chars[i] <= '9'))
                    return false;

            return true;
        }

    }
}