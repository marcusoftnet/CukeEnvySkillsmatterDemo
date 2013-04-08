using CukeEnvySkillsmatterDemo.Specs.Support.Builders;
using CukeEnvySkillsmatterDemo.Specs.Support.Wrappers;
using CukeEnvySkillsmatterDemo.Web.Models;
using NUnit.Framework;
using Simple.Data;

namespace CukeEnvySkillsmatterDemo.Specs.Support
{
    public class Driver_HTML
    {
        private dynamic _db = Database.Open();

        private readonly ATMPageWrapper _atmPageWrapper;
        private readonly AccountBuilder _accountBuilder;

        // Thanks to SpecFlow Context Injection feature 
        // (see https://github.com/techtalk/SpecFlow/wiki/Context-Injection)
        // We can declare our dependency of the page wrapper and the 
        // AccountBuilder right in our driver constructor
        public Driver_HTML(ATMPageWrapper atmPageWrapper, AccountBuilder accountBuilder)
        {
            _atmPageWrapper = atmPageWrapper;
            _accountBuilder = accountBuilder;
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
            // Call into the page wrapper for our account with defaults
            _atmPageWrapper.Withdraw(AccountBuilder.ACCOUNT_NO, 
                                    AccountBuilder.PIN_CODE,
                                    amount);
        }

        public void AmountShouldBeInTheDispenser(int expectedDispensedAmount)
        {
            // Check the values of the page wrapper for the dispensed amount recipt
            _atmPageWrapper.AssertDispensedAmount(expectedDispensedAmount);
        }

        public void AccountBalanceShouldBe(int expectedBalance)
        {
            // Check the account in the database for balance
            Account account = _db.Accounts.FindByNumber(AccountBuilder.ACCOUNT_NO);
            Assert.AreEqual(expectedBalance, account.Balance);
        }
    }
}