using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace SeleniumTestApp
{
    [TestClass]
    public class UnitTest1
    {
        private string loginText = "Пользователь 1";

        private string passwordText = "111";

        private IWebDriver _driver;

        private string HomeURL = "http://localhost:63171/Account/LogIn";

        [TestInitialize]
        public void Enter()
        {
            _driver = new ChromeDriver();

            _driver.Navigate().GoToUrl(HomeURL);

            IWebElement loginElement = _driver.FindElement(By.Name("UserName"));
            loginElement.SendKeys(loginText);

            IWebElement passElement = _driver.FindElement(By.Name("Password"));
            passElement.SendKeys(passwordText);

            IWebElement sobmitElement = _driver.FindElement(By.TagName("button"));

            sobmitElement.Click();

            _driver.Manage().Timeouts().ImplicitWait = (TimeSpan.FromSeconds(20));
             
        }

        [TestMethod]
        public void TestUserLogin()
        {
            //Работает только в полноэкранном окне браузера???
            IWebElement loginResult = _driver.FindElement(By.ClassName("login"));

            Assert.IsTrue(loginResult.Text.Contains(loginText));

        }

        [TestCleanup]
        public void TestCleanup()
        {
            _driver.Close();
        }
    }
}
