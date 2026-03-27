using UnityEngine;

public class OpenPictureDoor : MonoBehaviour, IInteractable
{
    public Transform smallColumn;
    public Transform mediumColumn;
    public Transform bigColumn;
    public Transform picture1;
    public Transform picture2;
    public Transform picture3;
    public float rot1;
    public float rot2;
    public float rot3;
  
    bool IsSolvePuzzle()
    {
        if (picture1.IsChildOf(smallColumn) && picture3.IsChildOf(mediumColumn) && picture2.IsChildOf(bigColumn))
            if (Mathf.Round(picture1.localEulerAngles.x) == rot1 && Mathf.Round(picture2.localEulerAngles.x) == rot2 && Mathf.Round(picture3.localEulerAngles.x) == rot3)
                return true;
        return false;
    }
    public void Interact()
    {
        var door = GetComponent<Door>();
        if (!door.enabled)
            door.doorOpen.Play();
        if(IsSolvePuzzle())
        {
            door.enabled = true;
            enabled = false;
        }
    }
}
