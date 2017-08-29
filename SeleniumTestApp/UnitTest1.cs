using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace SeleniumTestApp
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            IWebDriver driver = new ChromeDriver();
             
            driver.Navigate().GoToUrl("localhost");
             
            IWebElement loginElement = driver.FindElement(By.Name("login"));
            loginElement.SendKeys("Пользователь 1");

            IWebElement passElement = driver.FindElement(By.Name("pass"));
            passElement.SendKeys("111");

            IWebElement sobmitElement = driver.FindElement(By.Name("submit"));
            
            sobmitElement.Click();
             
            driver.Close();
        }
    }
}
