using UnityEngine;

public class PickableItem : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Inventory.Instance.AddObject(gameObject);
    }
}
