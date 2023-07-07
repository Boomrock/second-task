using UnityEngine;

public interface IUIManager
{
    public void ShowUI<typeOfWindow>() where typeOfWindow : IWindow;
    public IWindow Get<typeOfWindow>() where typeOfWindow : IWindow;
    public void Set<typeOfWindow>(IWindow window) where typeOfWindow : IWindow;
    public void LoadUI(string nameFolder);
    public void Init();
}
