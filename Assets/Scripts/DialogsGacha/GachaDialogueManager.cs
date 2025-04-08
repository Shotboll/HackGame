using UnityEngine;

public class GachaDialogueManager : MonoBehaviour
{
    public Animator gachaAnim;
    public GameObject[] ingredients;
    private Transform gacha;
    private PlayerComponent pc;

    public void Start()
    {
        gacha = GameObject.FindGameObjectWithTag("Gacha").transform;
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerComponent>(); ;
    }

    public void Roll()
    {
        if(pc.colTickects >= 1)
        {
            int randomInt = Random.Range(0, ingredients.Length);
            Vector2 gachaPos = new Vector2(gacha.position.x, (float)(gacha.position.y - 0.35));
            Instantiate(ingredients[randomInt], gachaPos, Quaternion.identity);
            pc.colTickects--;
        }
    }

    public void EndCraft()
    {
        gachaAnim.SetBool("openRoll", false);
    }
}
