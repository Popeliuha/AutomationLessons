using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoogleSearchTests
{
    class NavigationTest
    {
        IWebDriver driver;

        [Test]
        public void TestAlerts()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demoqa.com/alerts");
            var alertButton = driver.FindElement(By.Id("alertButton"));
            var confirmButton = driver.FindElement(By.Id("confirmButton"));
            var promtButton = driver.FindElement(By.Id("promtButton"));

            alertButton.Click();
            var alert = driver.SwitchTo().Alert();
            alert.Accept();

            confirmButton.Click();
            driver.SwitchTo().Alert().Dismiss();

            promtButton.Click();
            var text = driver.SwitchTo().Alert().Text;
            driver.SwitchTo().Alert().SendKeys("hello");
            driver.SwitchTo().Alert().Accept();
        }

        [Test]
        public void TestNavigationBewteenWindows()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demoqa.com/browser-windows");
            var windowButtonWrapper = driver.FindElement(By.Id("windowButtonWrapper"));
            string parentWindowHandle = driver.CurrentWindowHandle;
            windowButtonWrapper.Click();
            var allWindowHandles = driver.WindowHandles.ToList();
            string secondWindow = allWindowHandles.Where(x => x != parentWindowHandle).Select(x => x).FirstOrDefault();
            driver.SwitchTo().Window(secondWindow);
            var sampleHeading = driver.FindElement(By.Id("sampleHeading"));
            Console.WriteLine(sampleHeading.Text);
            driver.SwitchTo().Window(parentWindowHandle);
        }

        [Test]
        public void TestNavigationBewteenTabsAndCloseAllTabs()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demoqa.com/browser-windows");
            var tabButton = driver.FindElement(By.Id("tabButton"));
            string parentWindowHandle = driver.CurrentWindowHandle;
            tabButton.Click();
            var allWindowHandles = driver.WindowHandles.ToList();
            string secondWindow = allWindowHandles.Where(x => x != parentWindowHandle).Select(x => x).FirstOrDefault();
            driver.SwitchTo().Window(secondWindow);
            var sampleHeading = driver.FindElement(By.Id("sampleHeading"));
            Console.WriteLine(sampleHeading.Text);
            driver.Quit();
        }

        [Test]
        public void TestNavigationBewteenTabsAndCloseOneTab()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demoqa.com/browser-windows");
            var tabButton = driver.FindElement(By.Id("tabButton"));
            string parentWindowHandle = driver.CurrentWindowHandle;
            tabButton.Click();
            var allWindowHandles = driver.WindowHandles.ToList();
            string secondWindow = allWindowHandles.Where(x => x != parentWindowHandle).Select(x => x).FirstOrDefault();
            driver.SwitchTo().Window(secondWindow);
            var sampleHeading = driver.FindElement(By.Id("sampleHeading"));
            Console.WriteLine(sampleHeading.Text);
            driver.Close();
            driver.SwitchTo().Window(parentWindowHandle);
        }

        [Test]
        public void TestInterrogation()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.amazon.com/");
            
            string pageSource = driver.PageSource;
            string title = driver.Title;
            string url = driver.Url;

            driver.SwitchTo().NewWindow(WindowType.Tab);
            string currentWindowHandle = driver.CurrentWindowHandle;
            var allWindowHandles = driver.WindowHandles;
            driver.SwitchTo().Window(allWindowHandles[0]);
        }

        [Test]
        public void TestNavigation()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.amazon.com/");
            driver.Navigate().GoToUrl("https://www.google.com/");
            driver.Navigate().Back();
            driver.Navigate().Forward();
            driver.Navigate().Refresh();
        }
    }
}
