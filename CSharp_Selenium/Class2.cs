using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace CSharp_Selenium
{
    [TestClass]
    public class Class2
    {
        [TestMethod]
        public void TestMethod1()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://www.lambdatest.com/selenium-playground";

            // Step 2: Click “Input Form Submit”

            driver.FindElement(By.XPath("//a[normalize-space()='Input Form Submit']")).Click();

            // Step 3: Click “Submit” without filling in the form

            driver.FindElement(By.XPath("//button[normalize-space()='Submit']")).Click();

            // Assert error message "Please fill out this field."

            IWebElement firstNameField = driver.FindElement(By.Name("name"));
            string validationMessage = firstNameField.GetAttribute("validationMessage");
            if (validationMessage == "Please fill out this field.")
            {
                Console.WriteLine("Validation message displayed correctly. Test Passed!");
            }
            else
            {
                Console.WriteLine("Validation message not displayed correctly. Test Failed!");
            }

            // Step 4: Fill in Name, Email, and other fields

            driver.FindElement(By.Name("name")).SendKeys("Muhammad Hassan");
            driver.FindElement(By.XPath("//input[@id='inputEmail4']")).SendKeys("Hassan.meh@example.com");
            driver.FindElement(By.Name("password")).SendKeys("hassan1234");
            driver.FindElement(By.Name("company")).SendKeys("company");
            driver.FindElement(By.Name("website")).SendKeys("https://example.com");
            var select = driver.FindElement(By.XPath("//select[@name='country']"));
            var selectDropDown = new SelectElement(select);
            selectDropDown.SelectByText("United States");
            driver.FindElement(By.Name("city")).SendKeys("Karachi");
            driver.FindElement(By.Name("address_line1")).SendKeys("123 Main Street");
            driver.FindElement(By.Name("address_line2")).SendKeys("155 Main Street");
            driver.FindElement(By.Name("zip")).SendKeys("10001");
            driver.FindElement(By.XPath("//input[@id='inputState']")).SendKeys("Asia");
            driver.FindElement(By.XPath("//button[normalize-space()='Submit']")).Click();

            string msg = driver.FindElement(By.XPath("//p[@class='success-msg hidden']")).Text;
            Assert.AreEqual("Thanks for contacting us, we will get back to you shortly.", msg);

            driver.Close();




        }
    }
}
