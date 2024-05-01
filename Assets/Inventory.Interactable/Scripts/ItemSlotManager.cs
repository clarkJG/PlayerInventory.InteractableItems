using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlotManager : MonoBehaviour, IPointerClickHandler 
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

    public GameObject _selectedShader;
    public bool _selectedItem;

    private InventoryManager _inventoryManager;

    private void Start()
    {
        _inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }
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
        _inventoryManager.DeselectAllSlots();
        _selectedShader.SetActive(true);
        _selectedItem = true;
    }

    public void OnRightClick()
    {

    }
}
