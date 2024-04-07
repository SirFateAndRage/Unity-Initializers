using System;
using UnityEditor;


namespace SFR.Initializers
{
    public abstract class TypeInitializer<T> : Initializer
    {
        private T _parameter;

        public T Parameter { get => _parameter; }

        public override void Initialize()
        {
            _parameter = GetParameter();

            if (_parameter is null)
                HandleNullParameter();
        }

        private void HandleNullParameter()
        {
            Selection.activeGameObject = this.gameObject;
            throw new Exception($"Initializer with name {gameObject.name} is null");
        }

        protected abstract T GetParameter();

        private void OnDestroy()
        {
            if (!(_parameter is IDisposable))
                return;

            (_parameter as IDisposable).Dispose();
        }
    }
}