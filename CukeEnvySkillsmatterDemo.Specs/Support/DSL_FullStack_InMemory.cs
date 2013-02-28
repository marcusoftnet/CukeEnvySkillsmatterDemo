using CukeEnvySkillsmatterDemo.Specs.Support.Wrappers;
using CukeEnvySkillsmatterDemo.Web.Models;
using NUnit.Framework;
using Simple.Data;

namespace CukeEnvySkillsmatterDemo.Specs.Support
{
    public class DSL_FullStack_InMemory
    {
        private const string ACCOUNT_NO = "123456-123";
        private const string PIN_CODE = "4321";

        private static InMemoryCashDispenser _inMemoryCashDispenser =
            new InMemoryCashDispenser();

        private static dynamic _db = Database.Open(); 
        
        public static void SetAccountBalance(int amount)
        {
            var account = new Account { Balance = amount,
                              Number = ACCOUNT_NO,
                              Pin = PIN_CODE };

            _db.Accounts.Insert(account);
        }

        public static void Withdraw(int amount)
        {
            // Create automator that posts to the web-site
            var bankModuleWrapper = new BankModuleWrapper(_inMemoryCashDispenser);
            bankModuleWrapper.Withdraw(ACCOUNT_NO, PIN_CODE, amount);
        }

        public static void AmountShouldBeInTheDispenser(int expectedDispensedAmount)
        {
            Assert.AreEqual(expectedDispensedAmount,
                _inMemoryCashDispenser.DispenserContents);
        }

        public static void AccountBalanceShouldBe(int expectedBalance)
        {
            // Check the account in the database for balance
            Account account = _db.Accounts.FindByNumber(ACCOUNT_NO);
            Assert.AreEqual(expectedBalance, account.Balance);
        }
    }
}