using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    public float roty = 0f;
    public float speed = 90f;
    public bool isOpen = false;
    private float currentAngle = 0f;

    public AudioSource doorOpen;
    public float openPlayDelay = 0.05f;
    public AudioSource doorClose;
    public float closePlayDelay = 0.75f;
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
        if (!enabled) return;
        if (!isOpen)
            doorOpen.PlayDelayed(openPlayDelay);
        else
            doorClose.PlayDelayed(closePlayDelay);
        isOpen = !isOpen;
        
    }
}

