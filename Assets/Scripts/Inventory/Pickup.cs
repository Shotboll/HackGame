using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Inventory inventory;
    public GameObject slotButton;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            for(int i = 0; i<inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    inventory.isFull[i] = true;
                    Instantiate(slotButton, inventory.slots[i].transform.GetChild(0).transform);
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
