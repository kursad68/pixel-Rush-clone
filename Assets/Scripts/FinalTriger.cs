using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalTriger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<prefabBevelCube>())
        {
            other.gameObject.SetActive(false);
            EventManager.onFinalCubeActive.Invoke();
        }
    }
}
