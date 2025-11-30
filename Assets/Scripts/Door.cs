using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    public float speed = 90f;
    private bool isOpen = false;
    private float currentAngle = 0f;

    void Update()
    {
        float targetAngle = isOpen ? 90f : 0f;
        currentAngle = Mathf.MoveTowards(currentAngle, targetAngle, speed * Time.deltaTime);
        transform.localRotation = Quaternion.Euler(0, currentAngle, 0);
    }

    public void Interact()
    {
        isOpen = !isOpen;
    }
}

