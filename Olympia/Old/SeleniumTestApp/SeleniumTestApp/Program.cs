using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumTestApp
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Please enter your search text:");
            var searchText = Console.ReadLine();

            try
            {
                new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                FirefoxDriver fireFox = new FirefoxDriver();
                fireFox.Navigate().GoToUrl("https://www.google.com/");

                Thread.Sleep(2000);

                var searchBox = fireFox.FindElement(By.Name("q"));
                searchBox.SendKeys(searchText);

                Thread.Sleep(2000);

                IWebElement submitButton = fireFox.FindElement(By.Name("btnK"));
                Actions act = new Actions(fireFox);
                act.MoveToElement(submitButton).Click().Perform();

                Console.WriteLine("The html on this page is :");
                Console.WriteLine(fireFox.PageSource);

                fireFox.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("The following Error Occured:");
                Console.WriteLine(e);
                throw;
            }

            
        }
    }
}
