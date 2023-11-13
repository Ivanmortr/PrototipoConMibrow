using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerSCRIPT : MonoBehaviour
{
    [SerializeField] private Transform target;
    private NavMeshAgent agent;
    
    int productCap = 100;
   public int currProduct = 100;
    public int coolDownTime = 30;
    public float timer;
    int dineritoPalTapanko;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.Find("OBJETIVO").transform;        
        timer = coolDownTime;
    }

    private void FixedUpdate()
    {
        agent.SetDestination(target.position);

        if (currProduct == 0) {
            
            agent.SetDestination(gameObject.transform.parent.position);
            if (Vector3.Distance(gameObject.transform.position, gameObject.transform.parent.position) < 5)
            {
                RefillDelivery();
            }
        }
        
    }
    void RefillDelivery()
    {
        timer-=Time.deltaTime;
       Debug.Log("El Temach");

        if(timer < 0 )
        {
            currProduct = productCap;
            timer = coolDownTime;
            gameObject.GetComponentInParent<Almacen>().currentProduct -= currProduct;
            agent.SetDestination(target.position);
            Debug.Log("Gaviota");
        }
        

    }
    public void OnTriggerEnter(Collider other)
    {
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
