using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static List<GameObject> inventory = new();

    public static void AddObject(GameObject obj)
    {
        inventory.Add(obj);
        Destroy(obj);
        Debug.Log("Добавлен предмет");
        for (int i = 0; i < inventory.Count; i++)
        {
            Debug.Log(inventory[i].name);
        }
    }

    public static void RemoveObject(GameObject obj)
    {
        inventory.Remove(obj);
    }
}
