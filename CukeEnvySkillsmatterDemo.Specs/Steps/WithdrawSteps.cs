using TechTalk.SpecFlow;
//using DSL = CukeEnvySkillsmatterDemo.Specs.Support.DSL_Domain;
//using DSL = CukeEnvySkillsmatterDemo.Specs.Support.DSL_FullStack_InMemory;
using DSL = CukeEnvySkillsmatterDemo.Specs.Support.DSL_HTML;

namespace CukeEnvySkillsmatterDemo.Specs.Steps
{
    [Binding]
    public class WithdrawSteps
    {
        [Given(@"my account has a balance of \$(.*)")]
        [Given(@"my account has a balance of \$(.*)"), Scope()]
        public void a(int amount)
        {
            DSL.SetAccountBalance(amount);
        }

        public void a(int amount)
        {
            DSL.SetAccountBalance(amount);
        }

        [When(@"I withdraw \$(.*)")]
        public void b(int amount)
        {
            DSL.Withdraw(amount);
        }

        [Then(@"\$(.*) should be dispensed")]
        public void c(int amount)
        {
            DSL.AmountShouldBeInTheDispenser(amount);
        }

        [Then(@"the balance of my account should be \$(.*)")]
        public void d(int amount)
        {
            DSL.AccountBalanceShouldBe(amount);
        }

    }
}