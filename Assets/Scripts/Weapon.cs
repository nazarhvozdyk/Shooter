using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField]
    private Item _item;

    public Item Item
    {
        get => _item;
    }
}
