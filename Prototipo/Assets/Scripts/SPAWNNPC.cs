
using UnityEngine;
using UnityEngine.AI;

public class SPAWNNPC : MonoBehaviour
{
    [SerializeField] private GameObject prefabNPC;

    private void Start()
    {

        InvokeRepeating(nameof(InstanciarNPCS), 2, 5);
    }

    private void InstanciarNPCS()
    {
        Instantiate(prefabNPC);

    }
    
}
