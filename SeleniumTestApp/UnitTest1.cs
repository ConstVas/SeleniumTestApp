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
            var loginText = "Пользователь 1";
            var passwordText = "111";
            using (IWebDriver driver = new ChromeDriver())
            {
                 
                driver.Navigate().GoToUrl("http://localhost:63171/Account/LogIn");
             
                IWebElement loginElement = driver.FindElement(By.Name("UserName"));
                loginElement.SendKeys(loginText);

                IWebElement passElement = driver.FindElement(By.Name("Password"));
                passElement.SendKeys(passwordText);

                IWebElement sobmitElement = driver.FindElement(By.Name("submit"));
            
                sobmitElement.Click();

                driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            
                IWebElement loginResult = driver.FindElement(By.ClassName("login"));
             
                Assert.IsTrue(loginResult.Text.Contains(loginText));
            
                driver.Close();
            }
        }
    }
}
