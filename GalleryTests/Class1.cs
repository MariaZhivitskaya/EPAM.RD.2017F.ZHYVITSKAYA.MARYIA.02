using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace GalleryTests
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void JsTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http");
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.Manage().Window.Maximize();

            var quest = driver.FindElement(By.Id("GoToAdd"));
        }
        
        //private void Register()
        //{
        //    var testUserName = $"test-username{Random.Next()}";
        //    var password = "1";


        //}
    }
}
