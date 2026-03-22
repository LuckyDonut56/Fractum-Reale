using UnityEngine;

public class PickableItem : MonoBehaviour, IInteractable
{
    public AudioSource pickUpSound;
    public void Interact()
    {
        pickUpSound.Play();
        Inventory.Instance.AddObject(gameObject);
    }
}
