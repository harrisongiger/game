using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeleeEnemy : MonoBehaviour
{
    public Transform player;
    ThirdPersonPlayerController pc;
    NavMeshAgent agent;
    public float attackRate = 1;
    private float nextAttack;
    private float distToPlayer;
    public float enemyRange = 1;
    

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        pc = player.gameObject.GetComponent<ThirdPersonPlayerController>();
        if(pc == null)
        {
            Debug.Log("theres no player controller lolz");
        }
    }

    void Update()
    {
        distToPlayer = Vector3.Distance(player.position, transform.position);

        if (distToPlayer <= enemyRange)
        {
            agent.SetDestination(player.position);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Time.time > nextAttack)
        {
            pc.health--;
            nextAttack = Time.time + attackRate;
        }
    }
}
