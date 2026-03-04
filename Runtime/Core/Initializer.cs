using System.Threading.Tasks;
using UnityEngine;


namespace SFR.Initializers
{
    public abstract class Initializer : MonoBehaviour
    {
        public abstract Task Initialize();
    }
}