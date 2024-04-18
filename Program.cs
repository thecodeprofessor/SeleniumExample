using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using System.Reflection.Metadata;

namespace SeleniumExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Test_1_MyCambrianLogin_ValidUsername_NoPassword();
        }

        static void Test_1_MyCambrianLogin_ValidUsername_NoPassword()
        {
            var driver = new EdgeDriver();
            try
            {
                driver.Url = "https://mycambrian.cambriancollege.ca/";

                Console.Clear();

                var loginForm = driver.FindElement(By.Id("fm1"));


                var usernameTextBox = driver.FindElement(By.Id("username"));
                usernameTextBox.SendKeys("A0011223");

                var passwordTextBox = driver.FindElement(By.Id("password"));
                passwordTextBox.Clear();

                loginForm.Submit();

                Thread.Sleep(2000);
                var errorPanel = driver.FindElement(By.ClassName("errors"));

                var errorMessageExpected = "Password is a required field.";
                var errorMessageShown = errorPanel.Text;

                if (errorMessageShown == errorMessageExpected)
                {
                    Console.WriteLine("Test MyCambrianLogin_ValidUsername_NoPassword: PASS");
                }
                else
                {
                    Console.WriteLine("Test MyCambrianLogin_ValidUsername_NoPassword: FAIL");
                }
            }
            finally
            {
                driver.Quit();
            }
        }
    }
}
