using UnityEngine;

public class UVFlashlight : MonoBehaviour
{
    public GameObject flashlight;
    public Light flashlightLight;
    public KeyCode toggleKey = KeyCode.F;

    private bool isOn = false;
    void Start()
    {
        flashlight.SetActive(false);
        flashlightLight.enabled = false;
    }
    void Update()
    {
        if (Inventory.Instance.hasUVFlashlight)
        {
            if (!flashlight.activeSelf)
            {
                flashlight.SetActive(true);
            }
            if (Input.GetKeyDown(toggleKey))
            {
                isOn = !isOn;
                flashlightLight.enabled = isOn;
            }
        }

    }
}