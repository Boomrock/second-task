using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class game : MonoBehaviour
{
    
    private IUIManager uiManager;
    [SerializeField] private UIRoot _uiRoot;
    private void Start()
    {
        uiManager = new FirstUIManager(_uiRoot);
        uiManager.LoadUI();
        uiManager.Init();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            uiManager.Show<MainMenu>();
        }   
    }
}
