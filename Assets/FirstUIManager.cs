using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstUIManager:IUIManager
{
    private List<GameObject> Windows;
    private GameObject current; 

    public FirstUIManager()
    {
        Windows = new List<GameObject>();
        current = new GameObject();
    }
    public void OpenUI(string tag, Vector2 position)
    {
        
       var UI = Windows.Find(i => i.CompareTag(tag));
       if (UI is null) throw new ArgumentException("no prefab found with this tag");
       GameObject.Destroy(current); 
       current = UnityEngine.Object.Instantiate(UI);
       current.transform.SetParent(GameObject.Find("Canvas").transform);
       current.transform.localScale = new Vector3(1, 1, 1);
       current.transform.position = new Vector3(position.x, position.y);
       

    }   
    public void LoadUI(string nameFolder)
    {
        Windows = new List<GameObject>(Resources.LoadAll<GameObject>(nameFolder));
    }
}
