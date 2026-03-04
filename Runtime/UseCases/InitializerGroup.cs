using System;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;


namespace SFR.Initializers
{
    public class InitializerGroup : Initializer
    {
        [Header("References")]
        [SerializeField] private Initializer[] _initializer;

        public override async Task Initialize()
        {
            foreach (var initializer in _initializer)
            {
                if (null == initializer)
                    HandleNullInitializer();

                await initializer.Initialize();
            }
        }

        private void HandleNullInitializer()
        {
            Selection.activeGameObject = this.gameObject;
            throw new Exception($"The InitializerGroup: {this.gameObject.name} have some null initilizer");
        }
    }
}