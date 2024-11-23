using UnityEngine.EventSystems;
using UnityEngine;

[RequireComponent(typeof(Outline))]
public class IPointEnter : MonoBehaviour
{
    private Outline outline;

    private void OnEnable()
    {
        outline = GetComponent<Outline>();
    }

    public void OnMouseEnter()
    {
        outline.OutlineWidth = 10;
    }
    public void OnMouseExit() 
    {
        outline.OutlineWidth = 0;
    }
}
