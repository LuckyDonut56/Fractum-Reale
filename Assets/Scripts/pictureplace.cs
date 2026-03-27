using UnityEngine;

public class pictureplace : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        if (this.transform.childCount == 2)
        {
            foreach (var x in Inventory.Instance.inventory)
            {
                if (x.name == "Picture1" || x.name == "Picture2" || x.name == "Picture3")
                {
                    x.transform.parent = this.transform;
                    x.SetActive(true);
                    x.transform.position = gameObject.transform.Find("Pivot").position;
                    if (x.name == "Picture1") x.GetComponent<Transform>().rotation = Quaternion.Euler(-90, 0, 0);
                    else x.GetComponent<Transform>().rotation = Quaternion.Euler(-90, 0, 180);
                    Inventory.Instance.RemoveObject(x);
                    break;
                }
            }
        }
    }
}
