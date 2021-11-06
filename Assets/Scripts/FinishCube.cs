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
        EventManager.onAnimationPlay.Invoke("Idle");
        yield return new WaitForSeconds(6f);
        EventManager.OnGameWin.Invoke();
    }
}
