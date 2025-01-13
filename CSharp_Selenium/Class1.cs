using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Interactions;
using System;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;

namespace CSharp_Selenium
{
    [TestClass]
    public class Class1
    {
        [TestMethod]
        public void TestMethod1()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://www.lambdatest.com/selenium-playground";
            driver.FindElement(By.XPath("//a[normalize-space()='Drag & Drop Sliders']")).Click();
            driver.FindElement(By.XPath("//input[@value='15']")).Click();

            /*WebElement drag1 = (WebElement)driver.FindElement(By.XPath("//input[@value='15']"));
            Actions action = new Actions(driver);
            action.DragAndDropToOffset(drag1, 15, 95).Perform();*/
            IWebElement slider = driver.FindElement(By.XPath("//input[@value='15']"));
            IWebElement rangeOutput = driver.FindElement(By.Id("range"));

            // Step 4: Drag the slider to set its value to 95
            Actions action = new Actions(driver);
            int targetValue = 95;
            int currentValue = int.Parse(rangeOutput.Text);

            // Calculate the number of steps required to reach the target value
            int steps = targetValue - currentValue;

            // Drag the slider using keyboard simulation (step by step)
            for (int i = 0; i < steps; i++)
            {
                action.ClickAndHold(slider).MoveByOffset(5, 0).Release().Perform();
            }

            // Validate that the range value shows 95
            string finalValue = rangeOutput.Text;
            if (finalValue == targetValue.ToString())
            {
                Console.WriteLine("Slider value successfully set to 95. Test Passed!");
            }
            else
            {
                Console.WriteLine("Failed to set slider value to 95. Test Failed!");
            }


            driver.Close();
        }


    }
}
