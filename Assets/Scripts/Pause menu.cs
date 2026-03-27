using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausemenu : MonoBehaviour
{
    public GameObject PausePanel;
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
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)&& SafeCamera.activeSelf == false)
        {
            pause();
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
