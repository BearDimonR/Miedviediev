using System;
using System.Globalization;
using System.Threading;

namespace Miedviediev.Practice1
{
    public class Data
    {
        public int Age { get; private set; }
        public bool IsBirthDay { get; private set; }
        public string RemainDays{ get; private set; }
        public WesternZodiac WesternZodiac { get; private set; }
        public ChineseZodiac ChineseZodiac { get; private set; }
        public DateTime DateTime { get; private set; }

        public Data(DateTime time)
        {
            DateTime = time;
        }
        public void CountAge(DateTime value)
        {
            DateTime now = DateTime.Now;
            int age = now.Year - value.Year;
            if (value > now.AddYears(-age)) age--;
            if (age < 0 || age > 135)
                throw new ArgumentOutOfRangeException();
            DateTime = value;
            Age = age;
        }

        public void FindWesternZodiac()
        {
            Thread.Sleep(1500);
            switch (DateTime.Month)
            {
                case 1:
                    WesternZodiac = DateTime.Day <= 20 ? WesternZodiac.Capricorn : WesternZodiac.Aquarius;
                    break;
                case 2:
                    WesternZodiac = DateTime.Day <= 19 ? WesternZodiac.Aquarius : WesternZodiac.Pisces;
                    break;
                case 3:
                    WesternZodiac = DateTime.Day <= 20 ? WesternZodiac.Pisces : WesternZodiac.Aries;
                    break;
                case 4:
                    WesternZodiac = DateTime.Day <= 20 ? WesternZodiac.Aries : WesternZodiac.Taurus;
                    break;
                case 5:
                    WesternZodiac = DateTime.Day <= 21 ? WesternZodiac.Taurus : WesternZodiac.Gemini;
                    break;
                case 6:
                    WesternZodiac = DateTime.Day <= 22 ? WesternZodiac.Gemini : WesternZodiac.Cancer;
                    break;
                case 7:
                    WesternZodiac = DateTime.Day <= 22 ? WesternZodiac.Cancer : WesternZodiac.Leo;
                    break;
                case 8:
                    WesternZodiac = DateTime.Day <= 23 ? WesternZodiac.Leo : WesternZodiac.Virgo;
                    break;
                case 9:
                    WesternZodiac = DateTime.Day <= 23 ? WesternZodiac.Virgo : WesternZodiac.Libra;
                    break;
                case 10:
                    WesternZodiac = DateTime.Day <= 23 ? WesternZodiac.Libra : WesternZodiac.Scorpio;
                    break;
                case 11:
                    WesternZodiac = DateTime.Day <= 22 ? WesternZodiac.Scorpio : WesternZodiac.Sagittarius;
                    break;
                case 12:
                    WesternZodiac = DateTime.Day <= 21 ? WesternZodiac.Sagittarius : WesternZodiac.Capricorn;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void FindChineseZodiac()
        {
            Thread.Sleep(500);
            try
            {
                ChineseLunisolarCalendar calendar = new ChineseLunisolarCalendar();
                int terrestrialBranch = calendar.GetTerrestrialBranch(calendar.GetSexagenaryYear(DateTime));
                ChineseZodiac = (ChineseZodiac) terrestrialBranch;
            }
            catch (ArgumentOutOfRangeException)
            {
                ChineseZodiac = (ChineseZodiac) ((DateTime.Year - 4) % 12 + 1);
            }
        }

        public void CalculateBirthDay()
        {
            Thread.Sleep(1000);
            DateTime nextBirthday = DateTime.AddYears(Age + 1);
            TimeSpan difference = nextBirthday - DateTime.Today;
            int res = Convert.ToInt32(difference.TotalDays);
            IsBirthDay = res == 366;
            RemainDays = !IsBirthDay ? string.Concat("Days left: ",res.ToString()) : "Happy BirthDay!!!";
        }
    }
}