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
            var bdayMonth = _birthday.Month;
            var bdayDay = _birthday.Day;

            if (bdayMonth == 1)
                return bdayDay < 20 ? SunSignsZodiac[0] : SunSignsZodiac[1];

            else if (bdayMonth == 2)
                return bdayDay < 19 ? SunSignsZodiac[1] : SunSignsZodiac[2];

            else if (bdayMonth == 3)
                return bdayDay < 21 ? SunSignsZodiac[2] : SunSignsZodiac[3];

            else if (bdayMonth == 4)
                return bdayDay <= 20 ? SunSignsZodiac[3] : SunSignsZodiac[4];

            else if (bdayMonth == 5)
                return bdayDay < 21 ? SunSignsZodiac[4] : SunSignsZodiac[5];

            else if (bdayMonth == 6)
                return bdayDay < 21 ? SunSignsZodiac[5] : SunSignsZodiac[6];

            else if (bdayMonth == 7)
                return bdayDay < 23 ? SunSignsZodiac[6] : SunSignsZodiac[7];

            else if (bdayMonth == 8)
                return bdayDay < 23 ? SunSignsZodiac[7] : SunSignsZodiac[8];

            else if (bdayMonth == 9)
                return bdayDay < 23 ? SunSignsZodiac[8] : SunSignsZodiac[9];

            else if (bdayMonth == 10)
                return bdayDay < 23 ? SunSignsZodiac[9] : SunSignsZodiac[10];

            else if (bdayMonth == 11)
                return bdayDay < 22 ? SunSignsZodiac[10] : SunSignsZodiac[11];

            else if (bdayMonth == 12)
                return bdayDay < 22 ? SunSignsZodiac[11] : SunSignsZodiac[0];

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
                sb.AppendLine($"Age: {CountAge}");
            sb.AppendLine($"Sun sign: {SunSign}");
            sb.AppendLine($"Chinese sign: {ChineseSign}");
            return sb.ToString();
        }
    }
}
