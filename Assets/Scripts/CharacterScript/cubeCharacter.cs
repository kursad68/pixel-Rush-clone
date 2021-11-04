using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class cubeCharacter : MonoBehaviour
{

   private int SizeFinalCube,i=0;
   private Transform finalTransform;
    public List<GameObject> pfObjec;
    private ObjectPool GetPool;
    private FinalSceneObject finalObject;
    private FinalCubesObject FinalCube;
    void Start()
    {
        GetPool = EventManager.getPool.Invoke();
        finalObject = EventManager.getFinalSceneObject.Invoke();
        finalTransform = finalObject.gameObject.transform;
        FinalCube = EventManager.getFinalCubeObject.Invoke();
        SizeFinalCube = FinalCube.gameObject.transform.childCount;
    }
    private void OnEnable()
    {
        EventManager.onCubeActiveFalse.AddListener(getPrefabPlayerObjects);
        EventManager.onFinalCubeActive.AddListener(onFinalCubeActive);
        EventManager.OnGameWin.AddListener(cubeActiveTrue);
    }
    private void OnDisable()
    {
        EventManager.onCubeActiveFalse.RemoveListener(getPrefabPlayerObjects);
        EventManager.onFinalCubeActive.RemoveListener(onFinalCubeActive);
        EventManager.OnGameWin.RemoveListener(cubeActiveTrue);
    }

    private void getPrefabPlayerObjects()
    {
        EventManager.onAnimationPlay.Invoke("Idle");
       
       
            for (int i = 0; i < pfObjec.Count; i++)
            {

                cubeSetActivefalse(pfObjec[i].gameObject,false);

            }
         
     
    }
    private void cubeActiveTrue()
    {
        for (int i = 0; i < pfObjec.Count; i++)
        {

            cubeSetActivefalse(pfObjec[i].gameObject, true);

        }
    }
    private void cubeSetActivefalse(GameObject obj,bool isBool)
    {
        StartCoroutine(inOrderActive(obj, 0,isBool));

    }
    IEnumerator inOrderActive(GameObject obj, int i,bool isbool)
    {
        float x;
        if (isbool == false)
            x = 0.1f;
        else x = 0.01f;
        yield return new WaitForSeconds(x);

   
        if (i < obj.transform.childCount)
        {
            if (obj.transform.GetChild(i).gameObject.activeSelf&&isbool==false) 
            {
                GameObject objePool = GetPool.GetPooledObject(0);
                objePool.transform.position = obj.transform.GetChild(i).gameObject.transform.position;
                poolObjeGoToFinalScene(objePool);
            }
           
            obj.transform.GetChild(i).gameObject.SetActive(isbool);
           i++;
          StartCoroutine(inOrderActive(obj, i,isbool));
           
         
           
        }
        else
        {
          
        }

    }
    
    private void poolObjeGoToFinalScene(GameObject obj)
    {
        obj.transform.DOMove(finalTransform.position, 3f);
        obj.layer = 10;
     
    }
    private void onFinalCubeActive()
    {
    
        if (i < SizeFinalCube)
        {
            FinalCube.gameObject.transform.GetChild(i).gameObject.SetActive(true);
            i++;
        }
      
    }
}
