using System;
using System.Text;

namespace Lab02Prokopchuk.Models
{
    class Person
    {
        #region Fields
        private string _name;
        private string _lastname;
        private string _email;
        private DateTime _birthday;

        private readonly bool _isAdult;
        private readonly string _sunSign;
        private readonly string _chineseSign;
        private readonly bool _isBirthday;

        private readonly string[] zodiacSignsChinese =
        { "Monkey", "Rooster", "Dog", "Pig", "Rat", "Ox", 
          "Tiger", "Rabbit", "Dragon", "Snake",
          "Horse", "Sheep"
        };

        private readonly string[] SunSignsZodiac =
        { "Capricorn", "Aquarius", "Pisces", "Aries", "Taurus", "Gemini", "Cancer",
          "Leo", "Virgo", "Libra", "Scorpio", "Sagittarius",
        };
        #endregion

        #region Properties
        public String Name { get; private set; }
        public string Lastname { get; private set; }
        public string Email { get; private set; }
        public DateTime Birthday { get; private set; }
        public bool IsAdult { get; private set; }
        public string SunSign { get; private set; }
        public string ChineseSign { get; private set; }
        public bool IsBirthday { get; private set; }
        #endregion

        #region Methods
        private int CountAge()
        {
            var currentDay = DateTime.Today;
            var age = currentDay.Year - Birthday.Year;
            if (Birthday.Date > currentDay.AddYears(age * (-1)))
                age--;
            return age;
        }

        private string CountSunZodiac()
        {
            var day = Birthday.Day;
            var month = Birthday.Month;

            if (month == 1)
            {
                if (day < 20)
                    return SunSignsZodiac[0];
                else 
                    return SunSignsZodiac[1];
            }
            else if (month == 2)
            {
                if (day < 19) 
                    return SunSignsZodiac[1];
                else 
                    return SunSignsZodiac[2];
            }
            else if (month == 3)
            {
                if (day < 21) 
                    return SunSignsZodiac[2];
                else 
                    return SunSignsZodiac[3];
            }
            else if (month == 4)
            {
                if (day < 21) 
                    return SunSignsZodiac[3];
                else 
                    return SunSignsZodiac[4];
            }
            else if (month == 5)
            {
                if (day < 21) 
                    return SunSignsZodiac[4];
                else 
                    return SunSignsZodiac[5];
            }
            else if (month == 6)
            {
                if (day < 21) 
                    return SunSignsZodiac[5];
                else
                    return SunSignsZodiac[6];
            }
            else if (month == 7)
            {
                if (day < 23) 
                    return SunSignsZodiac[6];
                else 
                    return SunSignsZodiac[7];
            }
            else if (month == 8)
            {
                if (day < 23)
                    return SunSignsZodiac[7];
                else 
                    return SunSignsZodiac[8];
            }
            else if (month == 9)
            {
                if (day < 23) 
                    return SunSignsZodiac[8];
                else 
                    return SunSignsZodiac[9];
            }
            else if (month == 10)
            {
                if (day < 23)
                    return SunSignsZodiac[9];
                else
                    return SunSignsZodiac[10];
            }
            else if (month == 11)
            {
                if (day < 22) 
                    return SunSignsZodiac[10];
                else 
                    return SunSignsZodiac[11];
            }
            else if (month == 12)
            {
                if (day < 22) 
                    return SunSignsZodiac[11];
                else 
                    return SunSignsZodiac[0];
            }
            else
                return "Error";
        }

        private string CountChineseZodiac()
        {
            var year = Birthday.Year;
            return zodiacSignsChinese[year % 12];
        }

        private bool CheckIfBDToday()
        {
            var currentDay = DateTime.Today;
            return Birthday.Day == currentDay.Day && Birthday.Month == currentDay.Month;
        }

        public bool CheckIfValidBD()
        {
            var userAge = CountAge();
            if (userAge < 0)
                return false;
            if (userAge > 135)
                return false;
            return true;
        }
        #endregion

        #region Constructors
        internal Person(string name, string lastname, string email, DateTime birthday)
        {
            Name = name;
            Lastname = lastname;
            Email = email;
            Birthday = birthday;

            IsAdult = CountAge() >= 18;
            SunSign = CountSunZodiac();
            ChineseSign = CountChineseZodiac();
            IsBirthday = CheckIfBDToday();
        }

        Person(string name, string lastname, string email)
            : this(name, lastname, email, DateTime.Today) { }

        Person(string name, string lastname, DateTime birthday)
            : this(name, lastname, "usersemail@ukr.net", birthday) { }
        #endregion

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine($"Name: {Name}");
            sb.AppendLine($"Last name: {Lastname}");
            sb.AppendLine($"Email: {Email}");
            sb.AppendLine($"Birthday on: {Birthday.Day}/{Birthday.Month}/{Birthday.Year}");
            sb.AppendLine($"Is adult: {IsAdult}");
            if (IsBirthday)
                sb.AppendLine("Birthday is today!");
            else
                sb.AppendLine($"Age: {CountAge()}");
            sb.AppendLine($"Sun sign: {SunSign}");
            sb.AppendLine($"Chinese sign: {ChineseSign}");
            return sb.ToString();
        }
    }
}
