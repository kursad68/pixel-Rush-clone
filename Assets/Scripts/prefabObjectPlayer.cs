using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prefabObjectPlayer : MonoBehaviour
{
    public CubeType prefabType;
    private void OnEnable()
    {
        EventManager.getPrefabObject += getPObject;
        
    }
    private void OnDisable()
    {
        EventManager.getPrefabObject -= getPObject;

    }
    prefabObjectPlayer getPObject()
    {
        return GetComponent<prefabObjectPlayer>();
    }
}
