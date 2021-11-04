using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalSceneObject : MonoBehaviour
{
  
    private void OnEnable()
    {
        EventManager.getFinalSceneObject += GetFinalSceneObject;
    }
    private void OnDisable()
    {
        EventManager.getFinalSceneObject -= GetFinalSceneObject;
    }
    FinalSceneObject GetFinalSceneObject()
    {
        return GetComponent<FinalSceneObject>();
    }
}
