using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoogleSearchTests
{
    class TestClass2
    {
        [Test]
        public void SearchListOfElements()
        {
            var driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://mta.ua/telefoni-ta-smartfoni");

            List<IWebElement> products = driver.FindElements(By.XPath
                ("//div[@class='products__item']//div[@class='products__item_caption']")).ToList();

            foreach (IWebElement product in products)
            {
                IWebElement productName = product.FindElement(By.XPath("./a"));
                string _productName = productName.Text;

                List<IWebElement> elementPricesList = product.FindElements(By.XPath
                    (".//div[contains(@class, 'products__item_price')]")).ToList();

                IWebElement correctPrice = null;

                foreach(var elementPrice in elementPricesList)
                {
                    string elementPriceClass = elementPrice.GetAttribute("class");

                    if (!elementPriceClass.Contains("old") &&
                        !elementPriceClass.Contains("wrapper"))
                    {
                        correctPrice = elementPrice;
                    }
                }

                if (correctPrice == null)
                {
                    throw new AssertionException($"There is no correct price for product {_productName}");
                }

                string _correctPrice = correctPrice.Text;

                Console.WriteLine($"Name of product - {_productName}");
                Console.WriteLine($"Price of product - {_correctPrice}");
            }
        }

        [Test]
        public void ClickAndSendKeys()
        {
            string mobileModel = "Apple";
            var driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://mta.ua/telefoni-ta-smartfoni");

            IWebElement txtFilterByManufacturer = driver.FindElement(By.XPath
                ("//*[text()='Виробники']/../following-sibling::div[@class='filter-category__search']//input"));

            txtFilterByManufacturer.SendKeys(mobileModel);
            System.Threading.Thread.Sleep(3000);

            IWebElement chkByMobileModel = driver.FindElement(By.XPath($"//span[text()='{mobileModel}']/parent::div"));
            chkByMobileModel.Click();
        }

        [Test]
        public void TestKeyClass()
        {
            var driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://mta.ua/telefoni-ta-smartfoni");

            IWebElement txtSearch = driver.FindElement(By.XPath("//input[@name='search']"));
            txtSearch.SendKeys("привіти");
            txtSearch.SendKeys(Keys.Backspace);
            txtSearch.SendKeys(Keys.Enter);

            txtSearch = driver.FindElement(By.XPath("//input[@name='search']"));
            txtSearch.SendKeys(Keys.Shift + "aAaAaA");
        }

        [Test]
        public void TestGetAttributeAndText()
        {
            var driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://mta.ua/telefoni-ta-smartfoni");

            IWebElement header = driver.FindElement(By.XPath("//h1"));
            string headerText = header.Text;
            Console.WriteLine($"Text is {headerText}");
            string headerClass = header.GetAttribute("class");
            Console.WriteLine($"Class is {headerClass}");

            driver.Close();
        }
    }
}
