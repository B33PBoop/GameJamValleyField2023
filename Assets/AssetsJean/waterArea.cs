using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterArea : MonoBehaviour
{
    private void OnTriggerStay(Collider ObjCollider)
    {
        //Si une plante rentre dans l'aire d'arrosage
        if (ObjCollider.CompareTag("Plant")==true)
        { 
            //sa progression est diminuée (à un rythme plus grand qu'elle ne pousse)
            ObjCollider.gameObject.GetComponent<PlantsAI>().progress -= 0.01f;
        }
    }
}
