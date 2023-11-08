
using UnityEngine;
using UnityEngine.AI;

public class NPCMOVIMIENTO : MonoBehaviour
{
    public GameObject[] puntosDeInteresObjects;
    private NavMeshAgent agent;
    private Vector3 target;
    const string puntosDeInteresTag = "PUNTOSDEINTERES";
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        puntosDeInteresObjects = GameObject.FindGameObjectsWithTag(puntosDeInteresTag);
        target = puntosDeInteresObjects[Random.Range(0, puntosDeInteresObjects.Length)].transform.position;
        //agent.speed = Random.Range(3.5f,6.0f);
    }

    private void FixedUpdate()
    {
        bool comoesta = agent.SetDestination(target);
        Debug.Log(comoesta);
    }
}
