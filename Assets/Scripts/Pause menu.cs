using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausemenu : MonoBehaviour
{
    public GameObject PausePanel;
    public GameObject settingsPanel;
    public GameObject background;
    public GameObject SafeCamera;
    public PlayerController PlayerController;
    public void ContinueButton()
    {
        PausePanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
        PlayerController.enabled = true;
    }
    public void ExitButton()
    {
        SceneManager.LoadScene(0);
        PlayerController.enabled = true;
        Time.timeScale = 1;
    }
    public void OpenSettings()
    {
        PausePanel.SetActive(false);
        settingsPanel.SetActive(true);
        background.SetActive(true);
        SettingsUI settingsUI = FindFirstObjectByType<SettingsUI>();
        if (settingsUI != null) settingsUI.RefreshUI();
    }
    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
        background.SetActive(false);
        PausePanel.SetActive(true);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (settingsPanel.activeSelf)
            {
                CloseSettings();
            }
            else if (!PausePanel.activeSelf && SafeCamera.activeSelf == false)
            {
                pause();
            }
            else if (PausePanel.activeSelf)
            {
                ContinueButton();
            }
        }
    }
    
    public void pause()
    {
        Time.timeScale = 0;
        PausePanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        PlayerController.enabled = false;
    }
}
