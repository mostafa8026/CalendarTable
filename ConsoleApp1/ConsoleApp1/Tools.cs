using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class Tools
    {
        public static string toStringDay(DayOfWeek day)
        {
            switch (day)
            {
                case DayOfWeek.Saturday:
                    return "شنبه";
                case DayOfWeek.Sunday:
                    return "یک شنبه";
                case DayOfWeek.Monday:
                    return "دو شنبه";
                case DayOfWeek.Tuesday:
                    return "سه شنبه";
                case DayOfWeek.Wednesday:
                    return "چهار شنبه";
                case DayOfWeek.Thursday:
                    return "پنج شنبه";
                case DayOfWeek.Friday:
                    return "جمعه";
                default:
                    return "روز سال";
            }
        }

        public static int getDayNumberOFWeek(DateTime dt)
        {
            switch (dt.DayOfWeek)
            {
                case DayOfWeek.Saturday:
                    return 0;
                case DayOfWeek.Sunday:
                    return 1;
                case DayOfWeek.Monday:
                    return 2;
                case DayOfWeek.Tuesday:
                    return 3;
                case DayOfWeek.Wednesday:
                    return 4;
                case DayOfWeek.Thursday:
                    return 5;
                case DayOfWeek.Friday:
                    return 6;
                default:
                    return -1;

            }
        }

        public static DateTime shamsiStringToMiladi(string sh)
        {
            DateTime dt = shamsiStringToMiladi(getYear(sh), getMonth(sh), getDay(sh));
            return dt;
        }

        public static DateTime shamsiStringToMiladi(int year, int month, int day)
        {
            DateTime dt = new DateTime(year, month, day, new PersianCalendar());
            return dt;
        }

        public static int getDay(string s)
        {
            string output = "";
            if (s[6] == '/')
            {
                if (s.Length == 8)
                    output += s[7];
                else
                {
                    output += s[7];
                    output += s[8];
                }
            }
            else
            {
                if (s.Length == 9)
                    output += s[8];
                else
                {
                    output += s[8];
                    output += s[9];
                }
            }
            return Convert.ToInt32(output);
        }

        public static int getMonth(string s)
        {
            string output = "";
            if (s[6] == '/')
                output += s[5];
            else
            {
                output += s[5];
                output += s[6];
            }
            return Convert.ToInt32(output);
        }

        public static int getYear(string s)
        {
            string output = "";
            output += s[0];
            output += s[1];
            output += s[2];
            output += s[3];
            return Convert.ToInt32(output);
        }

        public static string toStringMonth(int month)
        {
            switch (month)
            {
                case 1:
                    return "فروردين";
                    break;
                case 2:
                    return "ارديبهشت";
                    break;
                case 3:
                    return "خرداد";
                    break;
                case 4:
                    return "تير";
                    break;
                case 5:
                    return "مرداد";
                    break;
                case 6:
                    return "شهريور";
                    break;
                case 7:
                    return "مهر";
                    break;
                case 8:
                    return "آبان";
                    break;
                case 9:
                    return "آذر";
                    break;
                case 10:
                    return "دي";
                    break;
                case 11:
                    return "بهمن";
                    break;
                case 12:
                    return "اسفند";
                    break;
                default:
                    return "ماه سال";
                    break;
            }
        }
    }
}
