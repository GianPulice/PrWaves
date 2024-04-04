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
    public Text creditsText;

    void Start()
    {
        currentHealth = maxHealth;
        currentProjectiles = maxProjectiles;
    }

    void Update()
    {
        
        UpdateUI();

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");


        Vector2 movement = new Vector2(horizontalInput, verticalInput).normalized * speed * Time.deltaTime;

        transform.Translate(movement);

     
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

    public void AddCredits(int amount)
    {
        credits += amount; 
        UpdateUI(); 
    }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Enemy"))
            {
                TakeDamage(10);
            }

        if (other.CompareTag("ammo"))
        {
            if (Input.GetKey(KeyCode.E) && credits >= 500)
            {
                currentProjectiles = maxProjectiles; 
                credits -= 500; 
                UpdateUI();
            }
        }

        if (other.CompareTag("Door"))
        {
            if (Input.GetKey(KeyCode.E) && credits >= 1800)
            {
                credits -= 1000;
                Destroy(other.gameObject);
            }
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

            if (creditsText != null)
            {
                creditsText.text = "Credits: " + credits.ToString(); 
            }
    }
}

