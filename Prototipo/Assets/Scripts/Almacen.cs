using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Almacen : MonoBehaviour
{
    int precioVenta;
    int maxProductCap;
    public bool comprado = false;
    public int currentProduct;
    

    
    [ContextMenuItem("MejoraCapacidad", "IncreaseMaxCap")]
    public int maxProduct = 100;    
    [ContextMenu ("hola mi ni�a")]
    public void IncreaseMaxCap()
    {
        maxProduct += 50;
    }        
    
    [ContextMenuItem("MejoraEnfriamiento", "ReduceCooldown")]
    float coolDownTimer = 150;

    [ContextMenu ("hola mi ni�a2")]
    public void ReduceCooldown()
    {
        coolDownTimer -= 20;
    }    

    void StartRefillingProdcutc()
    {
        coolDownTimer -= Time.deltaTime;
        currentProduct = maxProduct;
    }    
}
