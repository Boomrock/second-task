using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class FirstUIManager : IUIManager
{
    private Canvas canvas;
    private List<IWindow> Windows;
    private IWindow window;
    private Transform ActiveBox, DeactiveBox;

    public FirstUIManager(Transform ActiveBox, Transform DeactiveBox)
    {
        this.ActiveBox = ActiveBox;
        this.DeactiveBox = DeactiveBox;    
        Windows = new List<IWindow>();

    }

    public void ShowUI<typeOfWindow>() where typeOfWindow : IWindow
    {
        window?.Hide();
        window?.Transform.SetParent(DeactiveBox);
        window = Get<typeOfWindow>();
        window.Show();
        window.Transform.SetParent(ActiveBox);
    }

    public IWindow Get<typeOfWindow>() where typeOfWindow : IWindow
    {
        return Windows.Find(i => i is typeOfWindow);
    }

    public void Set<typeOfWindow>(IWindow window) where typeOfWindow : IWindow
    {
        int index = Windows.FindIndex(i => i is typeOfWindow);
        Windows[index] = window;
    }

    public void LoadUI(string nameFolder)
    {
        GameObject[] gameObjects = Resources.LoadAll<GameObject>(nameFolder);
        foreach (var gameObject in gameObjects)
        {
            IWindow window = gameObject.GetComponent<IWindow>();
            if (window is not null)
            {
                Windows.Add(window);
            }
        }
    }

    public void Init()
    {
        for (int i = 0; i < Windows.Count; i++)
        {
  
            Windows[i] = GameObject.Instantiate(Windows[i].Transform.gameObject, DeactiveBox).GetComponent<IWindow>();
            Windows[i].Hide();
        }
    }
}
