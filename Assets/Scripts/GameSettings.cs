using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public static GameSettings Instance;

    public float mouseSensitivity = 1f;
    public float volume = 1f;
    public int targetFPS = 60;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void CreateInstance()
    {
        if (Instance != null) return;

        GameObject prefab = Resources.Load<GameObject>("Settings");
        if (prefab != null)
        {
            GameObject obj = Instantiate(prefab);
            DontDestroyOnLoad(obj);
        }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            mouseSensitivity = PlayerPrefs.GetFloat("mouseSensitivity", 1f);
            volume = PlayerPrefs.GetFloat("volume", 1f);
            targetFPS = PlayerPrefs.GetInt("fps", 60);

            SetVolume(volume);
            SetFPS(targetFPS);
            SetMouseSensitivity(mouseSensitivity);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetMouseSensitivity(float value)
    {
        mouseSensitivity = Mathf.Clamp(value, 0.1f, 5f);
        PlayerPrefs.SetFloat("mouseSensitivity", mouseSensitivity);
    }

    public void SetVolume(float value)
    {
        volume = Mathf.Clamp01(value);
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("volume", volume);
    }

    public void SetFPS(int value)
    {
        QualitySettings.vSyncCount = 0;
        targetFPS = Mathf.Clamp(value, 30, 240);
        Application.targetFrameRate = targetFPS;
        PlayerPrefs.SetInt("fps", targetFPS);
    }
}
