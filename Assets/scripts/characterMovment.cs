using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class characterMovment : MonoBehaviour
{
    public float speed = 5f;

    public int maxHealth = 100;
    public int currentHealth;
    public GameObject projectilePrefab;
    public int maxProjectiles = 100;
    public int currentProjectiles;
    public int credits = 0;

    public Text healthText;
    public Text projectilesText;

    void Start()
    {
        currentHealth = maxHealth;
        currentProjectiles = maxProjectiles;
    }

    void Update()
    {
        
        UpdateUI();



     
        if (Input.GetMouseButtonDown(0) && currentProjectiles > 0)
        {
            ShootProjectile();
            currentProjectiles--;
        }
    }
    void ShootProjectile()
    {
        
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; 

        
        Vector2 shootDirection = (mousePosition - transform.position).normalized;

        
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        
        Projectile projectileComponent = projectile.GetComponent<Projectile>();
        if (projectileComponent != null)
        {
            projectileComponent.SetDirection(shootDirection);
        }
    }

  

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Enemy"))
            {
                TakeDamage(10);
            }

        

    }

        void TakeDamage(int damage)
        {
            currentHealth -= damage;

            
            if (currentHealth <= 0)
            {
                Die();
            }
        }

        void Die()
        {

            Destroy(gameObject);
        }

        void UpdateUI()
        {
            if (healthText != null)
            {
                healthText.text = "Health: " + currentHealth.ToString();
            }

            if (projectilesText != null)
            {
                projectilesText.text = "Projectiles: " + currentProjectiles.ToString();
            }

    }
}

