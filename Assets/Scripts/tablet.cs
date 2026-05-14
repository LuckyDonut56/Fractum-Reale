using System;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class tablet : MonoBehaviour, IInteractable
{
    public int[] sol = new int[5];
    [SerializeField] int[] state = new int[5]{0,0,0,0,0};
    [SerializeField] private Camera playerCamera;
    [SerializeField] private Camera tabletCamera;
    [SerializeField] private PlayerController PlayerController;
    public bool isActive = false;
    public GameObject crosshair;
    [SerializeField] private Material mOFF;
    [SerializeField] private Material mON; 
    [SerializeField] private CutsceneManager cm;
    
    void Start()
    {
        
    }
    void Update()
    {
        if (isActive && Input.GetMouseButtonDown(0))
        {
            Ray ray = tabletCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 10f))
            {
                buttontablet button = hit.collider.GetComponent<buttontablet>();
                if (button != null)
                {
                    button.Interact();
                }
            }
        }
        if (isActive && Input.GetKeyDown(KeyCode.Escape))
        {
            Stop();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1;
            PlayerController.enabled = true;
        }
            if (isSolved()) cm.isOpen = true;
            else cm.isOpen = false;

    }
    public void Interact()
    { 
        gameObject.GetComponent<Collider>().enabled = false;
        PlayerController.enabled = false;
        isActive = true;
        tabletCamera.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        crosshair.gameObject.SetActive(false);
        gameObject.GetComponent<Collider>().enabled = false;
    }
    void Stop()
    {
        tabletCamera.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        crosshair.gameObject.SetActive(true);
        gameObject.GetComponent<Collider>().enabled = true;
        isActive = false;
    }
    public void pressed(int row, int col)
    {
        if (state[row-1] > 0 && state[row-1]  < 4)
        {
            GameObject.Find("TabletButton" + row + ".00" + state[row-1]).GetComponent<Renderer>().material = mOFF;
        }
        GameObject.Find("TabletButton" + row  + ".00" + col).GetComponent<Renderer>().material = mON;
        state[row-1] = col;
    }
    public bool isSolved()
    {
        return state[0] == sol[0] && state[1] == sol[1] && state[2] == sol[2] && state[3] == sol[3] && state[4] == sol[4];
    }
}
