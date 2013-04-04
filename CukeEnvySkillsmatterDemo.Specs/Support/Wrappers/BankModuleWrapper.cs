using CukeEnvySkillsmatterDemo.Web;
using CukeEnvySkillsmatterDemo.Web.Models;
using Nancy;
using Nancy.Testing;
using NUnit.Framework;

namespace CukeEnvySkillsmatterDemo.Specs.Support.Wrappers
{
    public class BankModuleWrapper
    {
        private Browser _browser;

        public BankModuleWrapper(ICashDispenser cashDispenser)
        {
            _browser = new Browser(with =>
                {
                    with.Module<BankModule>();
                    with.Dependency<IAccountRepository>(new SQLServerAccountRepository());
                    with.Dependency<ICashDispenser>(cashDispenser);
                });
        }

        public void Withdraw(string accountNo, string pinCode, int amount)
        {
            // Post a HTTP form to our module
            var response = _browser.Post("/withdraw", with =>
                    {
                        with.FormValue("accountNo", accountNo);
                        with.FormValue("pin", pinCode);
                        with.FormValue("amount", amount.ToString());
                    });

            // Make sure that we've got an Accepted back
            Assert.AreEqual(HttpStatusCode.Accepted, response.StatusCode);

            // We could even assert against the view
            //response.Body[".dispensedAmount"].ShouldContain(amount.ToString());
        }
    }
}