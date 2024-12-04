using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

public class RunAway : MonoBehaviour
{
    [SerializeField] private NavMeshAgent Agent = null;
    [SerializeField] private Transform chaser = null;
    [SerializeField] private float displacementDist = 5f;

    void Start()
    {
        if (Agent == null)
        {
            if (!TryGetComponent(out Agent))
            {
                Debug.LogWarning(name + " needs a NavMeshAgent component");
            }
        }
        
            if (GetComponent<BoxCollider>() == null)
        {
            gameObject.AddComponent<BoxCollider>();
        }
    }

    private void Update()
    {
        if (chaser == null)
            return;

        Vector3 normDir = (transform.position - chaser.position).normalized;
        normDir = Quaternion.AngleAxis(Random.Range(0,200), Vector3.up) * normDir;
        MoveToPos(transform.position - (normDir * displacementDist));
    }

    private void MoveToPos(Vector3 pos)
    { 
        Agent.SetDestination(pos);
        Agent.isStopped = false;
    }
}