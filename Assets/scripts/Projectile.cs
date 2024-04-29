using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 5f;
    private Vector2 direction;

    private inventario inventario;

    void Start()
    {
        inventario = GameObject.FindGameObjectWithTag("Player").GetComponent<inventario>();
    }

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

        }

        if (other.CompareTag("Item"))
        {
            inventario.AddItem(other.gameObject);
            other.gameObject.SetActive(false);
        }

    }

}
