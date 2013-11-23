using FluentAutomation;

namespace CukeEnvySkillsmatterDemo.Specs.Support.Wrappers
{
    public class ATMPageWrapper : FluentTest
    {
        private const string BASE_URL = "http://localhost:3179";

        public ATMPageWrapper()
        {
            SeleniumWebDriver.Bootstrap(SeleniumWebDriver.Browser.Chrome);
            Settings.ScreenshotPath = @"C:\temp\results";
        }

        public void Withdraw(string accountNo, string pinCode, int amount)
        {
            //I.TakeScreenshot("Start");

            // Fill out the ATM-form
            I.Open(BASE_URL + "/withdraw");
            I.Enter(accountNo).In("input#accountNo");
            I.Enter(pinCode).In("#pin");
            I.Enter(amount).In(".amountField");

            I.Click("#withdraw");
        }

        public void AssertDispensedAmount(int expectedDispensedAmount)
        {
            I.Expect
                .Text(expectedDispensedAmount.ToString())
                .In(".dispensedAmount");

            I.Expect
                .Text("We promise!")
                .In(".assurance");

            //I.TakeScreenshot("Result");

        }
    }
}