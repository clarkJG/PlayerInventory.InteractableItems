using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ItemSlotManager : MonoBehaviour, IPointerClickHandler 
{
    //Item Data
    public string _itemName;
    public int _quantity;
    public Sprite _itemSprite;
    public bool isFull;
    public string _descriptionOfItem;
    public Sprite _emptySprite;

    [SerializeField]
    public int _maxNumOfItems;

    //Item Slot
    [SerializeField]
    private TMP_Text _quantityText;

    [SerializeField]
    private Image _itemImage;

    public GameObject _selectedShader;
    public bool _selectedItem;

    private InventoryManager _inventoryManager;

    [Tooltip("Follow the instruction doc to add the correct objects")]
    [Header("Connect Objects")]
    //Item description slot
    public Image _itemDescriptionImage;
    public TMP_Text ItemDescriptionName_txt;
    public TMP_Text ItemDescription_txt;

    private void Start()
    {
        _inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }
    public int AddItem(string _itemName, int _quantity, Sprite _itemSprite, string _descriptionOfItem)
    {
        //check to see if slot is full 
        if (isFull)
        {
            return _quantity;
        }
        //update name
        this._itemName = _itemName;

        //update sprite
        this._itemSprite = _itemSprite;
        _itemImage.sprite = _itemSprite;

        //updatae description
        this._descriptionOfItem = _descriptionOfItem;

        //update quantity
        this._quantity += _quantity;
        if (this._quantity >= _maxNumOfItems)
        {
            _quantityText.text = _quantity.ToString();
            _quantityText.enabled = true;
            isFull = true;

            //return leftovers
            int _extraItems = this._quantity - _maxNumOfItems;
            this._quantity = _maxNumOfItems;
            return _extraItems;
        }

        //update quantity text
        _quantityText.text = this._quantity.ToString();
        _quantityText.enabled = true;
        return 0;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }
        if(eventData.button == PointerEventData.InputButton.Right)
        {
            OnRightClick();
        }
    }

    public void OnLeftClick()
    {
        if (_selectedItem)
        {
            _inventoryManager.UseItem(_itemName);
            this._quantity -= 1;
            _quantityText.text = this._quantity.ToString();
            if(this._quantity <= 0)
            {
                EmpytSlot();
            }

        }
        else
        {
            _inventoryManager.DeselectAllSlots();
            _selectedShader.SetActive(true);
            _selectedItem = true;
            ItemDescriptionName_txt.text = _itemName;
            ItemDescription_txt.text = _descriptionOfItem;
            _itemDescriptionImage.sprite = _itemSprite;

            if (_itemDescriptionImage.sprite == null)
            {
                _ = _itemDescriptionImage.sprite == _emptySprite;
            }
        }

    }

    private void EmpytSlot()
    {
        _quantityText.enabled = false;
        _itemImage.sprite = _emptySprite;

        ItemDescriptionName_txt.text = "";
        ItemDescription_txt.text = "";
        _itemDescriptionImage.sprite = _emptySprite;

    }

    public void OnRightClick()
    {

    }

}
