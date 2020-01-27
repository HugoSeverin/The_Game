using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform wayPoint1, wayPoint2;
    private Transform wayPointTarget;
    [SerializeField] private float moveSpeed;

    [SerializeField] private float attackRange;
    private SpriteRenderer sp;
    private Transform target;

    // Partie projectile
    private Animator anim;
    public GameObject projectile;
    public Transform firePoint;

    private void Start()
    {
        wayPointTarget = wayPoint1;
        sp = GetComponent<SpriteRenderer>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, target.position) >= attackRange)
        {
            anim.SetBool("isAttack", false);
            Patrol();

        }
        else
        {
            anim.SetBool("isAttack", true);
        }

        TakeDamage(GetComponentInChildren<Arrow>().damage);

        // detruire le mob quand il est à 0hp
        if(GetComponentInChildren<HealthBar>().hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void TakeDamage(int damage)
    {
        GetComponentInChildren<HealthBar>().hp -= damage;

        // detruire le mob quand il est à 0hp
        if (GetComponentInChildren<HealthBar>().hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Patrol()
    {
        transform.position = Vector2.MoveTowards(transform.position, wayPointTarget.position, moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, wayPoint1.position) <= 0.01f)
        {
            wayPointTarget = wayPoint2;
            //sp.flipX = true;
            Vector3 localTemp = transform.localScale;
            localTemp.x *= -1;
            transform.localScale = localTemp;
        }

        if (Vector2.Distance(transform.position, wayPoint2.position) <= 0.01f)
        {
            wayPointTarget = wayPoint1;
            //sp.flipX = false;
            Vector3 localTemp = transform.localScale;
            localTemp.x *= -1;
            transform.localScale = localTemp;
        }
    }

    public void Shot()
    {
        Instantiate(projectile, firePoint.position, Quaternion.identity);
    }
}
