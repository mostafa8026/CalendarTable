using System;
using System.Globalization;
using Excel = Microsoft.Office.Interop.Excel;


namespace ConsoleApp1
{
    class Program
    {
        private static Excel.Workbook MyBook = null;
        private static Excel.Application MyApp = null;
        private static Excel.Worksheet MySheet = null;

        static void Main(string[] args)
        {
            MyApp = new Excel.Application();
            MyApp.Visible = true;
            //if (!File.Exists("CalendarBook.xlsx"))
            //    MyApp.Workbooks.Open(
            MyBook = MyApp.Workbooks.Add();
            MySheet = (Excel.Worksheet)MyBook.ActiveSheet; // Explicit cast is not required here
            var lastRow = MySheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Row;

            int year = 1397, month = 1, day = 1;
            DateTime startDate = Tools.shamsiStringToMiladi(year, month, day);
            for (int i = 0; i < 366; i++)
            {
                DateTime newDate = startDate.AddDays(i);
                PersianCalendar perCal = new PersianCalendar();
                HijriCalendar hijriCal = new HijriCalendar();
                int miladiYear = newDate.Year;
                int miladiMonth = newDate.Month;
                int miladiDay = newDate.Day;
                string miladiMonthName = newDate.ToString("MMMM", CultureInfo.CreateSpecificCulture("en"));
                int shamsiYear = perCal.GetYear(newDate);
                int shamsiMonth = perCal.GetMonth(newDate);
                int shamsiDay = perCal.GetDayOfMonth(newDate);
                string shmasiMonthName = newDate.ToString("MMMM", CultureInfo.CreateSpecificCulture("fa"));
                string shmasiWeekDayName = newDate.ToString("ddd", CultureInfo.CreateSpecificCulture("fa"));
                int HijriYear = hijriCal.GetYear(newDate);
                int HijriMonth = hijriCal.GetMonth(newDate);
                int HijriDay = hijriCal.GetDayOfMonth(newDate);
                string HijriMonthName = newDate.ToString("MMMM", CultureInfo.CreateSpecificCulture("ar"));
                lastRow += 1;
                MySheet.Cells[lastRow, 1] = shamsiYear;
                MySheet.Cells[lastRow, 2] = shamsiMonth;
                MySheet.Cells[lastRow, 3] = shamsiDay;
                MySheet.Cells[lastRow, 4] = shmasiMonthName;
                MySheet.Cells[lastRow, 5] = shmasiWeekDayName;
                MySheet.Cells[lastRow, 6] = HijriYear;
                MySheet.Cells[lastRow, 7] = HijriMonth;
                MySheet.Cells[lastRow, 8] = HijriDay;
                MySheet.Cells[lastRow, 9] = HijriMonthName;
                MySheet.Cells[lastRow, 10] = miladiYear;
                MySheet.Cells[lastRow, 11] = miladiMonth;
                MySheet.Cells[lastRow, 12] = miladiDay;
                MySheet.Cells[lastRow, 13] = miladiMonthName;
            }
            MyBook.SaveAs("CalndarTable");
        }
    }
}
