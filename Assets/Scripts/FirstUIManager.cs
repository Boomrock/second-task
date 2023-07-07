using System;
using System.Collections.Generic;
using System.Linq;
using Interfaces;
using Unity.VisualScripting;
using UnityEngine;
using Object = UnityEngine.Object;

public class FirstUIManager : IUIManager
{
    private const string _pathResoures = "GameScene";
    private readonly IUIRoot _uiRoot;
    private Canvas canvas;
    private Dictionary<Type, GameObject> _initWindows = new Dictionary<Type, GameObject>();
    private Dictionary<Type, UIWindow> _loadWindows = new Dictionary<Type, UIWindow>();

    public FirstUIManager(IUIRoot UIRoot)
    {
        _uiRoot = UIRoot;
    }

    public typeOfWindow Show<typeOfWindow>() where typeOfWindow : UIWindow
    {
        var window = Get<typeOfWindow>();
        window.transform.SetParent(_uiRoot.ActiveBox, false);
        window.transform.rotation = Quaternion.identity;
        window.transform.localScale = Vector3.one;
        window.transform.localPosition = Vector3.zero;
        window.Show();
        return window.GetComponent<typeOfWindow>();
    }

    public void Hide<typeOfWindow>() where typeOfWindow : UIWindow
    {
        var window = Get<typeOfWindow>();
        window.transform.SetParent(_uiRoot.DeactiveBox, false);
        window.transform.rotation = Quaternion.identity;
        window.transform.localScale = Vector3.one;
        window.transform.localPosition = Vector3.zero;
        window.Hide();
    }

    public typeOfWindow Get<typeOfWindow>() where typeOfWindow : UIWindow
    {
        return _loadWindows[typeof(typeOfWindow)].GetComponent<typeOfWindow>();
    }
    

    public void LoadUI()
    {
        var windows =  Resources.LoadAll(_pathResoures, typeof(IWindow));
        foreach (var window in  windows)
        {
            var type = window.GetType();
            _loadWindows.Add(type, (UIWindow)window);
        }

        /*GameObject[] gameObjects = Resources.LoadAll<GameObject>(nameFolder);
        Debug.Log(gameObjects.Length);
        foreach (var gamaObject in gameObjects)
        {
            
            IWindow window = gamaObject.GetComponent<IWindow>();
            if (window is not null)
            {
                Windows[window.GetType()] = gamaObject;
            }
        }*/
    }

    public void Init()
    {
        foreach (var window in _loadWindows)
        {
            var prefab = GameObject.Instantiate(window.Value);
            _initWindows.Add(window.Key, prefab.gameObject);
        }
    }

}
