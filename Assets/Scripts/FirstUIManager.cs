using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FirstUIManager : IUIManager
{
    private Canvas canvas;
    private Dictionary<Type, GameObject> Windows;
    private Transform ActiveBox, DeactiveBox;

    public FirstUIManager(Transform ActiveBox, Transform DeactiveBox)
    {
        this.ActiveBox = ActiveBox;
        this.DeactiveBox = DeactiveBox;    
        Windows = new Dictionary<Type, GameObject>();

    }

    public void Show<typeOfWindow>() where typeOfWindow : IWindow
    {
        GameObject gameObject = Windows[typeof(typeOfWindow)];
        IWindow window = gameObject.GetComponent<IWindow>();
        gameObject.SetActive(true);
        gameObject.transform.SetParent(ActiveBox);
        window.Show();
    }

    public void Hide<typeOfWindow>() where typeOfWindow : IWindow
    {
        GameObject gameObject = Windows[typeof(typeOfWindow)];
        IWindow window = gameObject.GetComponent<IWindow>();
        gameObject.SetActive(false);
        gameObject.transform.SetParent(DeactiveBox);
        window.Hide();
    }

    public IWindow Get<typeOfWindow>() where typeOfWindow : IWindow
    {
        return Windows[typeof(typeOfWindow)].GetComponent<IWindow>();
    }

    public void Set<typeOfWindow>(GameObject window) where typeOfWindow : IWindow
    {
        Windows[typeof(typeOfWindow)] = window;
    }

    public void LoadUI(string nameFolder)
    {
        GameObject[] gameObjects = Resources.LoadAll<GameObject>(nameFolder);
        Debug.Log(gameObjects.Length);
        foreach (var gamaObject in gameObjects)
        {
            
            IWindow window = gamaObject.GetComponent<IWindow>();
            if (window is not null)
            {
                Windows[window.GetType()] = gamaObject;
            }
        }
    }

    public void Init()
    {
        Type[] Keys = Windows.Keys.ToArray();
        foreach (var key in Keys)
        {

            Windows[key] = GameObject.Instantiate(Windows[key], DeactiveBox);
            Windows[key].SetActive(false);
           
        }
    }

}
