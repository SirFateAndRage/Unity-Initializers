using System.Threading.Tasks;


namespace SFR.Initializers
{
    public class SincInitializer : Initializer
    {
        public override Task Initialize()
        {
            return Task.CompletedTask;
        }
    }

}