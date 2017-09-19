using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

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

        [TestMethod]
        public void CashPaymentVoucherLinkCheck()
        {
            var CashPaymentVoucherLink = _driver.FindElement(By.XPath("/html/body/div[1]/div/my-app/div[1]/document-market/div/div[1]/div[2]/ul/li[2]/a"));

            var CashPaymentVoucherLinkText = CashPaymentVoucherLink.Text;

            CashPaymentVoucherLink.Click();

            _driver.Manage().Timeouts().ImplicitWait = (TimeSpan.FromSeconds(3));

            var CashPaymentVoucherTitle = _driver.FindElement(By.XPath("/html/body/div[1]/div/my-app/div[1]/ng-component/cash-payment-voucher/h4"));

            var CashReceiptTitleText = CashPaymentVoucherTitle.Text;

            Assert.AreEqual(CashReceiptTitleText, CashPaymentVoucherLinkText);
        }

        [TestMethod]
        public void CashPaymentVoucherAddNewDocument()
        {
            var CashPaymentVoucherLink = _driver.FindElement(By.XPath("/html/body/div[1]/div/my-app/div[1]/document-market/div/div[1]/div[2]/ul/li[2]/a"));

            CashPaymentVoucherLink.Click();

            _driver.Manage().Timeouts().ImplicitWait = (TimeSpan.FromSeconds(6));
             
            //Подождем когда прелоадер изчезнет
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(3));

            IWebElement AddNewListButton = wait.Until<IWebElement>((d) => 
            {
                var elem = d.FindElement(By.XPath("//*[@id='qa-table-controls']/div/documentactions/div/div/button"));
                if(elem.Displayed && elem.Enabled && elem.GetAttribute("aria-disabled") == null)
                {
                    return elem;
                }
                return null;
            });
            
            AddNewListButton.Click();

            var AddNewDocumentButton = _driver.FindElement(By.XPath("//*[@id=\"qa-table-controls\"]/div/documentactions/div/div/ul/li[1]/a"));

            AddNewDocumentButton.Click();

            _driver.Manage().Timeouts().ImplicitWait = (TimeSpan.FromSeconds(3));

            var DocumentNumberInput = _driver.FindElement(By.Id("DocumentNumber"));

            DocumentNumberInput.SendKeys("111");

            var entryDateInput = _driver.FindElement(By.Name("entryDate"));

            entryDateInput.SendKeys("11.11.2017");

            var SubmitButton = _driver.FindElement(By.XPath("/html/body/div[1]/div/my-app/div[1]/ng-component/cash-payment-voucher-detail/form/div[8]/div/div/div/div/button[1]"));

            SubmitButton.Click();

        }

        [TestCleanup]
        public void TestCleanup()
        {
            _driver.Close();
        }
    }
}
