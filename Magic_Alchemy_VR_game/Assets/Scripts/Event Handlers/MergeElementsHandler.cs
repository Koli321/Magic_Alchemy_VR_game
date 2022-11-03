using UnityEngine;

[RequireComponent(typeof(ElementsGuide))]
public class MergeElementsHandler : MonoBehaviour
{
    private ElementsGuide _elementsGuide;

    private void Awake()
    {
        _elementsGuide = GetComponent<ElementsGuide>();
    }

    private void OnEnable()
    {
        ElementsMerging.GetMergeElement += _elementsGuide.GetBy;
    }

    private void OnDisable()
    {
        ElementsMerging.GetMergeElement -= _elementsGuide.GetBy;
    }
}
