using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<GameObject> inventory = new();

    public void AddObject(GameObject obj)
    {
        inventory.Add(obj);
        obj.SetActive(false);
    }

    public void RemoveObject(GameObject obj)
    {
        inventory.Remove(obj);
    }
}
