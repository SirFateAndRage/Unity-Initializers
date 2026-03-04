namespace SFR.Initializers
{
    public class InitializeOnStart : InitializerGroup
    {
        private async void Start() => await Initialize();
    }
}