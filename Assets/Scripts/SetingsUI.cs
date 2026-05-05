using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    public Slider sensitivitySlider;
    public Slider volumeSlider;

    public void InitSettingsUI()
    {
        sensitivitySlider.value = GameSettings.Instance.mouseSensitivity;
        volumeSlider.value = GameSettings.Instance.volume;

        int fps = GameSettings.Instance.targetFPS;
    }

    public void Set30() => GameSettings.Instance.SetFPS(30);
    public void Set60() => GameSettings.Instance.SetFPS(60);
    public void Set120() => GameSettings.Instance.SetFPS(120);
    public void Set240() => GameSettings.Instance.SetFPS(240);
}

