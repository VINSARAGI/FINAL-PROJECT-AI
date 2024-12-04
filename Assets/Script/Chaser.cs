using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chaser : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent = null;
    [SerializeField] private Transform target = null;
    void Start()
    {
        if (agent == null) {
            if (!TryGetComponent(out agent)) {
                Debug.LogWarning(name + "needs a navmesh agent");
            }
        }
    }

    void Update()
    {
        if (target) {
            MoveToTarget();
        }
    }

    private void MoveToTarget() {
        agent.SetDestination(target.position);
        agent.isStopped = false;
    }
}
