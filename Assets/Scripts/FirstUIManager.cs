using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class FirstUIManager : IUIManager
{
    private Canvas canvas;
    private List<GameObject> Windows;
    private GameObject gameObject;
    private IWindow window;
    private Transform ActiveBox, DeactiveBox;

    public FirstUIManager(Transform ActiveBox, Transform DeactiveBox)
    {
        this.ActiveBox = ActiveBox;
        this.DeactiveBox = DeactiveBox;    
        Windows = new List<GameObject>();

    }

    public void ShowUI<typeOfWindow>() where typeOfWindow : IWindow
    {
        
        gameObject?.SetActive(false);
        window?.Hide();
        gameObject?.transform.SetParent(DeactiveBox);
        gameObject = Get<typeOfWindow>();
        window = gameObject.GetComponent<IWindow>();
        gameObject.SetActive(true);
        window.Show();
        gameObject.transform.SetParent(ActiveBox);
    }

    public GameObject Get<typeOfWindow>() where typeOfWindow : IWindow
    {
        return Windows.Find(i => i.GetComponent< typeOfWindow>() is not null);
    }

    public void Set<typeOfWindow>(GameObject window) where typeOfWindow : IWindow
    {
        var windowTypeOf = Get<typeOfWindow>();
        windowTypeOf = window;
    }

    public void LoadUI(string nameFolder)
    {
        GameObject[] gameObjects = Resources.LoadAll<GameObject>(nameFolder);
        foreach (var gameObject in gameObjects)
        {
            IWindow window = gameObject.GetComponent<IWindow>();
            if (window is not null)
            {
                Windows.Add(gameObject);
            }
        }
    }

    public void Init()
    {
        for (int i = 0; i < Windows.Count; i++)
        {
  
            Windows[i] = GameObject.Instantiate(Windows[i], DeactiveBox);
            Windows[i].SetActive(false);
        }
    }
}
