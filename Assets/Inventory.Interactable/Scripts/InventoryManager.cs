using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEditor;
using UnityEngine.UI;

[ExecuteInEditMode]
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
    /*
    [SerializeField]
    [Tooltip("Which key should be pressed to open the inventory")]
    public KeyCode _openInventory = KeyCode.I;
    */
    //InvalidOperationException: You are trying to read Input using the UnityEngine.Input class, but you have switched active Input handling to Input System package in Player Settings.
    //UnityEngine.Input.GetKey(UnityEngine.KeyCode key


    [Header("UI Colors")]
    //[SerializeField]
    [ColorUsage(true)]
    public Color _menu;
   // [SerializeField]
    [ColorUsage(true)]
    public Color _inventorySlots;
   // [SerializeField]
    [ColorUsage(true)]
    public Color _itemSlot;
   // [SerializeField]
    [ColorUsage(true)]
    public Color _inventoryDescription;
   // [SerializeField]
    [ColorUsage(true)]
    public Color _itemImage;
   // [SerializeField]
    [ColorUsage(true)]
    public Color _itemDescription;


    void Update()
    {
        // Opens Inventory when key is pressed
        //Pauses game when inventory is open
       
        if (Keyboard.current.iKey.wasPressedThisFrame && _menuOpen)
        {
            Time.timeScale = 1;
            _inventoryMenu.SetActive(false);
            _menuOpen = false;
        }
        else if (Keyboard.current.iKey.wasPressedThisFrame && !_menuOpen)
        {
            Time.timeScale = (float)_gameState;
            _inventoryMenu.SetActive(true);
            _menuOpen = true;
        }
    

#if UNITY_EDITOR
        UIColor();
#endif
    }

    [SerializeField]
    [ContextMenu("Update UI Color")]
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

[CustomEditor(typeof(InventoryManager))]
public class InventoryManagerEditor : Editor
{
    SerializedProperty _inventoryMenu;
    SerializedProperty _imageMenu;
    SerializedProperty _imageInventorySlots;
    SerializedProperty _imageItemSlot;
    SerializedProperty _imageInventoryDescription;
    SerializedProperty _imageItemImage;
    SerializedProperty _imageItemDescription;

    SerializedProperty _gameState;
    SerializedProperty _menu;
    SerializedProperty _inventorySlots;
    SerializedProperty _itemSlot;
    SerializedProperty _inventoryDescription;
    SerializedProperty _itemImage;
    SerializedProperty _itemDescription;


    bool showInfo, showCustom = false;

    void OnEnable()
    {
        _inventoryMenu = serializedObject.FindProperty("inventoryMenu");
        _imageMenu = serializedObject.FindProperty("imageMenu");
        _imageInventorySlots = serializedObject.FindProperty("imageInventorySlots");
        _imageItemSlot = serializedObject.FindProperty("imageItemSlot");
        _imageInventoryDescription = serializedObject.FindProperty("imageInventoryDescription");
        _imageItemImage = serializedObject.FindProperty("imageItemImage");
        _imageItemDescription = serializedObject.FindProperty("imageItemDescription");

        _gameState = serializedObject.FindProperty("gameState");
        _menu = serializedObject.FindProperty("menu");
        _inventorySlots = serializedObject.FindProperty("inventorySlots");
        _itemSlot = serializedObject.FindProperty("itemSlot");
        _inventoryDescription = serializedObject.FindProperty("inventoryDescription");
        _itemImage = serializedObject.FindProperty("itemImage");
        _itemDescription = serializedObject.FindProperty("itemDescription");

    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        showInfo = EditorGUILayout.Foldout(showInfo, "Don't Change");
        if (showInfo)
        {
            EditorGUILayout.PropertyField(_inventoryMenu);
            EditorGUILayout.PropertyField(_imageMenu);
            EditorGUILayout.PropertyField(_imageInventorySlots);
            EditorGUILayout.PropertyField(_imageItemSlot);
            EditorGUILayout.PropertyField(_imageInventoryDescription);
            EditorGUILayout.PropertyField(_imageItemImage);
            EditorGUILayout.PropertyField(_imageItemDescription);
        }
        //EditorGUILayout.EndFoldoutHeaderGroup();

        showCustom = EditorGUILayout.Foldout(showCustom, "Customizable Features");
        if (showCustom)
        {
            EditorGUILayout.PropertyField(_gameState);
            EditorGUILayout.PropertyField(_menu);
            EditorGUILayout.PropertyField(_inventorySlots);
            EditorGUILayout.PropertyField(_itemSlot);
            EditorGUILayout.PropertyField(_inventoryDescription);
            EditorGUILayout.PropertyField(_itemImage);
            EditorGUILayout.PropertyField(_itemDescription);
        }
        //EditorGUILayout.EndFoldoutHeaderGroup();

        serializedObject.ApplyModifiedProperties();
    }

}

