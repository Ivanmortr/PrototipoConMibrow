
using UnityEngine;
using UnityEngine.AI;

public class NPCMOVIMIENTO : MonoBehaviour
{
    public GameObject[] puntosDeInteresObjects;
    private NavMeshAgent agent;
    private Vector3 target;
    public SituacionEconomica situacionEconomica;
    const string puntosDeInteresTag = "PUNTOSDEINTERES";
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        
        puntosDeInteresObjects = GameObject.FindGameObjectsWithTag(puntosDeInteresTag);
        target = puntosDeInteresObjects[Random.Range(0, puntosDeInteresObjects.Length)].transform.position;
        agent.speed = Random.Range(9.6f,10.0f);
        
    }

    private void FixedUpdate()
    {
        agent.SetDestination(target);
        if(Vector3.Distance(agent.transform.position, target) < 15)
        {
            Destroy(agent.gameObject);
        }
    }

    
   public bool probabilidadVenta()
    {
        float prob = Random.Range(0,11);
        bool probabilidad = false;
        switch(situacionEconomica)
        {
            case SituacionEconomica.Naco:
                if(prob > 8) { probabilidad = true; }
                    break;
            case SituacionEconomica.ClaseMedia:
                if (prob > 5) { probabilidad = true; }
                break;
            case SituacionEconomica.Fifi:
                if (prob > 2) { probabilidad = true; }
                break;
        }
        return probabilidad;
    }
}
public enum SituacionEconomica
{
    Naco,
    ClaseMedia,
    Fifi
}
