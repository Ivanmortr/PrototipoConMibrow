
using UnityEngine;
using UnityEngine.AI;

public class SPAWNNPC : MonoBehaviour
{
    [SerializeField] private GameObject prefabNPC;
    [SerializeField] private GameObject prefabDeliveryNPC;

    private void Start()
    {

        InvokeRepeating(nameof(InstanciarNPCS), 2, 5);
        Invoke(nameof(InstanciarDeliveryNPCS),1);
    }

    private void InstanciarNPCS()
    {
        var inst = Instantiate(prefabNPC);
        

    }

    private void InstanciarDeliveryNPCS()
    {
        var inst = Instantiate(prefabDeliveryNPC);
        inst.transform.SetParent(GameObject.Find("Pos").transform);

    }
}
