using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField]
    private string _itemName;
    [SerializeField]
    private string _quantity;
    [SerializeField]
    private string _itemSprite;

    private InventoryManager _inventoryManager;

    void Start()
    {
        _inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            _inventoryManager.AddItem(_itemName, _quantity, _itemSprite);
            Destroy(gameObject);
        }
    }
}
