using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;

    private enum MovementState { idle, running, jumping, falling };

    [SerializeField] private LayerMask jumpableGround;

    [SerializeField] private AudioSource attakSoundEffect;

    [SerializeField] private GameObject Bullet;

    [SerializeField] private Transform FirePoint;

    [SerializeField] private KeyCode right;
    [SerializeField] private KeyCode left;
    [SerializeField] private KeyCode jump;
    [SerializeField] private KeyCode attack;

    [SerializeField] private float moveSpeed = 10;
    [SerializeField] private float jumpForce = 17;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        MovementAndAnimation();
        Attack();
    }

    private void Attack()
    {
        if (Input.GetKeyDown(attack))
        {
            GameObject bulletClone = (GameObject)Instantiate(Bullet, FirePoint.position, FirePoint.rotation);

            attakSoundEffect.Play();

            bulletClone.transform.localScale = transform.localScale;
        }
    }

    private void MovementAndAnimation()
    {
        MovementState state;

        if (Input.GetKey(right))
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            state = MovementState.running;
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (Input.GetKey(left))
        {
            rb.velocity = new Vector2(-1 * moveSpeed, rb.velocity.y);
            state = MovementState.running;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            state = MovementState.idle;
        }

        if (Input.GetKeyDown(jump) && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (rb.velocity.y > +.1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
