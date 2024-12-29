// Script name: InventoryVR
// Script purpose: attaching a gameobject to a certain anchor and having the ability to enable and disable it.
// This script is a property of Realary, Inc

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;


public class InventoryVR : MonoBehaviour
{
    public GameObject Inventory;
    public GameObject Anchor;
    public InputActionProperty toggleInventory;
    private InventorySlot[] inventorySlots;
    GameObject[] itemsInInventorySlots ;
    public bool UIActive;
    private bool loadingSave=false;

    private void Start()
    {
        if (PlayerPrefs.GetInt("Load") == 1)
        {
            loadingSave = true;
        }
            int i = 0;
            itemsInInventorySlots = new GameObject[4];
            foreach (InventorySlot slot in Inventory.GetComponentsInChildren<InventorySlot>())
            {
                if (slot.ItemInSlot != null)
                {
                    itemsInInventorySlots[i] = slot.ItemInSlot;
                    slot.ItemInSlot.SetActive(loadingSave);
                    i++;
                }
            }
            Inventory.SetActive(loadingSave);
            UIActive = loadingSave;
        
        
    }

    private void Update()
    {
        if (toggleInventory.action.WasPressedThisFrame())
        {
            UIActive = !UIActive;
         
            if (!UIActive)
            {
                int i = 0;
                itemsInInventorySlots = new GameObject[4];
                foreach (InventorySlot slot in Inventory.GetComponentsInChildren<InventorySlot>())
                  {
                    if (slot.ItemInSlot != null)
                {
                    itemsInInventorySlots[i] = slot.ItemInSlot;
                    i++;
                    }
                }
            }
            else
            {
                Inventory.SetActive(UIActive);
            }
           if (itemsInInventorySlots != null)
            {
                foreach (GameObject obj in itemsInInventorySlots)
                {
                    
                   if (obj!=null)
                        obj.SetActive(UIActive);
                }
            }

            if (!UIActive)
            {
                Inventory.SetActive(UIActive);
            }
        }
        if (UIActive)
        {
            Inventory.transform.position = Anchor.transform.position;
            Inventory.transform.eulerAngles = new Vector3(Anchor.transform.eulerAngles.x + 15, Anchor.transform.eulerAngles.y, 0);
        }
    }
}