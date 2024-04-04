using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovment : MonoBehaviour
{
    public float speed = 3f;
    public Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player == null)
            return;

        Vector2 direction = (player.position - transform.position).normalized;

        transform.Translate(direction * speed * Time.deltaTime);
    }

}
