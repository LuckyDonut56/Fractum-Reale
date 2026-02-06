using UnityEngine;
using TMPro;
using System.Collections;

public class Safe : MonoBehaviour, IInteractable
{
    public string code = "639";
    public TextMeshPro[] digits;

    public Camera playerCamera;
    public Camera safeCamera;

    public GameObject crosshair;

    public float roty = 0f;
    public float speed = 90f;

    private float currentAngle = 0f;

    private string entered = "";
    private bool isActive = false;
    private bool isChecking = false;
    private bool isSolved = false;
    private bool isOpen;
    void Start()
    {
        roty = transform.localRotation.eulerAngles.y;
    }

    void Update()
    {
        if (isActive && Input.GetMouseButtonDown(0))
        {
            Ray ray = safeCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 5f))
            {
                Button button = hit.collider.GetComponent<Button>();
                if (button != null)
                {
                    button.Interact();
                }
            }
        }
        if (isActive && Input.GetKeyDown(KeyCode.Escape))
        {
            ExitSafeView();
        }
        if (isSolved && !isOpen)
        {
            Debug.Log("Opening");
            Open();
        }
    }

    public void Interact()
    {
        if (isSolved)
        {
            return;
        }

        isActive = true;

        playerCamera.gameObject.SetActive(false);
        safeCamera.gameObject.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        crosshair.gameObject.SetActive(false);

        gameObject.GetComponent<Collider>().enabled = false;
    }

    public void AddDigit(int digit)
    {
        if (!isActive || isChecking)
            return;

        if (entered.Length >= digits.Length)
            return;

        entered += digit.ToString();
        digits[entered.Length - 1].text = digit.ToString();

        if (entered.Length == code.Length)
        {
            StartCoroutine(WaitAndCheck());
        }      
    }

    void CheckCode()
    {
        if (entered == code)
        {
            Debug.Log("Correct");
            isSolved = true;
            ExitSafeView();
            Open();
        }
        else
        {
            entered = "";
            foreach (var s in digits)
                s.text = "";
        }
    }

    public void ExitSafeView()
    {
        isActive = false;

        safeCamera.gameObject.SetActive(false);
        playerCamera.gameObject.SetActive(true);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        crosshair.gameObject.SetActive(true);

        gameObject.GetComponent<Collider>().enabled = true;

        if (!isSolved)
        {
            entered = "";
            foreach (var s in digits)
                s.text = "";
        }
    }

    private IEnumerator WaitAndCheck()
    {
        isChecking = true;
        yield return new WaitForSeconds(0.5f);
        CheckCode();
        isChecking = false;
    }

    public void Open()
    {
        float targetAngle = 90f;
        currentAngle = Mathf.MoveTowards(currentAngle, targetAngle, speed * Time.deltaTime);
        transform.localRotation = Quaternion.Euler(transform.localRotation.eulerAngles.x,
            roty + currentAngle,
            transform.localRotation.eulerAngles.z);

        if (currentAngle == targetAngle)
        {
            isOpen = true;
            Debug.Log("Opened");
        }
    }
}

