using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEditor;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public GameObject _inventoryMenu;
    private bool _menuOpen;
    public Image _imageMenu;
    public Image _imageInventorySlots;
    public Image _imageItemSlot;
    public Image _imageInventoryDescription;
    public Image _imageItemImage;
    public Image _imageItemDescription;

    public enum GameState
    {
        Paused = 0,
        Running = 1
    }

    [Header("Customizable Features")]
    [SerializeField]
    [Tooltip("Is the game paused or running in the background when inventory is opened")]
    private GameState _gameState;
    [SerializeField]
    [Tooltip("Which key should be pressed to open the inventory")]
    public KeyCode _openInventory = KeyCode.I;
    //InvalidOperationException: You are trying to read Input using the UnityEngine.Input class, but you have switched active Input handling to Input System package in Player Settings.
    //UnityEngine.Input.GetKey(UnityEngine.KeyCode key
   

       [Header("UI Colors")]
    [SerializeField]
    [ColorUsage(true)]
    private Color _menu;
    [SerializeField]
    [ColorUsage(true)]
    private Color _inventorySlots;
    [SerializeField]
    [ColorUsage(true)]
    private Color _itemSlot;
    [SerializeField]
    [ColorUsage(true)]
    private Color _inventoryDescription;
    [SerializeField]
    [ColorUsage(true)]
    private Color _itemImage;
    [SerializeField]
    [ColorUsage(true)]
    private Color _itemDescription;


    void Update()
    {
        // Opens Inventory when key is pressed
        //Pauses game when inventory is open
        if ((Input.GetKey(_openInventory)) && _menuOpen)
        {
            Time.timeScale = 1;
            _inventoryMenu.SetActive(false);
            _menuOpen = false;
        }
        else if ((Input.GetKey(_openInventory)) && !_menuOpen)
        {
            Time.timeScale = (float)_gameState;
            _inventoryMenu.SetActive(true);
            _menuOpen = true;
        }

        UIColor();
    }

    [SerializeField]
    public void UIColor()
    {
        _imageMenu.color = _menu;
        _imageInventorySlots.color = _inventorySlots;
        _imageItemSlot.color = _itemSlot;
        _imageInventoryDescription.color = _inventoryDescription;
        _imageItemImage.color = _itemImage;
        _imageItemDescription.color = _itemDescription;
    }
}
