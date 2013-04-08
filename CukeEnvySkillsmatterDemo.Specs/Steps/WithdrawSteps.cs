using TechTalk.SpecFlow;
using Driver = CukeEnvySkillsmatterDemo.Specs.Support.Driver_Domain;
//using Driver = CukeEnvySkillsmatterDemo.Specs.Support.Driver_FullStack_InMemory;
//using Driver = CukeEnvySkillsmatterDemo.Specs.Support.Driver_HTML;

namespace CukeEnvySkillsmatterDemo.Specs.Steps
{
    [Binding]
    public class WithdrawSteps
    {
        [Given(@"my account has a balance of \$(.*)")]
        public void a(int amount)
        {
            Driver.SetAccountBalance(amount);
        }

        [When(@"I withdraw \$(.*)")]
        public void b(int amount)
        {
            Driver.Withdraw(amount);
        }

        [Then(@"\$(.*) should be dispensed")]
        public void c(int amount)
        {
            Driver.AmountShouldBeInTheDispenser(amount);
        }

        [Then(@"the balance of my account should be \$(.*)")]
        public void d(int amount)
        {
            Driver.AccountBalanceShouldBe(amount);
        }

    }
}