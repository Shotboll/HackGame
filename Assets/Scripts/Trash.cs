using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Trash : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        Destroy(eventData.pointerDrag.transform.GetChild(0).gameObject);
    }
}
