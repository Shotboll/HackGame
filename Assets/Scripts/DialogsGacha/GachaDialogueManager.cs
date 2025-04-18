using Unity.VisualScripting;
using UnityEngine;

public class GachaDialogueManager : MonoBehaviour
{
    public Animator gachaAnim;
    public GameObject[] ingredients;
    private Transform gacha;
    private PlayerComponent pc;
    private Inventory inventory;

    public void Start()
    {
        gacha = GameObject.FindGameObjectWithTag("Gacha").transform;
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerComponent>();
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    public void Roll()
    {
        if(pc.colTickects >= 1)
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (!inventory.isFull[i])
                {
                    int randomInt = Random.Range(0, ingredients.Length);
                    Instantiate(ingredients[randomInt], inventory.slots[i].transform.GetChild(0).transform);
                    inventory.isFull[i] = true;
                    //Vector2 gachaPos = new Vector2(gacha.position.x, (float)(gacha.position.y - 0.35));
                    //Instantiate(ingredients[randomInt], gachaPos, Quaternion.identity);
                    pc.colTickects--;
                    return;
                }
            }
        }
    }

    public void EndCraft()
    {
        gachaAnim.SetBool("openRoll", false);
    }
}
