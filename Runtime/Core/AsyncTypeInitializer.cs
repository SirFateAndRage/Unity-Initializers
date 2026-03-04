using System;
using System.Threading.Tasks;
using UnityEditor;


namespace SFR.Initializers
{
    public abstract class AsyncTypeInitializer<T> : Initializer
    {
        private T _parameter;

        public T Parameter {get => _parameter;}

        public override async Task Initialize()
        {
            _parameter = await GetParameter();

            if (_parameter is null)
                HandleNullParameter();
        }

        internal abstract Task<T> GetParameter();

        private void HandleNullParameter()
        {
            Selection.activeGameObject = this.gameObject;
            throw new Exception($"Initializer with name {gameObject.name} is null");
        }

        private void OnDestroy()
        {
            if (_parameter is not IDisposable)
                return;

            (_parameter as IDisposable).Dispose();
        }
    }
}