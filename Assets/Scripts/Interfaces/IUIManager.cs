using UnityEngine;

public interface IUIManager
{
    public typeOfWindow Show<typeOfWindow>() where typeOfWindow : UIWindow;
    public void Hide<typeOfWindow>() where typeOfWindow : UIWindow;
    public typeOfWindow Get<typeOfWindow>() where typeOfWindow : UIWindow;
    public void LoadUI();
    public void Init();
}
