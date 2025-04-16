using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int colTickects;
    public List<string> potions;
    public List<string> inventory;

    public PlayerData(PlayerComponent player)
    {
        colTickects = player.colTickects;
        potions = player.savePotions;
        inventory = player.saveInventory;
    }
}
