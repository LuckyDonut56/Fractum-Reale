using UnityEngine;

public class buttonrotate : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        if (this.transform.parent.Find("Picture1") != null)
        this.transform.parent.Find("Picture1").transform.Rotate(0, 45, 0);
        if (this.transform.parent.Find("Picture2") != null)
            this.transform.parent.Find("Picture2").transform.Rotate(0, 45, 0);
        if (this.transform.parent.Find("Picture3") != null)
            this.transform.parent.Find("Picture3").transform.Rotate(0, 45, 0);
    }
}
