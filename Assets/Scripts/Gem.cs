using UnityEngine;

public class Gem : MonoBehaviour, IInteractable
{
    public Inventory inventory;
    public void Interact()
    {
        inventory.AddObject(gameObject);
    }
}
