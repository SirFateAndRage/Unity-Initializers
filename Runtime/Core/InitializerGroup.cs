using System;
using UnityEditor;
using UnityEngine;


namespace SFR.Initializers
{
    public class InitializerGroup : Initializer
    {
        [Header("References")]
        [SerializeField] private Initializer[] _initializer;

        public override void Initialize()
        {
            foreach (var initializer in _initializer)
            {
                if (null == initializer)
                    HandleNullInitializer();
                    
                initializer.Initialize();
            }
        }

        private void HandleNullInitializer()
        {
            Selection.activeGameObject = this.gameObject;
            throw new Exception($"The InitializerGroup: {this.gameObject.name} have some null initilizer");
        }
    }
}