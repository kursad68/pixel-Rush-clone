using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectableCubes : MonoBehaviour
{
    [SerializeField]
    private GameObject Shoulder, Shoulder1, Handle, Handle1, Body, Head;
    public int CubeSize;
    private void Start()
    {
        CubeSize = Shoulder.transform.childCount * 2 + Handle.transform.childCount * 2 + Body.transform.childCount + Head.transform.childCount;
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
    private void KRsdUpdate()
    {

    }


    private void cubeSwitchActive()
    {
        if (EventManager.shoulder == true)
        {
            Debug.Log("shoulder  " + EventManager.shoulder);
            cubeSetActiveTrue(Shoulder);
            cubeSetActiveTrue(Shoulder1);
            EventManager.shoulder = false;
        }
        else if (EventManager.body == true)
        {
            cubeSetActiveTrue(Body);
            EventManager.body = false;
        }
        else if (EventManager.handle == true)
        {
            cubeSetActiveTrue(Handle);
            cubeSetActiveTrue(Handle1);
            EventManager.handle = false;
        }
        else if (EventManager.head == true)
        {
            cubeSetActiveTrue(Head);
            EventManager.head = false;

        }
    }
}
