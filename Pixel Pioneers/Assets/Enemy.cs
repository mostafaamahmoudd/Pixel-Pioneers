using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform target;

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
