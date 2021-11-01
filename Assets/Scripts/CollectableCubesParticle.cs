using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCubesParticle : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponentInParent<Character>())
        {
       
            EventManager.onCubeActiveTrue.Invoke();
            Destroy(gameObject);
        }
    }
}
