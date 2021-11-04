using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishCube : MonoBehaviour
{
    bool isfinish = false;
    
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.GetComponentInParent<Character>()&&isfinish==false)
        {
            EventManager.onCubeActiveFalse.Invoke();
            isfinish = true;
            StartCoroutine(waitForWin());
        }
    }
    IEnumerator waitForWin()
    {
        yield return new WaitForSeconds(5f);
        EventManager.OnGameWin.Invoke();
    }
}
