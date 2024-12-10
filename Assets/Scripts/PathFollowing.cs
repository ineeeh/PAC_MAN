using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollowing : MonoBehaviour
{
    public Transform target; // Target to follow (you can set this to the player or any other point in the maze)
    private UnityEngine.AI.NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.SetDestination(target.position);
    }

    void Update()
    {
        // Check for obstacles in front of the agent
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1.0f))
        {
            // If an obstacle is detected, find a new random direction to move in
            if (hit.collider.CompareTag("Walls"))
            {
                Vector3 randomDirection = (transform.right * Random.Range(-1f, 1f)).normalized;
                agent.Move(randomDirection * agent.speed * Time.deltaTime);
            }
        }
    }
}
