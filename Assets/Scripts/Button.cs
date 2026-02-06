using UnityEngine;

public class Button : MonoBehaviour, IInteractable
{
    public int digit;
    public Safe safe;

    public void Interact()
    {
        safe.AddDigit(digit);
    }
}

