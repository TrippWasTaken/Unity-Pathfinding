using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AI_Follow : MonoBehaviour
{
    private GameObject[] lights;
    private GameObject targetLight;
    private GameObject lastTargetLight;

    UnityEngine.AI.NavMeshAgent MyNavMesh;
    void Start()
    {
        SetTargetLight();
        MyNavMesh = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    bool SetTargetLight()
    {
        lights = GameObject.FindGameObjectsWithTag("Green");
        lights = lights.Where(l => !l.Equals(lastTargetLight)).ToArray();
        if (lights.Length == 0)
        {
            return false;
        }

        lastTargetLight = targetLight;
        

        targetLight = lights[Random.Range(0, lights.Length)];

        return true;
    }
    void Update()
    {

        if (lastTargetLight != null && targetLight.Equals(lastTargetLight))
        {
            if (SetTargetLight()) FollowLight();
        }
        else if (targetLight !=null || SetTargetLight())
        {
            if (!targetLight.CompareTag("Green") && !SetTargetLight())
            {
                return;
            }
            FollowLight();
        }
    }

    void FollowLight()
    {
        var targetRotation = Quaternion.LookRotation(targetLight.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 5 * Time.deltaTime);
        MyNavMesh.destination = targetLight.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == targetLight)
        {
            SetTargetLight();
        }
    }
}
