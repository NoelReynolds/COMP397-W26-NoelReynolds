using UnityEngine;
using KBCore.Refs;
using UnityEngine.AI;
using System.Collections.Generic;
using System.Linq;

[RequireComponent(typeof(NavMeshAgent))]
public class NPCMovementScript : MonoBehaviour
{
    [SerializeField, Self] private NavMeshAgent agent;
    [SerializeField] private List<GameObject> waypoints = new List<GameObject>();
    private Vector3 destination;
    private int index;

    private void OnValidate()
    {
        this.ValidateRefs();
    }

    void Start()
    {
        waypoints = GameObject.FindGameObjectsWithTag("waypoint").ToList();
        if (waypoints.Count < 0) return;
        agent.destination = waypoints[index].transform.position;
    }

    void Update()
    {
        if (waypoints.Count < 0) return;
        if (Vector3.Distance(agent.destination, destination) < 3f)
        {
            index = (index + 1) % waypoints.Count;
            destination = waypoints[index].transform.position;
            agent.destination = destination;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            destination = other.transform.position;
            agent.destination = destination;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            destination = waypoints[index].transform.position;
            agent.destination = destination;
        }
    }
}
