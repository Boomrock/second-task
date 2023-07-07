using UnityEngine;

public interface IUIManager
{
    public void ShowUI<typeOfWindow>() where typeOfWindow : IWindow;
    public GameObject Get<typeOfWindow>() where typeOfWindow : IWindow;
    public void Set<typeOfWindow>(GameObject window) where typeOfWindow : IWindow;
    public void LoadUI(string nameFolder);
    public void Init();
}
