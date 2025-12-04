using UnityEngine;

public class FlashlightSimple : MonoBehaviour
{
    public Light flashlightLight;  
    public KeyCode toggleKey = KeyCode.F;  

    private bool isOn = false;  

    void Update()
    {       
        if (Input.GetKeyDown(toggleKey))
        {
            isOn = !isOn;
            flashlightLight.enabled = isOn;           
        }
    }
}

