using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace GoogleSearchTests
{
    public class TestAsserts
    {
        IWebDriver driver;

        [Test]
        public void RegularAsserts()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://mta.ua");

            string textToInput = "ПРИВІТ";
            IWebElement txtSearch = driver.FindElement(By.XPath("//input[@name='search']"));
            txtSearch.SendKeys(textToInput);
            txtSearch.SendKeys(Keys.Enter);

            Thread.Sleep(2000);

            IWebElement results = driver.FindElement(By.TagName("h1"));
            string actualSearchText = results.Text.Split(' ')[^1];
            //Console.WriteLine("Text is: "+ actualSearchText);

            Assert.AreEqual(textToInput, actualSearchText, $"There is no search result {textToInput} on search results page");
            Assert.IsFalse(string.IsNullOrEmpty(actualSearchText), "Actual search result text is null or empty");
            Assert.IsTrue(driver.Url.Contains("search"), $"Url {driver.Url} does not contain search results");
        }

        [Test]
        public void StringAsserts()
        {
            StringAssert.Contains("tasha", "Natasha");
            StringAssert.DoesNotContain("tosha", "Natasha", "");
            StringAssert.AreEqualIgnoringCase("TASHA", "tasha");
            StringAssert.AreNotEqualIgnoringCase("ToSHA", "tasha");
            StringAssert.StartsWith("Na", "Natasha");
            StringAssert.DoesNotStartWith("M", "Natasha");
            StringAssert.EndsWith("a", "Natasha");
            StringAssert.DoesNotEndWith("o", "Natasha");
        }

        [Test]
        public void CollectionAsserts()
        {
            List<int?> intList = new List<int?> { 1, 5, 7, 9, 2 };
            List<int> intList2 = new List<int> { 1, 5, 7, 9, 2 };
            List<int> intList3 = new List<int> { 1, 5, 7, 9, 2, 3 };
            List<int> intList4 = new List<int> { 1, 5, 9, 7, 2 };
            List<int> intList5 = new List<int>();
            List<string> stringList = new List<string> { "a", "b", "c" };

            CollectionAssert.AreEqual(intList, intList2);
            CollectionAssert.AreNotEqual(intList, intList3);
            CollectionAssert.AreEquivalent(intList, intList4);
            CollectionAssert.AreNotEquivalent(intList2, intList3);
            CollectionAssert.Contains(intList3, 3);
            CollectionAssert.DoesNotContain(intList3, 4);
            CollectionAssert.AllItemsAreInstancesOfType(intList, typeof(int));
            CollectionAssert.AllItemsAreNotNull(intList);
            CollectionAssert.IsNotEmpty(intList);
            CollectionAssert.IsEmpty(intList5);
            CollectionAssert.AllItemsAreUnique(intList4);
            CollectionAssert.IsSubsetOf(intList2, intList3);
            CollectionAssert.IsSupersetOf(intList3, intList2);
            CollectionAssert.IsOrdered(stringList);
        }

        [Test]
        public void MultipleAsserts()
        {
            Assert.Multiple(() =>
            {
                StringAssert.Contains("tsha", "Natasha");
                StringAssert.DoesNotContain("tosha", "Natasha", "");
                StringAssert.AreEqualIgnoringCase("TASHA", "tasha");
                StringAssert.AreNotEqualIgnoringCase("ToSHA", "tasha");
                StringAssert.StartsWith("M", "Natasha");
                StringAssert.DoesNotStartWith("M", "Natasha");
                StringAssert.EndsWith("o", "Natasha");
                StringAssert.DoesNotEndWith("o", "Natasha");
            });
        }


        [TearDown]
        public void TearDown()
        {
            // driver.Close();
        }
    }
}
