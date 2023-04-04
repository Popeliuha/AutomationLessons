using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace GoogleSearchTests
{
    public class FramesTest
    {
        IWebDriver driver;

        [Test]
        public void InheritedFrameTest()
        {
            try
            {
                driver = new ChromeDriver();
                driver.Navigate().GoToUrl("https://demoqa.com/nestedframes");

                var iframes = driver.FindElements(By.TagName("iframe"));
                IWebElement parentFrame = driver.FindElement(By.XPath("//*[@id='frame1']"));
                driver.SwitchTo().Frame(parentFrame);
                var element = driver.FindElement(By.TagName("body"));
                Console.WriteLine(element.Text);
                iframes = driver.FindElements(By.TagName("iframe"));
                driver.SwitchTo().Frame(0);
                Thread.Sleep(1000);
                var childElement = driver.FindElement(By.TagName("p"));
                Console.WriteLine(childElement.Text);
                driver.SwitchTo().ParentFrame();
                element = driver.FindElement(By.TagName("body"));
                Console.WriteLine(element.Text);
            }
            catch (Exception)
            {

            }
            finally
            {
                driver.Quit();
            }
        }

        [Test]
        public void FrameTest()
        {
            try
            {
                driver = new ChromeDriver();
                driver.Navigate().GoToUrl("https://demoqa.com/frames");

                var iframes = driver.FindElements(By.TagName("iframe"));
                IWebElement bigFrame = driver.FindElement(By.XPath("//*[@id='frame1']"));
                driver.SwitchTo().Frame(bigFrame);
                var element = driver.FindElement(By.XPath("//h1[@id='sampleHeading']"));
                Console.WriteLine(element.Text);
                driver.SwitchTo().DefaultContent();
                Thread.Sleep(1000);
                var outOfFrameEl = driver.FindElement(By.XPath("//*[@id='framesWrapper']/div"));
                Console.WriteLine(outOfFrameEl.Text);
            }
            catch (Exception)
            {

            }
            finally
            {
                driver.Quit();
            }
        }
    }
}
