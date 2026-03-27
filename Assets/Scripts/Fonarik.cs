using UnityEngine;
public enum light { none, std, UV };
public class FlashlightSimple : MonoBehaviour
{
    public GameObject flashlight;
    public GameObject UVflashlight;
    public light state = global::light.none;
    public KeyCode toggleKey = KeyCode.F;  
    void Start()
    {
        flashlight.SetActive(false);
        UVflashlight.SetActive(false);
    }
    void Update()
    {
        switch (state)
        {
            case global::light.none:
                flashlight.SetActive(false);
                UVflashlight.SetActive(false);
                break;
            case global::light.std:
                UVflashlight.SetActive(false);
                if (Inventory.Instance.hasFlashlight)
                {
                    if (!flashlight.activeSelf)
                    {
                        flashlight.SetActive(true);
                    }
                }
                else state += 1;
                break;
            case global::light.UV:
                flashlight.SetActive(false);
                if (Inventory.Instance.hasUVFlashlight)
                {
                    if (!UVflashlight.activeSelf)
                    {
                        UVflashlight.SetActive(true);
                    }
                }
                else state += 1;
                break;
            default: state = 0;
                break;
        }
        if (Input.GetKeyDown(toggleKey))
        {
            state+=1;
        }

    }
}

