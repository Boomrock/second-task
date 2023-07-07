using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class game : MonoBehaviour
{
    private IUIManager uiManager;
    [SerializeField] private Transform ActiveBox, 
                                        DeactiveBox;

    private void Start()
    {
        uiManager = new FirstUIManager(ActiveBox, DeactiveBox);
        uiManager.LoadUI("GameScene");
        uiManager.Init();
    }

    public void Open(string typeName)
    {
        Type typeArgument = Type.GetType(typeName);
        MethodInfo method = uiManager.GetType().GetMethod("Show");
        MethodInfo genericMethod = method.MakeGenericMethod(typeArgument);
        genericMethod.Invoke(uiManager, null);
    }
    public void Hide(string typeName)
    {
        Type typeArgument = Type.GetType(typeName);
        MethodInfo method = uiManager.GetType().GetMethod("Hide");
        MethodInfo genericMethod = method.MakeGenericMethod(typeArgument);
        genericMethod.Invoke(uiManager, null);
    }
}
