using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventario : MonoBehaviour
{
    private Cola<GameObject> itemQueue;
    private int maxSlots = 3; // Ajustado a 3 para mejor gestión de límite
    public Text inventoryText;

    void Start()
    {
        itemQueue = new Cola<GameObject>();
        UpdateInventoryText();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            UseItem();
        }
    }

    public void AddItem(GameObject item)
    {
        if (itemQueue.Count >= maxSlots)
        {
            GameObject oldItem = itemQueue.Remover(); 
            Destroy(oldItem);
        }

        itemQueue.Agregar(item);
        UpdateInventoryText();
    }

    private void UseItem()
    {
        if (itemQueue.Count > 0)
        {
            GameObject itemToUse = itemQueue.Remover(); 

            if (itemToUse != null)
            {
                heal healItem = itemToUse.GetComponent<heal>();
                ammo ammoItem = itemToUse.GetComponent<ammo>();

                if (healItem != null)
                {
                    characterMovment player = GetComponent<characterMovment>();
                    if (player != null)
                    {
                        player.Heal(healItem.healthToAdd);
                    }
                }

                if (ammoItem != null)
                {
                    characterMovment player = GetComponent<characterMovment>();
                    if (player != null)
                    {
                        player.AddAmmo(ammoItem.ammoToAdd);
                    }
                }

                Destroy(itemToUse); 
            }

            UpdateInventoryText();
        }
        else
        {
            Debug.Log("El inventario está vacío.");
        }
    }

    private void UpdateInventoryText()
    {
        string inventoryContent = "Inventario:\n";
        foreach (GameObject item in itemQueue)
        {
            if (item != null)
            {
                string itemName = item.name.Replace("(Clone)", "");
                inventoryContent += itemName + "\n";
            }
        }
        inventoryText.text = inventoryContent;
    }
}