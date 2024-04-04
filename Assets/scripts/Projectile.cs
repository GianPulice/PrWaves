using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    private Vector2 direction;




    void Update()
    {
        
        transform.Translate(direction * speed * Time.deltaTime);

       
        if (!GetComponent<Renderer>().isVisible)
        {
            Destroy(gameObject);
        }
    }

    public void SetDirection(Vector2 dir)
    {
        direction = dir;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);

            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                characterMovment playerMovement = player.GetComponent<characterMovment>();
                if (playerMovement != null)
                {
                    playerMovement.AddCredits(50);
                }
            }
        }

    }

}
