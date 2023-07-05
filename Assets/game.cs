using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game : MonoBehaviour
{
    public IUIManager UIManager;

    private void Start()
    {
        UIManager = new FirstUIManager();
        UIManager.LoadUI("GameScene");
    }

    public void Open(string tag)
    {
        UIManager.OpenUI(tag, new Vector2(0,0));
    }
}
