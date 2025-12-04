using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    public float roty = 0f;
    public float speed = 90f;
    private bool isOpen = false;
    private float currentAngle = 0f;
    void Start()
    {
        roty = transform.localRotation.eulerAngles.y;
    }
    void Update()
    {
        float targetAngle = isOpen ? 90f : 0f;
        currentAngle = Mathf.MoveTowards(currentAngle, targetAngle, speed * Time.deltaTime);
        transform.localRotation = Quaternion.Euler(transform.localRotation.eulerAngles.x, roty + currentAngle, transform.localRotation.eulerAngles.z);
    }

    public void Interact()
    {
        isOpen = !isOpen;
    }
}

