using UnityEngine;
using System;

public class ElementsGuide : MonoBehaviour
{
    [SerializeField] private MergePoint[] _mergeList;

    public ElementType GetBy(ElementType first, ElementType second)
    {
        foreach (var mergePoint in _mergeList)
        {
            if ((mergePoint.FirstElement == first && mergePoint.SecondElement == second) ||
                (mergePoint.SecondElement == first && mergePoint.FirstElement == second))
                return mergePoint.NewElement;
        }
        return ElementType.None;
    }
}

[Serializable]
public class MergePoint
{
    public ElementType FirstElement;
    public ElementType SecondElement;
    public ElementType NewElement;
}