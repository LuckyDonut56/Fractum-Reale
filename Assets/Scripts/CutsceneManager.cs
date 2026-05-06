using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private GameObject _playerUICanvas;
    [SerializeField] private GameObject _introCanvas;

    public void StartCutscene()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    public void StartGame()
    {
        _playerController.enabled = true;
        _playerUICanvas.SetActive(true);
        _introCanvas.SetActive(false);
    }
}
