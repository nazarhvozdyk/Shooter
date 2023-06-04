using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemIconContent : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _amountText;

    [SerializeField]
    private Image _image;

    public void SetUp(int amount, Sprite sprite)
    {
        if (amount == 1)
            _amountText.text = string.Empty;
        else
            _amountText.text = amount.ToString();

        _image.sprite = sprite;
    }
}
