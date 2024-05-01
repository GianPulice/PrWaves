using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventario : MonoBehaviour
{
    private Cola<GameObject> itemQueue;
    private int maxSlots = 2;
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
            GameObject oldItem = itemQueue.Tomar();
            Destroy(oldItem);
        }

        itemQueue.Encolar(item);
        UpdateInventoryText();
    }

    private void UseItem()
    {
        if (itemQueue.Count > 0)
        {
            GameObject itemToUse = itemQueue.Tomar();

            // Verificar si el objeto todavía es válido
            if (itemToUse != null)
            {
                heal healItem = itemToUse.GetComponent<heal>();
                ammo ammoItem = itemToUse.GetComponent<ammo>();

                // Resto del código...

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
            }
            itemQueue.Desencolar();
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
            string itemName = item.name.Replace("(Clone)", ""); 
            inventoryContent += itemName + "\n";
        }
        inventoryText.text = inventoryContent;
    }
}