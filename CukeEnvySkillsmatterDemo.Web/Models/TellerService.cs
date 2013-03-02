using System;

namespace CukeEnvySkillsmatterDemo.Web.Models
{
    public class TellerService
    {
        private Account _account;
        private IAccountRepository _accountRepository;
        private ICashDispenser _dispenser;

        public TellerService(IAccountRepository accountRepository, ICashDispenser dispenser)
        {
            _accountRepository = accountRepository;
            _dispenser = dispenser;
        }

        public void Authenticate(string number, string pin)
        {
            // Rock-solid-validation technique
            // I know
            _account = _accountRepository.GetForLogin(number, pin);
        }

        public Receipt Withdraw(string number, int amount)
        {
            _account.Balance -= amount;
            _accountRepository.Update(_account);
            _dispenser.Dispense(amount);

            return new Receipt(amount);
        }
    }

    public class Receipt
    {
        public Guid Id { get; set; }
        public int DispensedAmount { get; set; }

        public Receipt()
        {
            Id = Guid.NewGuid();
        }

        public Receipt(int dispensedAmount)
        {
            Id = Guid.NewGuid();
            DispensedAmount = dispensedAmount;
        }
    }
}