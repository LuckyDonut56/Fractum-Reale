using UnityEngine;

public class Gem : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Inventory.AddObject(gameObject);
    }
}
