using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRun : StateMachineBehaviour
{
    [SerializeField] private GameObject[] players;
    [SerializeField] private GameObject nearestPlayer;

    float distance;
    float nearestDis = 100f;

    private Rigidbody2D rb;
    private Enemy enemy;

    [SerializeField] private float speed = 7f;
    [SerializeField] private float attackRange = 2.79f;
    [SerializeField] private float idleRange = 10f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        players = GameObject.FindGameObjectsWithTag("Player");

        rb = animator.GetComponent<Rigidbody2D>();
        enemy = animator.GetComponent<Enemy>();

        for (int i = 0; i < players.Length; i++)
        {
            distance = Vector2.Distance(animator.transform.position, players[i].transform.position);

            if (distance < nearestDis)
            {
                nearestPlayer = players[i];
                nearestDis = distance;
            }
        }
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy.LookAtPlayer();

        Vector2 target = new Vector2(nearestPlayer.transform.position.x, animator.transform.position.y);
        Vector2 newPos = Vector2.MoveTowards(animator.transform.position, target, speed * Time.deltaTime);

        if (Vector2.Distance(nearestPlayer.transform.position, rb.position) > attackRange)
        {
            animator.transform.position = newPos;
        }
        else if (Vector2.Distance(nearestPlayer.transform.position, rb.position) <= attackRange)
        {
            animator.SetTrigger("Attack");
        }
        
        if (Vector2.Distance(nearestPlayer.transform.position, rb.position) > idleRange)
        {
            animator.SetBool("isFollowing", false);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }
}
