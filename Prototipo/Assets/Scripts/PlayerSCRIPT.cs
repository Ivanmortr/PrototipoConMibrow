using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerSCRIPT : MonoBehaviour
{
    [SerializeField] private Transform target;
    private NavMeshAgent agent;
    
    int productCap = 1000;
   public int currProduct = 1000;
    int dineritoPalTapanko;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.Find("OBJETIVO").transform;
    }

    private void FixedUpdate()
    {
        agent.SetDestination(target.position);

        if (currProduct == 0) { agent.SetDestination(gameObject.transform.parent.position); }
        if (Vector3.Distance(gameObject.transform.position, gameObject.transform.parent.position) < 10)
        {
            RefillDelivery();
        }
    }
    void RefillDelivery()
    {
        currProduct = productCap;
        gameObject.GetComponentInParent<Almacen>().currentProduct-=currProduct;
        agent.SetDestination(target.position);

    }
    public void OnTriggerEnter(Collider other)
    {
            Debug.Log("El Temach");
        if (other.GetComponent<NPCMOVIMIENTO>())
        {
            if (other.GetComponent<NPCMOVIMIENTO>().probabilidadVenta()) { StartSale(); }
            
        }
    }

    public void StartSale()
    {
        var venta = Random.Range(1, 5);
        currProduct -= venta;
        dineritoPalTapanko += venta * 35;//Num Tamales vendidos por su precio:$35
    }
}
