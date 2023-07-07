using UnityEngine;
public class UIWindow: MonoBehaviour, IWindow
{
    private bool isShow = true;
    public void Show()
    {
        if(isShow ) return;
        isShow = !isShow;
        this.gameObject.SetActive(isShow);
    }

    public void Hide()
    {
        
        if(!isShow ) return;
        isShow = !isShow;
        this.gameObject.SetActive(isShow);
    }

    public Transform Transform { get => transform; }
}