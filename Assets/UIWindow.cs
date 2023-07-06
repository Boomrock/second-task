using UnityEngine;
public class UIWindow: MonoBehaviour, IWindow
{
    private bool isOpen = false;
    private GameObject self;
    public void Open()
    {
        if(isOpen && self is null) return;
        self.SetActive(true);
    }

    public void Close()
    {
        if(!isOpen && self is null) return;
        self.SetActive(false);
    }

    public void Init(Object parent)
    {
        if (parent is Canvas canvas)
        {
            self = Instantiate(this.transform.gameObject, canvas.transform);
            self.SetActive(false);
        }
    }
}