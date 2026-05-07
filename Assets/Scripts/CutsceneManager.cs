using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class CutsceneManager : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private GameObject _playerUICanvas;
    [SerializeField] private GameObject _introCanvas;
    [SerializeField] private GameObject _street;
    [SerializeField] private GameObject _room4;
    [SerializeField] private FlashlightSimple fonarik;
    [SerializeField] private PlayableDirector _cutscene;

    public bool isOpen;

    // Включение катсцены, в головоломке при решении постаить значение true и здесь в условии его записать
    private void OnTriggerEnter(Collider other)
    {
        if (isOpen && other.CompareTag("Player"))
            _cutscene.Play();
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
        SceneManager.LoadScene(0);
    }

    public void StartGame()
    {
        _playerController.enabled = true;
        _playerUICanvas.SetActive(true);
        _introCanvas.SetActive(false);
    }
}
