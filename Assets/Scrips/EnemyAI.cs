using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public GameObject player;
    private NavMeshAgent agent = null;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

    }
    void Update()
    {
        agent.SetDestination(player.transform.position);
    }


}
