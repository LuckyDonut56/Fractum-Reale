using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausemenu : MonoBehaviour
{
    public GameObject PausePanel;
    public PlayerController PlayerController;
    public AudioListener AudioListener;
    public void ContinueButton()
    {
        PausePanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
        PlayerController.enabled = true;
        AudioListener.enabled = true;
    }
    public void ExitButton()
    {
        SceneManager.LoadScene(0);
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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
        AudioListener.enabled = false;
    }
}
