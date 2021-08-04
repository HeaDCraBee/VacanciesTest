using NUnit.Framework;
using VacanciesTest;

namespace Tests
{
    //������������� ��� ������������� ������������ � ���������� �����������
    public class Tests
    {
        [Test]
        public void TestVacProdEng()
        {
            var department = "���������� ���������";
            var language = "����������";
            Assert.IsTrue(Program.StartTest(department, language));
        }

        [Test]
        public void TestVacProdRusEng()
        {
            var department = "���������� ���������";
            var languages = new string[] { "�������", "����������" };
            Assert.IsTrue(Program.StartTest(department, languages));
        }
       
        [Test]
        public void TestVacSellEngRus()
        {
            var department = "�������";
            var languages = new string[] { "����������", "�������" };
            Assert.IsTrue(Program.StartTest(department, languages));
        }

        [Test]
        public void TestVacProdEngCustomExpectedValue()
        {
            var expectedValue = 6;
            var department = "���������� ���������";
            var language = "����������";
            Assert.IsTrue(Program.StartTest(expectedValue, department, language));
        }
    }
}