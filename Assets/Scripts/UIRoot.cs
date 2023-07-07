using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

public class UIRoot : MonoBehaviour, IUIRoot
{
    public Transform ActiveBox { get => activeBox; }
    public Transform DeactiveBox { get => deactiveBox; }
    
    [SerializeField] private Transform activeBox;
    [SerializeField] private Transform deactiveBox;
}
