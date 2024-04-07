namespace SFR.Initializers
{
    public class InitializeOnAwake : InitializerGroup
    {
        private void Awake() => Initialize();
    }
}