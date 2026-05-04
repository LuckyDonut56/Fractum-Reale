using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private GameObject _playerUICanvas;

    public void StartCutscene()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    public void StartGame()
    {
        _playerController.enabled = true;
        _playerUICanvas.SetActive(true);    
    }
}
