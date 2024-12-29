using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class InventorySlot : MonoBehaviour
{
    public InventoryVR inventory;
    public GameObject ItemInSlot;
    public Image slotImage;
    Color originalColor;
    GameObject obj;
    XRSocketInteractor socketInteractor;
    void Awake()
    {
       
        originalColor = slotImage.color;
        
        
    }
    
    void Update()
    {
    
    }


    public void InsertItem()
    {
        socketInteractor = GetComponent<XRSocketInteractor>();
        obj = socketInteractor.GetOldestInteractableSelected().transform.gameObject;
        obj.GetComponent<InventoryItem>().inSlot= true;
        obj.GetComponent<InventoryItem>().currentSlot = this;
        InventoryManager.inventoryItems[obj.name] = true;
        Debug.Log(obj.name + " = " + InventoryManager.inventoryItems[obj.name]);
        ItemInSlot = obj;
        slotImage.color=Color.gray;
    }
    public void ExtractItem()
    {
        if (inventory.UIActive)
        {
            obj.GetComponent<InventoryItem>().inSlot = false;
            obj.GetComponent<InventoryItem>().currentSlot = null;
            InventoryManager.inventoryItems[obj.name] = false;
            Debug.Log(obj.name + " = " + InventoryManager.inventoryItems[obj.name]);
            ItemInSlot = null;
            slotImage.color = originalColor;
        }
    }

}
