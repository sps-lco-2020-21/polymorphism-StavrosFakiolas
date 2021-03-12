using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualNewOverride
{
    class Person
    {
        protected string _first;
        protected string _last;
        protected string _email;
        protected DateTime _doB;
        protected int _age;

        public Person(string first, string last, DateTime doB, string email)
        {
            SetupPerson(first, last, doB, email);
        }

        public Person(string first, string last, DateTime doB)
        {
            SetupPerson(first, last, doB, "");
        }

        public Person() { } //needed to construct derived class

        protected void SetupPerson(string first, string last, DateTime doB, string email) //actual setup
        {
            _first = first;
            _last = last;
            _doB = doB;
            _email = email;
            _age = CalculateAge(doB);

            if (ValidateAge() == false)
            {
                throw new Exception("Age is invalid"); //I think this is the proper way to throw an excption here?
            }
        }
        protected int CalculateAge(DateTime birth)
        {
            return DateTime.Today.Year - birth.Year;
        }
        protected virtual bool ValidateAge() //OVERRIDE THIS - haha great idea stavros
        {
            if (_age < 115 && _age >= 0)
                return true;
            else
                return false;
        }

        public bool Valid { get { return ValidateAge(); } } //returns if valid age boolean
        public bool Adult { get { if (_age >= 18) { return true; } else { return false; } } }
        public bool Birthday { get { if ((DateTime.Today.Month - _doB.Month == 0) && (DateTime.Today.Day - _doB.Day == 0)) { return true; } else { return false; } } } //returns true if bday today
    }

    class Student : Person
    {
        protected string _schoolYear;

        public Student(string name, string name2, DateTime doB, string email, string schoolYear)
        {
            SetupStudent(name, name2, doB,email,schoolYear);
        }

        protected void SetupStudent(string first, string last, DateTime doB, string email, string schoolYear)
        {
            _first = first;
            _last = last;
            _doB = doB;
            _email = email;
            _schoolYear = schoolYear;
            _age = CalculateAge(doB);

            
            if (ValidateAge() == false)
            {
                throw new Exception("Age is invalid"); //I think this is the proper way to throw an excption here?
            }
        }
        
        //has to be 4-18
        protected override bool ValidateAge() 
        {
            if (_age <= 18 && _age >= 4)
                return true;
            else
                return false;
        }
    
    }

    class Teacher : Person
    {
        protected string _subject;

        public Teacher(string name, string name2, DateTime doB, string email, string subject)
        {
            SetupTeacher(name, name2, doB, email, subject);
        }

        protected void SetupTeacher(string first, string last, DateTime doB, string email, string subject)
        {
            _first = first;
            _last = last;
            _doB = doB;
            _email = email;
            _subject = subject;
            _age = CalculateAge(doB);

            //Has to be adult - add functionality here
            if (ValidateAge() == false)
            {
                throw new Exception("Age is invalid"); //I think this is the proper way to throw an excption here?
            }
        }

        protected override bool ValidateAge() //19 - 115?
        {
            if (_age < 115  && _age >= 19)
                return true;
            else
                return false;
        }
    }
}

// DateTime today = DateTime.Today;

// if(DateTime.Today.Year - dt.Year >= 18) 
// { 
//     return "adult" 
// }

// DateTime tomorrow = today.AddDays(1);

// TimeSpan diff = tomorrow - today;