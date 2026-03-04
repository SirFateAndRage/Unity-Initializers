namespace SFR.Initializers
{
    public class InitializeOnAwake : InitializerGroup
    {
        private async void Awake() => await Initialize();
    }
}