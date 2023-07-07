using UnityEngine;

namespace Interfaces
{
    public interface IUIRoot
    {
        public Transform  ActiveBox { get; }
        public Transform  DeactiveBox { get; }
    }
}