using UnityEngine;

public class GachaDialogueManager : MonoBehaviour
{
    public Animator gachaAnim;
    public GameObject[] ingredients;
    private Transform gacha;

    public void Start()
    {
        gacha = GameObject.FindGameObjectWithTag("Gacha").transform;
    }

    public void Roll()
    {
        int randomInt = Random.Range(0, ingredients.Length);
        Vector2 gachaPos = new Vector2(gacha.position.x, (float)(gacha.position.y - 0.35));
        Instantiate(ingredients[randomInt], gachaPos, Quaternion.identity);
    }

    public void EndCraft()
    {
        gachaAnim.SetBool("openRoll", false);
    }
}
