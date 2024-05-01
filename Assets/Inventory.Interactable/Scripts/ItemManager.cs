using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    [SerializeField]
    private string _itemName;
    [SerializeField]
    private int _quantity;
    [SerializeField]
    private Sprite _itemSprite;

    private InventoryManager _inventoryManager;

    void Start()
    {
        _inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            _inventoryManager.AddItem(_itemName, _quantity, _itemSprite);
            Destroy(gameObject);
        }
    }
}
