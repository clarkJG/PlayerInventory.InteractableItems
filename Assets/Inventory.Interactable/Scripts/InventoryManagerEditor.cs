using UnityEditor;

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
