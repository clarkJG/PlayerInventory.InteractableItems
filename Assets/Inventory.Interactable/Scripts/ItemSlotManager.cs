using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemSlotManager : MonoBehaviour
{
    //Item Data
    public string _itemName;
    public int _quantity;
    public Sprite _itemSprite;
    public bool isFull;


    //Item Slot
    [SerializeField]
    private TMP_Text _quantityText;

    [SerializeField]
    private Image _itemImage;

    public void AddItem(string _itemName, int _quantity, Sprite _itemSprite)
    {
        this._itemName = _itemName;
        this._quantity = _quantity;
        this._itemSprite = _itemSprite;
        isFull = true;

        _quantityText.text = _quantity.ToString();
        _quantityText.enabled = true;
        _itemImage.sprite = _itemSprite;
    }
}
