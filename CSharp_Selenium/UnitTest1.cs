using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using System;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;

namespace CSharp_Selenium
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Test Scenario 1:
            // Step 1: Initialize WebDriver and open the Selenium Playground

            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://www.lambdatest.com/selenium-playground";

            // Step 2: Click “Simple Form Demo”

            driver.FindElement(By.XPath("//a[normalize-space()='Simple Form Demo']")).Click();

            // Step 3: Validate that the URL contains “simple-form-demo”

            string currentUrl = driver.Url;
            if (currentUrl.Contains("simple-form-demo"))
            {
                Console.WriteLine("URL validation passed.");
            }
            else
            {
                Console.WriteLine("URL validation failed.");
            }

            // Step 4: Create a variable for the string value

            string message = "Welcome to LambdaTest";

            // Step 5: Enter the string in the “Enter Message” text box

            driver.FindElement(By.XPath("//input[@id='user-message']")).SendKeys(message);

            // Step 6: Click “Get Checked Value”

            driver.FindElement(By.XPath("//button[@id='showInput']")).Click();

            // Step 7: Validate whether the same text message is displayed

            string Message = driver.FindElement(By.Id("message")).Text;
            Assert.AreEqual(message, Message);

            //just for console print that the assertion is passed otherwise no need of that code.
            string displayedMessage = driver.FindElement(By.Id("message")).Text;

            if (displayedMessage == message)
            {
                Console.WriteLine("Message validation passed.");
            }
            else
            {
                Console.WriteLine("Message validation failed.");
            }

           





            driver.Close();
        }
    }
}
