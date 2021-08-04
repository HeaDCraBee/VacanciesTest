using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;

namespace VacanciesTest
{
    public class Program
    {
        private static string s_url = @"https://careers.veeam.ru/vacancies";
        private static string s_department = "Разработка продуктов";
        private static string s_language = "Английский";
        private static int? s_expectedValue;

        static void Main(string[] args)
        {
            StartTest(s_department, s_language);
        }

        //Метод для параметризации ожидаемого значения
        public static bool StartTest(int expectedValue, string department, params string[] languages)
        {
            s_expectedValue = expectedValue;
            return StartTest(department, languages);
        }

        public static bool StartTest(string department, params string[] languages)
        {
            IWebDriver webDriver = new FirefoxDriver();

            webDriver.Url = s_url;

            webDriver.Manage().Window.FullScreen();

            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));

            //Открытие списка департаментов
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//button[contains(.,'Все отделы')]")));
            element.Click();

            //Выбор департамента
            element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.LinkText(department)));
            element.Click();

            //Открытие списка языков
            element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("xpath=//button[contains(.,'Все языки')]")));
            element.Click();

            //Выбор языков
            foreach (var language in languages)
            {
                element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath($"//label[contains(.,'{language}')]")));
                element.Click();
            }

            //Ожидание прогрузки всех вакансий
            element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//div[@class = 'h-100 d-flex flex-column']")));

            //Получение списка вакансий
            var vacancies = webDriver.FindElements(By.XPath("//div[@class = 'h-100 d-flex flex-column']/a"));

            //Заголовок с количеством вакансий
            element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//h3/span")));

            int expectedValue;
            if (s_expectedValue == null)
            {
                if (!int.TryParse(element.GetAttribute("innerText"), out expectedValue))
                    throw new ArgumentException("Uncorrect value in vacancies number");
            }
            else
            {
                expectedValue = (int)s_expectedValue;
            }

            webDriver.Close();

            Console.WriteLine($"\nНайдено {vacancies.Count} вакансий");
            Console.WriteLine($"Ожидаемое кол-во вакансий: {expectedValue}");
            Console.WriteLine("\nEnd");

            return vacancies.Count == expectedValue;
        }
    }
}
