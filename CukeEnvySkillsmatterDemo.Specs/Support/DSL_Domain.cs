using CukeEnvySkillsmatterDemo.Web.Models;
using NSubstitute;
using NUnit.Framework;

namespace CukeEnvySkillsmatterDemo.Specs.Support
{
    public static class DSL_Domain
    {
        private const string ACCOUNT_NO = "123456-123";
        private const string PIN_CODE = "4321";

        private static Account _account =
            new Account { Number = ACCOUNT_NO, Pin = PIN_CODE };

            private static ICashDispenser _cashDispenser =
                new InMemoryCashDispenser();

        private static IAccountRepository _mockAccountRepository =
            Substitute.For<IAccountRepository>();

        public static void SetAccountBalance(int amount)
        {
            _account.Balance = amount;
        }

        // This is the method that actually does the automations
        public static void Withdraw(int amount)
        {
            // Set up mock
            _mockAccountRepository
                .GetForLogin(ACCOUNT_NO, PIN_CODE)
                .Returns(_account);

            // Create the teller service
            var teller = new TellerService(
                            _mockAccountRepository,
                            _cashDispenser);

            // Authenicate and withdraw
            teller.Authenticate(_account.Number, _account.Pin);
            teller.Withdraw(_account.Number, amount);
        }

        public static void AmountShouldBeInTheDispenser(int expectedAmount)
        {
            Assert.AreEqual(
                expectedAmount,
                _cashDispenser.DispenserContents);
        }

        public static void AccountBalanceShouldBe(int expectedBalance)
        {
            Assert.AreEqual(
                expectedBalance,
                _account.Balance);
        }
    }
}
