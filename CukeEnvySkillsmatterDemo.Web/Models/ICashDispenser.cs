namespace CukeEnvySkillsmatterDemo.Web.Models
{
    public interface ICashDispenser
    {
        void Dispense(int amount);
        int DispenserContents { get; }
    }

    public class InMemoryCashDispenser : ICashDispenser
    {
        public int DispenserContents { get; private set; }

        public void Dispense(int amount)
        {
            DispenserContents = amount;
        }
    }
}