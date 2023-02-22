using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GoogleSearchTests
{
    public class TestClass3
    {
        [Test]
        public void TestRadioButton()
        {
            var driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://ultimateqa.com/simple-html-elements-for-automation");

            IWebElement rdoOther = driver.FindElement(By.XPath("//input[@value = 'other']"));
            IWebElement rdoMale = driver.FindElement(By.XPath("//input[@value = 'male']"));
            IWebElement rdoFemale = driver.FindElement(By.XPath("//input[@value = 'female']"));

            rdoFemale.Click();
            bool isFemaleSelected = rdoFemale.Selected;
            bool isMaleSelected = rdoMale.Selected;
            bool isOtherSelected = rdoOther.Selected;

            Console.WriteLine("Female:" + isFemaleSelected);
            Console.WriteLine("Male:" + isMaleSelected);
            Console.WriteLine("Other:" + isOtherSelected);
            Console.WriteLine("++++++++++++++++++++++++");

            rdoMale.Click();

            isFemaleSelected = rdoFemale.Selected;
            isMaleSelected = rdoMale.Selected;
            isOtherSelected = rdoOther.Selected;

            Console.WriteLine("Female:" + isFemaleSelected);
            Console.WriteLine("Male:" + isMaleSelected);
            Console.WriteLine("Other:" + isOtherSelected);
            Console.WriteLine("++++++++++++++++++++++++");

            bool isMaleDisplayed = rdoMale.Displayed;
            bool isMaleEnabled = rdoMale.Enabled;

            Console.WriteLine("Is male displayed:" + isMaleDisplayed);
            Console.WriteLine("Is male enabled:" + isMaleEnabled);

            driver.Close();
        }

        [Test]
        public void TestCheckbox()
        {
            var driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://ultimateqa.com/simple-html-elements-for-automation");

            IWebElement chkCar = driver.FindElement(By.XPath("//input[@value = 'Car']"));
            IWebElement chkBike = driver.FindElement(By.XPath("//input[@value = 'Bike']"));

            bool isCarChecked = chkCar.Selected;
            bool isBikeChecked = chkBike.Selected;

            Console.WriteLine("Car is checked:" +isCarChecked);
            Console.WriteLine("Bike is checked:" + isBikeChecked);
            Console.WriteLine("===========================");

            chkBike.Click();
            chkCar.Click();

            isCarChecked = chkCar.Selected;
            isBikeChecked = chkBike.Selected;

            Console.WriteLine("Car is checked:" + isCarChecked);
            Console.WriteLine("Bike is checked:" + isBikeChecked);
        }

        [Test]
        public void TestDropdown()
        {
            var driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://ultimateqa.com/simple-html-elements-for-automation");

            IWebElement ddlVehicles = driver.FindElement(By.TagName("select"));
            SelectElement _ddlVehicles = new SelectElement(ddlVehicles);

            var allselectedOptions = _ddlVehicles.AllSelectedOptions.ToList();
            allselectedOptions.ForEach(x => Console.WriteLine("All selected options:" + x.Text));

            bool isMultiple = _ddlVehicles.IsMultiple;
            Console.WriteLine("Is multiple:" + isMultiple);

            var optionsList = _ddlVehicles.Options.ToList();
            optionsList.ForEach(x => Console.WriteLine("Options List:" + x.Text));

            var wrappedElement = _ddlVehicles.WrappedElement;
            Console.WriteLine(wrappedElement);
            Console.WriteLine(wrappedElement.Text);
            Console.WriteLine(wrappedElement.TagName);

            _ddlVehicles.SelectByText("Volvo");
            var selectedOption = _ddlVehicles.SelectedOption.Text;
            Console.WriteLine("First selected option:" + selectedOption);

            _ddlVehicles.SelectByValue("saab");
            selectedOption = _ddlVehicles.SelectedOption.Text;
            Console.WriteLine("Second selected option:" + selectedOption);

            _ddlVehicles.SelectByIndex(0);
            selectedOption = _ddlVehicles.SelectedOption.Text;
            Console.WriteLine("0 selected option:" + selectedOption);
            _ddlVehicles.SelectByIndex(1);
            selectedOption = _ddlVehicles.SelectedOption.Text;
            Console.WriteLine("1 selected option:" + selectedOption);
            _ddlVehicles.SelectByIndex(2);
            selectedOption = _ddlVehicles.SelectedOption.Text;
            Console.WriteLine("2 selected option:" + selectedOption); 
            _ddlVehicles.SelectByIndex(3);
            selectedOption = _ddlVehicles.SelectedOption.Text;
            Console.WriteLine("3 selected option:" + selectedOption);
            driver.Close();
        }

        [Test]
        public void TestUL()
        {
            var driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://ultimateqa.com/simple-html-elements-for-automation");

            IWebElement liTab1 = driver.FindElement(By.XPath("//li[contains(@class,'et_pb_tab_0')]"));
            IWebElement liTab2 = driver.FindElement(By.XPath("//li[contains(@class,'et_pb_tab_1')]"));
            IWebElement displayedOption = driver.FindElement(By.XPath("//div[not(contains(@style, 'none'))]/div[@class='et_pb_tab_content']"));

            Console.WriteLine("Displayed option " + displayedOption.Text);

            liTab2. Click();
            Thread.Sleep(10000);
            displayedOption = driver.FindElement(By.XPath("//div[not(contains(@style, 'none'))]/div[@class='et_pb_tab_content']"));
            Console.WriteLine("Displayed option " + displayedOption.Text);

            liTab1.Click();
            Thread.Sleep(10000);
            displayedOption = driver.FindElement(By.XPath("//div[not(contains(@style, 'none'))]/div[@class='et_pb_tab_content']"));
            Console.WriteLine("Displayed option " + displayedOption.Text);

            driver.Close();
        }
    }
}
