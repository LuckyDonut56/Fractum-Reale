using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;
    public List<GameObject> inventory = new();

    public bool hasFlashlight = false;
    public bool hasUVFlashlight = false;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void AddObject(GameObject obj)
    {
        inventory.Add(obj);
        obj.SetActive(false);

        if (obj.name == "flashlightPickable")
            hasFlashlight = true;
        if (obj.name == "UVFlashlightPickable")
            hasUVFlashlight = true;
    }

    public void RemoveObject(GameObject obj)
    {
        inventory.Remove(obj);
    }
}
