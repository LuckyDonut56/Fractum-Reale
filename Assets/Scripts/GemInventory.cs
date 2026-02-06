using System.Collections.Generic;
using UnityEngine;
using static Gem;

public class GemInventory : MonoBehaviour
{
    public static GemInventory gemInventory;

    public List<Gem> collectedGems = new List<Gem>();

    void Awake()
    {
        if (gemInventory == null)
            gemInventory = this;
    }

    public void AddGem(Gem gem)
    {
        collectedGems.Add(gem);
    }

    public bool HasGem(GemColor color)
    {
        return collectedGems.Find(g => g.color == color) != null;
    }

    public void RemoveGem(GemColor color)
    {
        var gem = collectedGems.Find(g => g.color == color);
        if (gem != null)
        {
            collectedGems.Remove(gem);
            Destroy(gem.gameObject);
        }
    }
}
