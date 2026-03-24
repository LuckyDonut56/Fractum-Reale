using UnityEngine;

public class UVScript : MonoBehaviour
{
    public Material mat;
    public Light spotLight;

    public FlashlightSimple flashlight;
    void Update()
    {
        if (mat && spotLight && flashlight)
        {
            if (flashlight.state == global::light.UV)
            {
                mat.SetVector("_LightPosition", spotLight.transform.position);
                mat.SetVector("_LightDirection", -spotLight.transform.forward);
                mat.SetFloat("_LightAngle", spotLight.spotAngle);
            }
            else
            {
                mat.SetFloat("_LightAngle", 0f);
            }
        }
    }
}