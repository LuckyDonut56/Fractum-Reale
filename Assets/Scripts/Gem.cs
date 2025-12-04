using UnityEngine;

public class Gem : MonoBehaviour, IInteractable
{
    public enum GemColor {Red, Green, Blue}
    public GemColor color;
    public void Interact()
    {
        GemInventory.gemInventory.AddGem(this);
        gameObject.SetActive(false);
    }
}
