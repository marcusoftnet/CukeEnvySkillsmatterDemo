using Simple.Data;
using TechTalk.SpecFlow;

namespace CukeEnvySkillsmatterDemo.Specs.Support
{
    [Binding]
    public class Hooks
    {
        [BeforeTestRun]
        public static void BeforeAnyFeature()
        {
            // FOR DSL_INMEMORY ONLY
            // Database.UseMockAdapter(new InMemoryAdapter());            
        }

        [BeforeScenario]
        public void BeforeEveryScenario()
        {
            // FOR INMEMORY & HTML
            Database.Open().Accounts.DeleteAll();
        }
    }
}
