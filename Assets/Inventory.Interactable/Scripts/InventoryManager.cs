using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryManager : MonoBehaviour
{
    // Opens Inventory when key is pressed
    //Pauses game when inventory is open

    public GameObject _inventoryMenu;
    private bool _menuOpen;
    void Start()
    {
        
    }


    void Update()
    {
        if ((Keyboard.current.iKey.wasPressedThisFrame) && _menuOpen)
        {
            Time.timeScale = 1;
            _inventoryMenu.SetActive(false);
            _menuOpen = false;
        }
        else if ((Keyboard.current.iKey.wasPressedThisFrame) && !_menuOpen)
        {
            Time.timeScale = 0;
            _inventoryMenu.SetActive(true);
            _menuOpen = true;
        }
    }
}
