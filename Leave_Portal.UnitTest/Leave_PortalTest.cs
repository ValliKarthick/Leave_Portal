using System;
using NUnit.Framework;
using System.Reflection;
using System.Linq;

namespace Leave_Portal.UnitTest
{
    [TestFixture] 
    public class Leave_PortalTest
    {
        private MethodInfo testingMethod;
        private object SUT;

        [SetUp]
        public void Initialize()
        {
            Assembly assembly = Assembly.Load("Leave_Portal");
            SUT = assembly.CreateInstance(assembly.GetTypes().Where(type => type.Name == "Verification").FirstOrDefault()?.FullName, 
                false, BindingFlags.CreateInstance, null, null, null, null);
            testingMethod = SUT.GetType().GetMethod("CheckLeaveRequestDate");
        }

        [Test]
        public void Check_Return_Message_When_Date_Is_Not_A_FutureDate()
        {
            DateTime dateTime = DateTime.Now.AddDays(-1);
             Assert.AreEqual("Date must be a future date!", testingMethod.Invoke(SUT, new object[] { dateTime }));
        }

        [Test]
        public void Check_Return_Message_When_Date_Is_Not_CurrentYear()
        {
            DateTime dateTime = DateTime.Now.AddYears(2);
            Assert.AreEqual("You can avail leave only for the current year!", testingMethod.Invoke(SUT, new object[] { dateTime }));
        }

        [Test]
        public void Check_Return_Message_When_Date_Is_Not_A_Weekday()
        {
            DateTime dateTime = DateTime.Now.AddDays(6 - (int) DateTime.Now.DayOfWeek);
            Assert.AreEqual("Date belongs to weekend!", testingMethod.Invoke(SUT, new object[] { dateTime }));
        }

        [Test]
        public void Check_Return_Message_When_Date_Is_Valid()
        {
            DateTime dateTime = DateTime.Now.AddDays(6 - (int)DateTime.Now.DayOfWeek +2);
            Assert.AreEqual("Leave Granted!", testingMethod.Invoke(SUT, new object[] { dateTime }));
        }
    }
}
