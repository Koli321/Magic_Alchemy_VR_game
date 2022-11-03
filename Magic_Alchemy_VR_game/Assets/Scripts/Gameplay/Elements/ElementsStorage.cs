using UnityEngine;
using System;
using System.Collections.Generic;

public class ElementsStorage : MonoBehaviour
{
    [SerializeField] private TypedElement[] _elements;

    private readonly Dictionary<ElementType, GameObject> _elementsDictionary = new();

    public GameObject GetPrefab(ElementType type) => _elementsDictionary[type];

    private void Awake()
    {
        foreach (var element in _elements)
            _elementsDictionary.Add(element.Type, element.Prefab);
    }
}

[Serializable]
public class TypedElement
{
    public ElementType Type;
    public GameObject Prefab;
}