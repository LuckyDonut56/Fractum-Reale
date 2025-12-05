using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class ClosedDoor : MonoBehaviour, IInteractable
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Interact()
    {
        foreach(var x in Inventory.Instance.inventory)
        {
            if (x.gameObject.name == "Key1")
            {
                GetComponent<Door>().enabled = true;
                enabled = false;
            }
        }
    }
}
