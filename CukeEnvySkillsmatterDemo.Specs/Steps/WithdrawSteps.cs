using TechTalk.SpecFlow;
using Driver = CukeEnvySkillsmatterDemo.Specs.Support.Driver_Domain;
//using Driver = CukeEnvySkillsmatterDemo.Specs.Support.Driver_FullStack_InMemory;
//using Driver = CukeEnvySkillsmatterDemo.Specs.Support.Driver_HTML;

namespace CukeEnvySkillsmatterDemo.Specs.Steps
{
    [Binding]
    public class WithdrawSteps
    {
        // We'll inject the driver (change version by uncommenting
        // lines in the using-part of this file)
        private readonly Driver _driver;
        public WithdrawSteps(Driver driver)
        {
            _driver = driver;
        }

        [Given(@"my account has a balance of \$(.*)")]
        public void a(int amount)
        {
            _driver.SetAccountBalance(amount);
        }

        [When(@"I withdraw \$(.*)")]
        public void b(int amount)
        {
            _driver.Withdraw(amount);
        }

        [Then(@"\$(.*) should be dispensed")]
        public void c(int amount)
        {
            _driver.AmountShouldBeInTheDispenser(amount);
        }

        [Then(@"the balance of my account should be \$(.*)")]
        public void d(int amount)
        {
            _driver.AccountBalanceShouldBe(amount);
        }
    }
}