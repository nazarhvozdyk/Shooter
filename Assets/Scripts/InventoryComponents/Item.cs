using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Shooter/Item")]
public class Item : ScriptableObject
{
    public string intemName = "Item name";
    public int value;
    public Sprite sprite;
    public ItemType itemType;
    public GameObject itemPrefab;
    public GameObject droppedItemPrefab;
}
