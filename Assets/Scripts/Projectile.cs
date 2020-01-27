using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Transform target;
    [SerializeField] private float moveSpeed;
    private float lifeTimer;
    [SerializeField] private float maxLife = 2.0f;

    public GameObject destroyEffect; // si ça se detruit au bout de 2sec
    public GameObject attackEffect; //si ça touche le joueur

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update() 
    {
        transform.position = Vector2.MoveTowards(transform.position,target.position, moveSpeed * Time.deltaTime);
        lifeTimer += Time.deltaTime;
        if(lifeTimer >= maxLife) // pour detruire le projectile apres 2sec
        {
            Instantiate(destroyEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.GetComponentInChildren<HealthBar>().hp -= 5;
            Instantiate(attackEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
