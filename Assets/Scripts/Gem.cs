using UnityEngine;

public class Gem : MonoBehaviour, IInteractable
{
    public enum GemColor {Red, Green, Blue}
    public GemColor color;
    public AudioSource gemPickUpSound;
    public void Interact()
    {
        gemPickUpSound.Play();
        GemInventory.gemInventory.AddGem(this);
        gameObject.SetActive(false);
    }
}
