using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{

    enum ChineseZodiac { Rat = 4, Ox, Tiger, Rabbit, Dragon, Snake, Horse, Goat, Monkey = 0, Rooster, Dog, Pig };

    internal class User
    {
       
        private DateTime _birthDate;

        private int _age;

        private bool _isBDay;

        private bool _validDate;

        private string _zodiac;

        private string _chineseZodiac;

        public DateTime BirthDate
        {
            get { return _birthDate; }
            set {

                _birthDate = value;

                DateTime today = DateTime.Today;

                //check if valid date
                int result = DateTime.Compare(today, BirthDate);
                if (result < 0 || today.Year - BirthDate.Year > 135)
                {
                    ValidDate = false;
                }
                else
                {
                    ValidDate = true;
                }

                //set age
                var age = today.Year - BirthDate.Year;
                if (BirthDate > today.AddYears(-age)) age--;
                Age = age;

                //check if BDay
                isBDay = false;
                if (today.DayOfYear == BirthDate.DayOfYear)
                {
                    isBDay = true;
                }

                //chinese zodiac
                int year = BirthDate.Year;
                int rem = year % 12;
                ChineseZodiac zodiac = (ChineseZodiac)rem;
                ChineseZodiac = zodiac.ToString();


                //zodiac
                Zodiac = getZodiac();

            }
        }

        private string getZodiac()
        {
            int month = BirthDate.Month;
            int day = BirthDate.Day;
            switch (month)
            {
                case 1:
                    if (day <= 19)
                        return "Capricorn";
                    else
                        return "Aquarius";

                case 2:
                    if (day <= 18)
                        return "Aquarius";
                    else
                        return "Pisces";
                case 3:
                    if (day <= 20)
                        return "Pisces";
                    else
                        return "Aries";
                case 4:
                    if (day <= 19)
                        return "Aries";
                    else
                        return "Taurus";
                case 5:
                    if (day <= 20)
                        return "Taurus";
                    else
                        return "Gemini";
                case 6:
                    if (day <= 20)
                        return "Gemini";
                    else
                        return "Cancer";
                case 7:
                    if (day <= 22)
                        return "Cancer";
                    else
                        return "Leo";
                case 8:
                    if (day <= 22)
                        return "Leo";
                    else
                        return "Virgo";
                case 9:
                    if (day <= 22)
                        return "Virgo";
                    else
                        return "Libra";
                case 10:
                    if (day <= 22)
                        return "Libra";
                    else
                        return "Scorpio";
                case 11:
                    if (day <= 21)
                        return "Scorpio";
                    else
                        return "Sagittarius";
                case 12:
                    if (day <= 21)
                        return "Sagittarius";
                    else
                        return "Capricorn";
            }
            return "";
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public bool ValidDate
        {
            get {

                return _validDate;
            }
            set { _validDate = value; }
        }

        public bool isBDay
        {
            get
            {
                return _isBDay;
            }
            set { _isBDay = value; }
        }



        public string Zodiac
        {
            get
            {
                return _zodiac;
            }
            set { _zodiac = value; }
        }

        public string ChineseZodiac
        {
            get
            {
                return _chineseZodiac;
            }
            set { _chineseZodiac = value; }
        }
        
        
    }
}
