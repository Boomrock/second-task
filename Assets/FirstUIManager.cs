using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class FirstUIManager:IUIManager
{
    private Canvas canvas;
    private List<IWindow> Windows;
    private IWindow window; 

    
    public FirstUIManager(Canvas canvas)
    {
        this.canvas = canvas;
        Windows = new List<IWindow>();
        
    }
    public void OpenUI(Type typeOfWindow)
    { 
        if (typeOfWindow.GetType().GetInterfaces().Contains(typeof(IWindow))) throw new ArgumentException("window type should be IWindow");
        window.Close();
        window = Windows.Find(i => i.GetType() == typeOfWindow);
        window.Open();
    }   
    public void LoadUI(string nameFolder)
    {
        var GameObject = Resources.LoadAll(nameFolder);
        foreach (var obj in GameObject)
        {
            window = obj.GetComponent<IWindow>();
            if (window is not null)
            {
                window.Init(canvas);
                Windows.Add(window);
            } 
        }

        window = Windows.Last();
    }
}
