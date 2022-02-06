using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMaster : MonoBehaviour
{
    public GameObject Player;
    public float Distance;
    public Camera cam;

    public bool isChasing = false;

    public NavMeshAgent _agent;

    // Update is called once per frame
    void Update()
    {
        if(IsEnemyVisible(cam, this.gameObject))
        {
            isChasing = false;
        }
        if (IsEnemyVisible(cam, this.gameObject) == false)
        {
            isChasing = true;
        }

        if (isChasing)
        {
            _agent.isStopped = false;
            _agent.SetDestination(Player.transform.position);
        }
        if(!isChasing)
        {
            _agent.isStopped = true;
        }
    }

    bool IsEnemyVisible(Camera c, GameObject go)
    {
        var planes = GeometryUtility.CalculateFrustumPlanes(c);
        var point = go.transform.position;
        foreach (var plane in planes)
        {
            if (plane.GetDistanceToPoint(point) < -0.8)
                return false;
        }
        return true;
    }
}
