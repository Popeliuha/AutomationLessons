using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace GoogleSearchTests
{
    public class GoogleSearchClass
    {
        [Test]
        public void GoogleSearch()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://google.com");
            driver.Manage().Window.Maximize();

            IWebElement txtSearch = driver.FindElement(By.Name("q"));
            txtSearch.SendKeys("Youtube");
            txtSearch.SendKeys(Keys.Enter);

            IWebElement btnUkrainianYouTube = driver.FindElement(By.XPath("//a[@href='https://www.youtube.com/?hl=uk&gl=UA']"));
            btnUkrainianYouTube.Click();
        }
    }
}
