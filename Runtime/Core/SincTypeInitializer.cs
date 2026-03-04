using System;
using System.Threading.Tasks;
using UnityEditor;


namespace SFR.Initializers
{
    public abstract class SincTypeInitializer<T> : SincInitializer
    {
        private T _parameter;

        public T Parameter { get => _parameter; }

        public override Task Initialize()
        {
            _parameter = GetParameter();

            if (_parameter is null)
                HandleNullParameter();

            return base.Initialize();
        }



        private void HandleNullParameter()
        {
            Selection.activeGameObject = this.gameObject;
            throw new Exception($"Initializer with name {gameObject.name} is null");
        }

        protected abstract T GetParameter();

        private void OnDestroy()
        {
            if (_parameter is not IDisposable)
                return;

            (_parameter as IDisposable).Dispose();
        }
    }
}