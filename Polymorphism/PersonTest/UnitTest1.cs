using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using VirtualNewOverride; //using other namespace + classes public

namespace PersonTest
{
    [TestClass]
    public class UnitTest1
    {
        DateTime minus18 = new DateTime(DateTime.Today.Year - 18,DateTime.Today.Month,DateTime.Today.Day);
        DateTime minus18Minus1 = new DateTime(DateTime.Today.Year - 18, DateTime.Today.Month, DateTime.Today.Day-1);
        DateTime minus18Plus1 = new DateTime(DateTime.Today.Year - 18, DateTime.Today.Month, DateTime.Today.Day + 1);
        DateTime myBirthday = new DateTime(2004, 3, 16);
        DateTime myBirthdayOlder = new DateTime(1990, 3, 16);


        //Something is going wrong here - I need to investigate further

        [TestMethod]
        public void TestAdult1()
        {
            // list and methods?
            
            Person me1 = new Person("Stavros", "Fakiolas", minus18, "Poggers@gmail.com");
            
            Assert.IsTrue(me1.Adult);
        }
        
        [TestMethod]
        public void TestAdult2()
        {
            Person me2 = new Person("Stavros", "Fakiolas", minus18Minus1, "Poggers@gmail.com");
            Assert.IsTrue(me2.Adult);
        }

        [TestMethod]
        public void TestAdult3()
        {
            Person me3 = new Person("Stavros", "Fakiolas", minus18Plus1, "Poggers@gmail.com");
            Assert.IsTrue(me3.Adult);
        }
    }
}
