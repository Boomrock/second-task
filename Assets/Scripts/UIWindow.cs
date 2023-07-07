using UnityEngine;
public abstract class UIWindow : MonoBehaviour, IWindow
{
    public virtual void Show()
    { }
    public virtual void Hide()
    { }
}