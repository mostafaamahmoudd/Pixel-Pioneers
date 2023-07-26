using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AWSD_Move : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float speed;
    
    private float MovementX;
    private float MovementY;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        MovementX = 0;
        MovementY = 0;
    }

    void Update()
    {
        rb.velocity = new Vector2(MovementX * speed * Time.deltaTime, MovementY * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.W))
        {
            MovementY = 1;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            MovementY = -1;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            MovementX = 1;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            MovementX = -1;
        }

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            MovementY = 0;
        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            MovementX = 0;
        }
    }
}
