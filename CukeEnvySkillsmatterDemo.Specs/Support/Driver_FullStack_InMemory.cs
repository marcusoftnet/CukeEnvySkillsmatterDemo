using CukeEnvySkillsmatterDemo.Specs.Support.Builders;
using CukeEnvySkillsmatterDemo.Specs.Support.Wrappers;
using CukeEnvySkillsmatterDemo.Web.Models;
using NUnit.Framework;
using Simple.Data;

namespace CukeEnvySkillsmatterDemo.Specs.Support
{
    public class Driver_FullStack_InMemory
    {
        private ICashDispenser _cashDispenser;
        private readonly AccountBuilder _accountBuilder;
        private readonly BankModuleWrapper _bankModuleWrapper;
        private dynamic _db = Database.Open();

        // Thanks to SpecFlow Context Injection feature 
        // (see https://github.com/techtalk/SpecFlow/wiki/Context-Injection)
        // We can declare our dependency of the inmemory cashdispenser and the 
        // AccountBuilder right in our driver constructor
        public Driver_FullStack_InMemory(InMemoryCashDispenser cashDispenser, AccountBuilder accountBuilder)
        {
            _cashDispenser = cashDispenser;
            _accountBuilder = accountBuilder;

            // We can now create our NancyModule-wrapper that we'll
            // use to test in memory
            _bankModuleWrapper = new BankModuleWrapper(_cashDispenser);
        }

        public void SetAccountBalance(int amount)
        {
            // Build our test account. Here we only care about the amount
            // and can use the defaults for the rest of the properties
            var account = _accountBuilder
                                .WithBalance(amount)
                                .Build();

            _db.Accounts.Insert(account);
        }

        public void Withdraw(int amount)
        {
            // Create automator that posts to the web-site
            _bankModuleWrapper.Withdraw(AccountBuilder.ACCOUNT_NO, 
                                        AccountBuilder.PIN_CODE, 
                                        amount);
        }

        public void AmountShouldBeInTheDispenser(int expectedDispensedAmount)
        {
            // Check our InMemoryCashDispeser for the dispesed amount
            Assert.AreEqual(expectedDispensedAmount, _cashDispenser.DispenserContents);
        }

        public void AccountBalanceShouldBe(int expectedBalance)
        {
            // Check the account in the database for balance
            Account account = _db.Accounts.FindByNumber(AccountBuilder.ACCOUNT_NO);
            Assert.AreEqual(expectedBalance, account.Balance);
        }
    }
}