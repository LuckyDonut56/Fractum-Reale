using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class CutsceneManager : MonoBehaviour
{

    [SerializeField] private Transform room4;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private GameObject _playerUICanvas;
    [SerializeField] private GameObject _introCanvas;
    [SerializeField] private GameObject _street;
    [SerializeField] private GameObject _room4;
    [SerializeField] private FlashlightSimple fonarik;
    [SerializeField] private PlayableDirector _cutscene;
    [SerializeField] private AudioSource outdoorSource;
    [SerializeField] private AudioSource indoorSource;
    [SerializeField] private GameObject sc;

    public bool isOpen;

    // Включение катсцены, в головоломке при решении постаить значение true и здесь в условии его записать
    private void OnTriggerEnter(Collider other)
    {
        if (isOpen && other.CompareTag("Player"))
        {
            room4.localPosition = new Vector3(-7.53599977f, 0, -26.1599998f);
            sc.GetComponent<MusicCrossfadeZone>().enabled = false;
            outdoorSource.volume = 0.1f;
            indoorSource.volume = 0f;
            indoorSource.Stop();
            outdoorSource.Play();
            _cutscene.Play();
        }
    }

    public void StartCutscene()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        _playerController.enabled = false;
        _playerUICanvas.SetActive(false);
    }

    public void StartOutroCutscene()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        _playerController.enabled = false;
        _playerUICanvas.SetActive(false);
        _introCanvas.SetActive(true);
    }
    
    public void ExitToStreet()
    {
        _street.SetActive(true);
        fonarik.enabled = false;
    }

    public void DeactiveRoom()
    {
        _room4.SetActive(false);
    }

    public void ToMenu()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(0);
    }

    public void StartGame()
    {
        _playerController.enabled = true;
        _playerUICanvas.SetActive(true);
        _introCanvas.SetActive(false);
    }
}
