using UnityEngine;
using UnityEngine.AI;

public class EnemyNavigation : MonoBehaviour
{
 
    //void Start()
    //{
    //    var destination = GameObject.FindGameObjectWithTag("Player").transform.position;
    //    GetComponent<NavMeshAgent>().SetDestination(destination);
    //}
    private NavMeshAgent agent;
    private Transform player;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player").transform.transform;
    }

    void Update()
    {
        agent.SetDestination(player.position);
    }

}
