using NUnit.Framework;
using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
namespace platformer397
{
    public class EnemyNavigation : MonoBehaviour, IObserver
    {
        private NavMeshAgent agent;
        [SerializeField] private PlayerController player;
        [SerializeField] private List<Transform> waypoints = new List<Transform>();
        private int index = 0;
        [SerializeField] private float distancethreshold = 1.0f;
        private Vector3 destination;
        private void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
            destination = waypoints[index].position;
            player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();

        }
        private void OnEnable()
        {
            player.AddObserver(this);
        }
        private void OnDisable()
        {
            player.RemoveObserver(this);
        }

        void Update()
        {
            if (Vector3.Distance(destination, transform.position) < distancethreshold)
            {
                index = (index + 1) % waypoints.Count;
                destination = waypoints[index].position;
                agent.destination = destination;
            }

        }
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            for (int i = 0; i < waypoints.Count; i++)
            {
                if (i > 0)
                {
                    Gizmos.DrawLine(waypoints[i - 1].position, waypoints[i].position);
                }
            }

        }
    
    public void OnNotify() 
        {
            Debug.Log($"Notified by the Subject");
        }
    }
}
