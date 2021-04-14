using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class RandomPoint : MonoBehaviour
{
    [SerializeField]
    private float _range = 10f;
    [SerializeField]
    private float _speed = 1f;
    [SerializeField]
    private float _offset = 1f;
    private NavMeshAgent _agent;
    private bool _gettingPath = false;
    [SerializeField]
    private float _moveDelay = 2;
    private WaitForSeconds _randomPointDelay;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.speed = _speed;
        _randomPointDelay = new WaitForSeconds(_moveDelay);
    }

    bool RandomPointOnMesh(Vector3 center, float range, out Vector3 result)
    {
        for (int i = 0; i < 30; i++)
        {
            Vector3 randomPoint = center + Random.insideUnitSphere * range;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1f, NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }
        }
        result = Vector3.zero;
        return false;
    }

    void Update()
    {
        if (_agent.hasPath == false || _agent.remainingDistance < _offset)
        {
            if (_gettingPath == false)
            {
                StartCoroutine(GetNextDestination());
                //Vector3 point;

                //if (RandomPointOnMesh(transform.position, _range, out point))
                //{
                //    //Debug.DrawRay(point, Vector3.up, Color.blue, 1f);
                //}

                //Debug.Log(this.name + " is getting Position.");
                //_agent.SetDestination(point);
            }
        }
    }

    IEnumerator GetNextDestination()
    {
        _gettingPath = true;
        Vector3 point;

        yield return _randomPointDelay;

        if (RandomPointOnMesh(transform.position, _range, out point))
        {
            //Debug.DrawRay(point, Vector3.up, Color.blue, 1f);
        }

        _agent.SetDestination(point);
        _gettingPath = false;
    }
}
