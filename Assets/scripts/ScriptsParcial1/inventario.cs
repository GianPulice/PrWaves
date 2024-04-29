using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventario : MonoBehaviour
{
    private Queue<GameObject> itemQueue;
    private int maxSlots = 3;
    public Text inventoryText;

    void Start()
    {
        itemQueue = new Queue<GameObject>();
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
            GameObject oldItem = itemQueue.Dequeue();
            Destroy(oldItem);
        }

        itemQueue.Enqueue(item);
        UpdateInventoryText();
    }

    
    private void UseItem()
    {
        
            if (itemQueue.Count > 0)
            {


            GameObject itemToUse = itemQueue.Peek();

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
                
                itemQueue.Dequeue();
                Destroy(itemToUse);
            UpdateInventoryText();
        }
            else
        {
            Debug.Log("vacio");
        }
    }
    private void UpdateInventoryText()
    {
        string inventoryContent = "Inventario:\n";
        foreach (GameObject item in itemQueue)
        {
            
            string itemName = item.name.Replace("(Clone)", "");
            inventoryContent += "- " + itemName + "\n";
        }
        inventoryText.text = inventoryContent;
    }

}
