using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterArea : MonoBehaviour
{
    private void OnTriggerStay(Collider ObjCollider)
    {
        if (ObjCollider.CompareTag("Plant")==true)
        {
            Debug.Log("Unexpected plant in watering area");
            ObjCollider.gameObject.GetComponent<PlantsAI>().progress -= 0.01f;
        }
    }
}
