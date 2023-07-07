using UnityEngine;

public interface IUIManager
{
    public void Show<typeOfWindow>() where typeOfWindow : IWindow;
    public void Hide<typeOfWindow>() where typeOfWindow : IWindow;
    public IWindow Get<typeOfWindow>() where typeOfWindow : IWindow;
    public void Set<typeOfWindow>(GameObject window) where typeOfWindow : IWindow;
    public void LoadUI(string nameFolder);
    public void Init();
}
