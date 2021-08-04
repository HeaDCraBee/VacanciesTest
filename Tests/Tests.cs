using NUnit.Framework;
using VacanciesTest;

namespace Tests
{
    //Использование для автоматизации тестирования с различными параметрами
    public class Tests
    {
        [Test]
        public void TestVacProdEng()
        {
            var department = "Разработка продуктов";
            var language = "Английский";
            Assert.IsTrue(Program.StartTest(department, language));
        }

        [Test]
        public void TestVacProdRusEng()
        {
            var department = "Разработка продуктов";
            var languages = new string[] { "Русский", "Английский" };
            Assert.IsTrue(Program.StartTest(department, languages));
        }
       
        [Test]
        public void TestVacSellEngRus()
        {
            var department = "Продажи";
            var languages = new string[] { "Английский", "Русский" };
            Assert.IsTrue(Program.StartTest(department, languages));
        }

        [Test]
        public void TestVacProdEngCustomExpectedValue()
        {
            var expectedValue = 6;
            var department = "Разработка продуктов";
            var language = "Английский";
            Assert.IsTrue(Program.StartTest(expectedValue, department, language));
        }
    }
}