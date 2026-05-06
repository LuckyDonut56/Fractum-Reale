using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    public Slider volumeSlider;
    public Slider sensitivitySlider;
    public TextMeshProUGUI[] buttons;
    public void InitSettingsUI()
    {
        sensitivitySlider.value = GameSettings.Instance.mouseSensitivity;
        volumeSlider.value = GameSettings.Instance.volume;

        int fps = GameSettings.Instance.targetFPS;
        
    }

    public void Set30()
    {
        GameSettings.Instance.SetFPS(30);
        Select(0);
        
    }
    public void Set60()
    {
        GameSettings.Instance.SetFPS(60);
        Select(1);

    }
    public void Set120()
    {
        GameSettings.Instance.SetFPS(120);
        Select(2);

    }
    public void Set240()
    {
        GameSettings.Instance.SetFPS(240);
        Select(3);

    }
    public void Select(int idx)
    {
        buttons[idx].color = new Color(0.4196f, 0f, 0f);
        for (int i = 0; i < buttons.Length; i++)
        {
            if (i != idx)
            {
                buttons[i].color = Color.black;
            }
        }
    }
    private void OnLevelWasLoaded(int level)
    {
        volumeSlider = GameObject.FindWithTag("VolumeSlider").GetComponent<Slider>();
        sensitivitySlider = GameObject.FindWithTag("SensitivitySlider").GetComponent<Slider>();

        GameObject[] FPSButtons = GameObject.FindGameObjectsWithTag("FPSButton");
        for (int i = 0; i < 4; ++i)
        {
            buttons[i] = FPSButtons[i].GetComponent<TextMeshProUGUI>();
        }
    }
}

