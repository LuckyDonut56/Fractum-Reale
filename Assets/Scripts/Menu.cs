using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public SettingsUI settings;

    public GameObject mainMenu;
    public GameObject settingsMenu;

    private void Start()
    {
        GameObject prefab = Resources.Load<GameObject>("Settings");
        if (prefab != null )
        {
            settings = prefab.GetComponent<SettingsUI>();
        }

        mainMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }

    public void StartButton()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void SettingsButton()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
        settings.RebindUI();
        settings.InitSettingsUI();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && settingsMenu.activeSelf)
        {
            mainMenu.SetActive(true);
            settingsMenu.SetActive(false);
        }
    }
}
