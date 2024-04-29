using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventario : MonoBehaviour
{
    private Queue<GameObject> itemQueue;
    private int maxSlots = 3;

    void Start()
    {
        itemQueue = new Queue<GameObject>();
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
                Debug.Log("Usando: " + itemToUse.name);
                itemQueue.Dequeue();
                Destroy(itemToUse);
            }
            else
        {
            Debug.Log("vacio");
        }
    }
}
