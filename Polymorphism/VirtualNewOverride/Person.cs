using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualNewOverride
{
/// <summary>
/// Extension class - "The default class of humanity"
/// </summary>
    public class Person
    {
        protected string _first;
        protected string _last;
        protected string _email;
        protected DateTime _doB;

        public Person(string first, string last, DateTime doB, string email)
        {
            _first = first;
            _last = last;
            _doB = doB;
            _email = email;

            if (ValidateAge() == false)
            {
                throw new ApplicationException("Age is invalid");
            }
        }

        public Person(string first, string last, DateTime doB) :
            this(first, last, doB, "")
        { }

        public Person() { } //needed to construct derived class

        protected int CalculateAge(DateTime birth)
        {
            return (DateTime.Today - birth).Days / 365;
        }

        protected virtual bool ValidateAge() //OVERRIDE THIS - haha great idea stavros
        {
            int age = CalculateAge(_doB);
            return age <= 130 && age >= 0;
        }

        public bool Valid { get { return ValidateAge(); } } //returns if valid age boolean
        public bool Adult { get { return CalculateAge(_doB) >= 18; } }
        public bool Birthday { get { if ((DateTime.Today.Month - _doB.Month == 0) && (DateTime.Today.Day - _doB.Day == 0)) { return true; } else { return false; } } } //returns true if bday today
        public virtual string ScreenName { get { return _first.ToLower() + _last.ToLower() + _doB.Day + _doB.Month; } }
        
        public string ChineseSign
        {
           get
            {
                int N = _doB.Year + 9;
                int output = N % 12;
                switch(output)
                {
                    case 0:
                        return "Pig";
                    case 1:
                        return "Rooster";
                    case 2:
                        return "Dog";
                    case 3:
                        return "Pig";
                    case 4:
                        return "Rat";
                    case 5:
                        return "Ox";
                    case 6:
                        return "Tiger";
                    case 7:
                        return "Rabbit";
                    case 8:
                        return "Dragon";
                    case 9:
                        return "Snake";
                    case 10:
                        return "Horse";
                    case 11:
                        return "Sheep";
                    default:
                        throw new ApplicationException("Error ChineseSign");
                }
            }
        }
    }
/// <summary>
/// Extension of Person class - Student
/// </summary>
    public class Student : Person
    {
        protected string _schoolYear;

        public Student(string first, string last, DateTime doB, string email, string schoolYear)
        {
            _first = first;
            _last = last;
            _doB = doB;
            _email = email;
            _schoolYear = schoolYear;

            if (ValidateAge() == false)
            {
                throw new Exception("Age is invalid");
            }
        }
        public Student(string name, string name2, DateTime doB, string schoolYear) :
            this(name, name2, doB, "", schoolYear)
        { }
        
        //has to be 4-18 (normally)
        protected override bool ValidateAge() 
        {
            int age = CalculateAge(_doB);
            return age <= 18 && age >= 4;
        }

        public override string ScreenName { get { return _first.ToLower() + _last.ToLower() + _doB.Day + _doB.Month + _schoolYear; } }

    }
    /// <summary>
    /// Extension of Person class - Teacher
    /// </summary>
    public class Teacher : Person
    {
        protected string _subject;

        public Teacher(string first, string last, DateTime doB, string email, string subject)
        {
            _first = first;
            _last = last;
            _doB = doB;
            _email = email;
            _subject = subject;

            if (ValidateAge() == false)
            {
                throw new Exception("Age is invalid");
            }
        }

        public Teacher(string name, string name2, DateTime doB, string subject) :
            this(name, name2, doB, "", subject)
        { }

        protected override bool ValidateAge() 
        {
            return Adult;
        }

        public override string ScreenName { get { return _last + _first; } }

    }
}

// DateTime today = DateTime.Today;

// if(DateTime.Today.Year - dt.Year >= 18) 
// { 
//     return "adult" 
// }

// DateTime tomorrow = today.AddDays(1);

// TimeSpan diff = tomorrow - today;