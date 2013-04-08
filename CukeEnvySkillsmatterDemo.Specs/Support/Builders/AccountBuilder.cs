using CukeEnvySkillsmatterDemo.Web.Models;

namespace CukeEnvySkillsmatterDemo.Specs.Support.Builders
{
    public class AccountBuilder
    {
        public const string ACCOUNT_NO = "123456-123";
        public const string PIN_CODE = "4321";

        private string _number = ACCOUNT_NO;
        private string _pin = PIN_CODE;
        private int _balance;

        public AccountBuilder WithNumber(string number)
        {
            _number = number;
            return this;
        }

        public AccountBuilder WithPin(string pin)
        {
            _pin = pin;
            return this;
        }

        public AccountBuilder WithBalance(int balance)
        {
            _balance = balance;
            return this;
        }

        public Account Build()
        {
            return new Account { Number = _number, Pin = _pin, Balance = _balance };
        }
    }
}
