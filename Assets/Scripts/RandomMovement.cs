using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomMovement : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    private NavMeshAgent agent;

    public bool canMove = true;
    public float speed = 2.0f;
    private Coroutine waitCoroutine;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void FixedUpdate()
    {
        if (canMove)
        {
            if (player != null)
            {
                agent.SetDestination(player.position);
                agent.speed = speed;
            }
        }
        else
        {
            agent.SetDestination(transform.position);
           if (waitCoroutine == null) // Start the coroutine only if it's not running
            {
                waitCoroutine = StartCoroutine(Wait());
            }

        }
        
    }


    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);
        canMove = true;
        waitCoroutine = null; // Reset the coroutine reference
    }
}
