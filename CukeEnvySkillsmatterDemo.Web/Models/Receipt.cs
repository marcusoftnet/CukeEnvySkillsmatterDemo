using System;

namespace CukeEnvySkillsmatterDemo.Web.Models
{
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