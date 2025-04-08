using Unity.VisualScripting;
using UnityEngine;

public class Craft : MonoBehaviour
{

    public string[] craftIng;
    public Animator[] potionsAnims = new Animator[5];
    private string[] recipes = new string[] { "Coal+crystal","brown","flower+Uranus","green","gold+redDust","orange","Uranus+gold","yellow","gold+flower","pink"};

    private GameObject craft;
    private GameObject potions;

    private string potion;

    private PlayerComponent pc;

    private void Start()
    {
        craft = GameObject.FindGameObjectWithTag("Craft");
        potions = GameObject.FindGameObjectWithTag("Potions");
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerComponent>(); ;
    }

    public void CraftPotion()
    {
        for (int i = 0; i < craft.transform.childCount; i++)
        {
            if (craft.transform.GetChild(i).transform.name.Contains("Slot"))
            {
                craftIng[i] = craft.transform.GetChild(i).transform.GetChild(0).transform.GetChild(0).transform.name.Replace("Button(Clone)", "");
            }
        }

        if (craftIng[0] == craftIng[1])
        {
            return;
        }

        for (int i = 0; i < recipes.Length; i += 2)
        {
            string recipe = recipes[i];
            if (recipe.Contains(craftIng[0]) && recipe.Contains(craftIng[1]))
            {
                potion = recipes[i + 1];
            }
        }

        for (int i = 0; i < potions.transform.childCount; i++)
        {
            if (potions.transform.GetChild(i).transform.name.Contains(potion))
            {
                potions.transform.GetChild(i).transform.gameObject.SetActive(true);
                pc.colPotions++;
                Destroy(craft.transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).gameObject);
                Destroy(craft.transform.GetChild(1).transform.GetChild(0).transform.GetChild(0).gameObject);
                break;
            }
        }
        
    }
    
}
