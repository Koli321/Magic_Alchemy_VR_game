using UnityEngine;
using System;

namespace Gameplay.Elements
{
    public class ElementsGuide : MonoBehaviour
    {
        private readonly MergePoint[] _mergeList = new[]
        {
        new MergePoint(ElementType.Water, ElementType.Water, ElementType.Cube),
        new MergePoint(ElementType.Water, ElementType.Air, ElementType.Cube),
        new MergePoint(ElementType.Water, ElementType.Ground, ElementType.Cube),
        new MergePoint(ElementType.Water, ElementType.Fire, ElementType.Cube),
        new MergePoint(ElementType.Air, ElementType.Air, ElementType.Cube),
        new MergePoint(ElementType.Air, ElementType.Ground, ElementType.Cube),
        new MergePoint(ElementType.Air, ElementType.Fire, ElementType.Cube),
        new MergePoint(ElementType.Ground, ElementType.Ground, ElementType.Cube),
        new MergePoint(ElementType.Ground, ElementType.Fire, ElementType.Cube),
        new MergePoint(ElementType.Fire, ElementType.Fire, ElementType.Cube),
    };

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

    public class MergePoint
    {
        public ElementType FirstElement { get; }
        public ElementType SecondElement { get; }
        public ElementType NewElement { get; }

        public MergePoint(ElementType first, ElementType second, ElementType result)
        {
            FirstElement = first;
            SecondElement = second;
            NewElement = result;
        }
    }
}