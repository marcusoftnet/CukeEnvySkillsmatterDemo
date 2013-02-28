using Simple.Data;

namespace CukeEnvySkillsmatterDemo.Web.Models
{
    public interface IAccountRepository
    {
        Account GetForLogin(string number, string pin);
        void Update(Account account);
    }

    public class SQLServerAccountRepository : IAccountRepository
    {
        private dynamic _db;

        public SQLServerAccountRepository()
        {
            _db = Database.Open();
        }

        public void Update(Account account)
        {
            _db.Accounts.UpdateByNumber(account);
        }

        public Account GetForLogin(string number, string pin)
        {
            return _db.Accounts.FindByNumberAndPin(number, pin);
        }
    }
}