using UnityEngine;

public class picturespick : MonoBehaviour, IInteractable
{
    public AudioSource pickUpSound;
    public void Interact()
    {
        bool b = true;
        foreach (var x in Inventory.Instance.inventory)
        {
            if (x.name == "Picture1"|| x.name == "Picture2" ||x.name == "Picture3") 
            {
                b = false;
            }
        }
        if (b)
        {
            pickUpSound.Play();
            Inventory.Instance.AddObject(gameObject);
            if (this.transform.parent != null)
                this.transform.parent = null;
        }
        
    }
}
