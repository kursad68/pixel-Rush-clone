using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectableCubes : MonoBehaviour
{
    [SerializeField]
    private GameObject Shoulder, Shoulder1, Handle, Handle1, Body, Head;
    private int shoulderSize,handleSize,headSize,bodySize;
    private void Start()
    {
        shoulderSize = Shoulder.transform.childCount * 2;
        handleSize = Handle.transform.childCount * 2;
        bodySize = Body.transform.childCount;
        headSize = Head.transform.childCount;
        EventManager.headSize = headSize;
        EventManager.bodySize = bodySize;
        EventManager.handleSize = handleSize;
        EventManager.shoulderSize = shoulderSize;
    }
    private void OnEnable()
    {
        EventManager.onCubeActiveTrue.AddListener(cubeSwitchActive);
    }
    private void OnDisable()
    {
        EventManager.onCubeActiveTrue.RemoveListener(cubeSwitchActive);
    }

    private void cubeSetActiveTrue(GameObject obj)
    {
        /* for (int i = 0; i < obj.transform.childCount; i++)
         {
             obj.transform.GetChild(i).gameObject.SetActive(true);

         }*/
       
       StartCoroutine( inOrderActive(obj, 0));

    }
    IEnumerator inOrderActive(GameObject obj,int i)
    {
        yield return new WaitForSeconds(0.03f);
     
        obj.transform.GetChild(i).gameObject.SetActive(true);
        i++;
        if (i < obj.transform.childCount)
        {
           
            StartCoroutine(inOrderActive(obj, i));
        }
       
    }

    private void cubeSwitchActive()
    {
        if (EventManager.shoulder == true)
        {
          
            cubeSetActiveTrue(Shoulder);
            cubeSetActiveTrue(Shoulder1);
            EventManager.shoulderSize = shoulderSize;
            EventManager.shoulder = false;
            EventManager.onAnimationPlay.Invoke("RunForward");
        }
        else if (EventManager.body == true)
        {
            cubeSetActiveTrue(Body);
            EventManager.bodySize = bodySize;
            EventManager.body = false;
        }
        else if (EventManager.handle == true)
        {
            cubeSetActiveTrue(Handle);
            cubeSetActiveTrue(Handle1);
            EventManager.handleSize = handleSize;
            EventManager.handle = false;
        }
        else if (EventManager.head == true)
        {
            cubeSetActiveTrue(Head);
            EventManager.headSize = headSize;
            EventManager.head = false;

        }
    }
}
