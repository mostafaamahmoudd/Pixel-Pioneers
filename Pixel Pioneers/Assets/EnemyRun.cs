using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRun : StateMachineBehaviour
{
    private Transform player;
    private Rigidbody2D rb;
    private Enemy enemy;

    [SerializeField] private float speed = 7f;
    [SerializeField] private float attackRange = 2.79f;
    [SerializeField] private float idleRange = 10f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        enemy = animator.GetComponent<Enemy>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy.LookAtPlayer();

        Vector2 target = new Vector2(player.position.x, animator.transform.position.y);
        Vector2 newPos = Vector2.MoveTowards(animator.transform.position, target, speed * Time.deltaTime);

        if (Vector2.Distance(player.position, rb.position) > attackRange)
        {
            animator.transform.position = newPos;
        }
        else if (Vector2.Distance(player.position, rb.position) <= attackRange)
        {
            animator.SetTrigger("Attack");
        }
        
        if (Vector2.Distance(player.position, rb.position) > idleRange)
        {
            animator.SetBool("isFollowing", false);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }
}
