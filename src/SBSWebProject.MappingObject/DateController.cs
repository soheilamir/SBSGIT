using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;

namespace SBSWebProject.MappingObject
{
    public class DateController
    {

        #region Global VarS

        private DateTime _selDate;
        private int _selMonth;
        readonly string[] _lstMonth = { "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند" };

        #endregion

        # region PropS

        public DateTime GerogorianDate
        {
            get
            {
                return this._selDate;
            }
            set
            {
                this._selDate = value;
            }
        }

        public string JalaiDate
        {
            get
            {
                return this.ConvertGer2Jalai(this._selDate);
            }
            set
            {
                this._selDate = this.ConvertJalai2Ger(value);
            }
        }


        # endregion

        # region Methods

        public void ComboMothChanged(int month)
        {
            this._selMonth = month;
        }

        public IList FillCmbYear(int start, int lengh)
        {
            IList list = new List<string>();
            for (int i = start; i < start + lengh; i++)
            {
                list.Add(Convert.ToString(i));
            }
            return list;
        }

        public IList FillCmbMonth()
        {
            IList list = new List<string>();
            for (int i = 1; i < 10; i++)
            {
                list.Add("0" + i);
            }
            for (int i = 10; i < 13; i++)
            {
                list.Add(Convert.ToString(i));
            }

            return list;
        }

        public IList FillCmbDay()
        {
            IList list = new List<string>();
            for (int i = 1; i < 10; i++)
            {
                list.Add("0" + i);
            }
            for (int i = 10; i < 31; i++)
            {
                list.Add(Convert.ToString(i));
            }
            if (this._selMonth < 7)
            {
                list.Add("31");
            }

            return list;
        }

        public string ConvertGer2Jalai(DateTime date)
        {
            string strJalaliDate;
            System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
            strJalaliDate = pc.GetYear(date).ToString() + "/";
            int month = pc.GetMonth(date);
            if (month < 10)
                strJalaliDate += "0" + month.ToString() + "/";
            else
                strJalaliDate += month.ToString() + "/";
            int day = pc.GetDayOfMonth(date);
            if (day < 10)
                strJalaliDate += "0" + day.ToString();
            else
                strJalaliDate += day.ToString();
            return strJalaliDate;
        }

        public DateTime ConvertJalai2Ger(string date)
        {
            System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
            string[] straDate = date.Split('/');
            if (straDate.Length == 3)
                return pc.ToDateTime(Convert.ToInt32(straDate[0]), Convert.ToInt32(straDate[1]), Convert.ToInt32(straDate[2]), 12, 0, 0, 0);
            return DateTime.Now;

        }

        public string[] GetArrayDate(string date)
        {
            string[] straDate = date.Split('/');
            if (straDate.Length == 3)
                return straDate;
            return null;
        }

        public DataTable FillCmbMonthByName(int lang)
        {
            DataTable tblMounth = new DataTable("tblMonyh");
            tblMounth.Columns.Add("MonthName", typeof(string));
            tblMounth.Columns.Add("MonthNumber", typeof(int));
            if (lang == 2)
            {

                tblMounth.Rows.Add("January", 1);
                tblMounth.Rows.Add("February", 2);
                tblMounth.Rows.Add("March", 3);
                tblMounth.Rows.Add("April", 4);
                tblMounth.Rows.Add("May", 5);
                tblMounth.Rows.Add("June", 6);
                tblMounth.Rows.Add("July", 7);
                tblMounth.Rows.Add("Agust", 8);
                tblMounth.Rows.Add("September", 9);
                tblMounth.Rows.Add("October", 10);
                tblMounth.Rows.Add("November", 11);
                tblMounth.Rows.Add("Desember", 12);
                return tblMounth;
            }
            else
            {
                tblMounth.Rows.Add("فروردین", 1);
                tblMounth.Rows.Add("اردیبهشت", 2);
                tblMounth.Rows.Add("خرداد", 3);
                tblMounth.Rows.Add("تیر", 4);
                tblMounth.Rows.Add("مرداد", 5);
                tblMounth.Rows.Add("شهریور", 6);
                tblMounth.Rows.Add("مهر", 7);
                tblMounth.Rows.Add("آبان", 8);
                tblMounth.Rows.Add("آذر", 9);
                tblMounth.Rows.Add("دی", 10);
                tblMounth.Rows.Add("بهمن", 11);
                tblMounth.Rows.Add("اسفند", 12);
                return tblMounth;
            }
        }

        public string GetMonthName(int index)
        {
            if (index > 0 && index < 13)
                return _lstMonth[index - 1];
            return null;
        }


        # endregion
    }
}