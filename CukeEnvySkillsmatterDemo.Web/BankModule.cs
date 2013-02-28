using CukeEnvySkillsmatterDemo.Web.Models;
using Nancy;

namespace CukeEnvySkillsmatterDemo.Web
{
    public class BankModule : NancyModule
    {
        public BankModule(TellerService tellerService)
        {
            Post["/withdraw"] = _ =>
                    {
                        string accountNo = Request.Form.AccountNo;
                        string pin = Request.Form.Pin;
                        int amount = Request.Form.Amount;

                        // Authenticate
                        tellerService.Authenticate(accountNo, pin);
                        tellerService.Withdraw(accountNo, amount);
                        
                        return HttpStatusCode.Accepted;
                    };

            Get["/withdraw"] = _ => { return View["ATM"]; };
        }
    }
}