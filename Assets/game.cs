using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game : MonoBehaviour
{
    private IUIManager UIManager;
    [SerializeField] private Canvas canvas;

    private void Start()
    {
        UIManager = new FirstUIManager(canvas);
        UIManager.LoadUI("GameScene");
    }

    public void Open(string type)
    {
        UIManager.OpenUI(Type.GetType(type));
    }
}
