using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletExample : MonoBehaviour
{

    public GameObject player;

    public Rigidbody2D rb;

    public float Force = 5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * Force;
    }

    private void Update()
    {
        
    }
}
