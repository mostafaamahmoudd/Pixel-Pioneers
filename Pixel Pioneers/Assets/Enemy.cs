using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator anim;

    [SerializeField] private Transform target;

    [SerializeField] private float health, maxHealth = 3f;

    private void Start()
    {
        anim = GetComponent<Animator>();

        health = maxHealth;
    }

    public void TakeDamage(float _damage)
    {
        health -= _damage;

        anim.SetTrigger("hurt");

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void LookAtPlayer()
    {

        if (transform.position.x > target.position.x)
        {            
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else if (transform.position.x < target.position.x)
        {           
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);            
        }
    }
}
