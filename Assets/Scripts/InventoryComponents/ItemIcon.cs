using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class ItemIcon : MonoBehaviour
{
    private static List<ItemIcon> _icons = new List<ItemIcon>();

    [SerializeField]
    private TextMeshProUGUI _amountText;

    [SerializeField]
    private Image _image;

    private void Start()
    {
        _icons.Add(this);
    }

    public void SetUp(Item item, int amount)
    {
        if (amount == 1)
            _amountText.text = string.Empty;
        else
            _amountText.text = amount.ToString();

        _image.sprite = item.sprite;
    }

    private void OnDestroy()
    {
        _icons.Remove(this);
    }

    public static void DestroyAll()
    {
        foreach (var icon in _icons)
            Destroy(icon.gameObject);
    }
}
