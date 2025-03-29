using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class UISlot : MonoBehaviour, IDropHandler
{
    private Inventory inventory;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (gameObject.transform.GetChild(0).childCount == 0)
        {
            var otherItemTransform = eventData.pointerDrag.transform.GetChild(0).transform;
            otherItemTransform.SetParent(transform.GetChild(0));
            otherItemTransform.localPosition = Vector3.zero;
            try
            {
                int index = Convert.ToInt32(transform.name[transform.name.Length - 1]) - 48;
                inventory.isFull[index - 1] = true;
            }
            catch { }
        }
    }
}
