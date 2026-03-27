using UnityEngine;
using UnityEngine.Rendering;

public class picturespick : MonoBehaviour, IInteractable
{
    public AudioSource pickUpSound;
    public void Interact()
    {
        bool b = true;
        GameObject pic = null;
        foreach (var x in Inventory.Instance.inventory)
        {
            if (x.name == "Picture1"|| x.name == "Picture2" ||x.name == "Picture3") 
            {
                b = false;
                pic = x;
            }
        }
        if (b)
        {
            pickUpSound.Play();
            Inventory.Instance.AddObject(gameObject);
            if (this.transform.parent != null)
                this.transform.parent = null;
        }
        else
        {
            var x = this.transform.parent;
            var y = this.transform.position;
            var z = this.transform.rotation;
            this.transform.parent = pic.transform.parent;
            this.transform.position = pic.transform.position;
            this.transform.rotation = pic.transform.rotation;
            pic.transform.parent=x;
            pic.transform.position=y;
            pic.transform.rotation=z;
            if (this.name == "Picture1" || pic.name == "Picture1") {
                pic.transform.Rotate(0, 0, 180);
            }
            Inventory.Instance.AddObject(gameObject);
            Inventory.Instance.RemoveObject(pic);
            pic.SetActive(true);
        }
        
    }
}
