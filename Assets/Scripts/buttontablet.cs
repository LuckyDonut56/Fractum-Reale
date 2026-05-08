using UnityEngine;

public class buttontablet : MonoBehaviour, IInteractable
{
    public int row;
    public int col;
    public tablet tablet;

    public void Interact()
    {
        tablet.pressed(row,col);
    }
}

