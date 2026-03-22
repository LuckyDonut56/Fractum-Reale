using UnityEngine;

public class Button : MonoBehaviour, IInteractable
{
    public int digit;
    public Safe safe;
    public AudioSource buttonSound;

    public void Interact()
    {
        buttonSound.Play();
        safe.AddDigit(digit);
    }
}

