using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    public Slider volumeSlider;
    public Slider sensitivitySlider;
    public TextMeshProUGUI[] fpsButtonTexts;
    private UnityEngine.UI.Button[] fpsButtons;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        RefreshUI();
    }

    public void RefreshUI()
    {
        RebindUI();
        InitSettingsUI();
        SubscribeEvents();
    }

    public void InitSettingsUI()
    {
        if (GameSettings.Instance == null) return;

        if (sensitivitySlider != null)
            sensitivitySlider.SetValueWithoutNotify(GameSettings.Instance.mouseSensitivity);
        if (volumeSlider != null)
            volumeSlider.SetValueWithoutNotify(GameSettings.Instance.volume);

        int currentFPS = GameSettings.Instance.targetFPS;
        HighlightButton(currentFPS);
    }

    public void RebindUI()
    {
        Slider[] allSliders = Resources.FindObjectsOfTypeAll<Slider>();
        volumeSlider = null;
        sensitivitySlider = null;
        foreach (var slider in allSliders)
        {
            if (slider.CompareTag("VolumeSlider")) volumeSlider = slider;
            if (slider.CompareTag("SensitivitySlider")) sensitivitySlider = slider;
        }

        UnityEngine.UI.Button[] allButtons = Resources.FindObjectsOfTypeAll<UnityEngine.UI.Button>();
        var buttonList = new System.Collections.Generic.List<UnityEngine.UI.Button>();
        foreach (var button in allButtons)
        {
            if (button.CompareTag("FPSButton"))
                buttonList.Add(button);
        }

        fpsButtons = buttonList.ToArray();
        fpsButtonTexts = new TextMeshProUGUI[fpsButtons.Length];
        for (int i = 0; i < fpsButtons.Length; i++)
        {
            fpsButtonTexts[i] = fpsButtons[i].GetComponentInChildren<TextMeshProUGUI>();
        }
    }

    private void SubscribeEvents()
    {
        UnsubscribeEvents();

        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
        sensitivitySlider.onValueChanged.AddListener(OnSensitivityChanged);

        for (int i = 0; i < fpsButtons.Length; i++)
        {
            int index = i;
            fpsButtons[i].onClick.AddListener(() => OnFPSButtonClicked(index));
        }
    }

    private void UnsubscribeEvents()
    {
        volumeSlider.onValueChanged.RemoveAllListeners();
        sensitivitySlider.onValueChanged.RemoveAllListeners();

        foreach (var button in fpsButtons)
            button.onClick.RemoveAllListeners();
    }

    private void OnVolumeChanged(float value)
    {
        GameSettings.Instance.SetVolume(value);
    }

    private void OnSensitivityChanged(float value)
    {
        GameSettings.Instance.SetMouseSensitivity(value);
    }

    private void OnFPSButtonClicked(int index)
    {
        string fpsText = fpsButtonTexts[index].text;
        if (int.TryParse(fpsText, out int fps))
        {
            GameSettings.Instance.SetFPS(fps);
            HighlightButton(fps);
        }
    }

    private void HighlightButton(int fps)
    {
        for (int i = 0; i < fpsButtonTexts.Length; i++)
        {
            if (fpsButtonTexts[i] != null && int.TryParse(fpsButtonTexts[i].text, out int btnFps))
            {
                if (btnFps == fps)
                {
                    fpsButtonTexts[i].color = new Color(0.4196f, 0f, 0f);
                }
                else
                {
                    fpsButtonTexts[i].color = Color.black;
                }
            }
        }
    }

}

