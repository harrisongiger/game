using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RangedEnemy : MonoBehaviour
{
    public Transform player;
    ThirdPersonPlayerController pc;
    NavMeshAgent agent;
    public float attackRate = 1;
    private float distToPlayer;
    public float viewRange = 1;
    public float shootRange = .75f;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        pc = player.gameObject.GetComponent<ThirdPersonPlayerController>();
        if (pc == null)
        {
            Debug.Log("theres no player controller lolz");
        }
    }

    // Update is called once per frame
    void Update()
    {
        distToPlayer = Vector3.Distance(player.position, transform.position);

        if (distToPlayer <= viewRange)
        {
            if (distToPlayer >= viewRange)
            {
                agent.SetDestination(player.position);
                
            } else
            {
                agent.ResetPath();
            }
        }
    }
}
