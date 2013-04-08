using CukeEnvySkillsmatterDemo.Specs.Support.Builders;
using CukeEnvySkillsmatterDemo.Web.Models;
using NSubstitute;
using NUnit.Framework;

namespace CukeEnvySkillsmatterDemo.Specs.Support
{
    public class Driver_Domain
    {
        private IAccountRepository _mockAccountRepository = Substitute.For<IAccountRepository>();
        private Account _account;
        
        
        private readonly AccountBuilder _accountBuilder;
        private ICashDispenser _cashDispenser = new InMemoryCashDispenser();

        // Thanks to SpecFlow Context Injection feature 
        // (see https://github.com/techtalk/SpecFlow/wiki/Context-Injection)
        // We can declare our dependency of the inmemory cashdispenser and the 
        // AccountBuilder right in our driver constructor
        public Driver_Domain(InMemoryCashDispenser cashDispenser, AccountBuilder accountBuilder)
        {
            _cashDispenser = cashDispenser;
            _accountBuilder = accountBuilder;
        }
        
        public void SetAccountBalance(int amount)
        {
            // Set up the account in the correct state
            _account = _accountBuilder.WithBalance(amount).Build();
        }

        // This is the method that actually does the automations
        public void Withdraw(int amount)
        {
            // Set up mock
            _mockAccountRepository
                .GetForLogin(AccountBuilder.ACCOUNT_NO, AccountBuilder.PIN_CODE)
                .Returns(_account);

            // Create the teller service
            var teller = new TellerService(_mockAccountRepository, _cashDispenser);

            // Authenicate and withdraw
            // In this case we're keeping track of the workflow
            // here in the test code
            // This would later move to a controller or other workflow manager
            teller.Authenticate(_account.Number, _account.Pin);
            teller.Withdraw(_account.Number, amount);
        }

        public void AmountShouldBeInTheDispenser(int expectedAmount)
        {
            // Assert that the inmemory cash dispenser contains the cash
            Assert.AreEqual(expectedAmount, _cashDispenser.DispenserContents);
        }

        public void AccountBalanceShouldBe(int expectedBalance)
        {
            // Assert that the amount is correct on the account
            Assert.AreEqual(expectedBalance, _account.Balance);
        }
    }
}
