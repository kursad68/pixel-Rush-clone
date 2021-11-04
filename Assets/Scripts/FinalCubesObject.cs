using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalCubesObject : MonoBehaviour
{
    private void OnEnable()
    {
        EventManager.getFinalCubeObject += GetFinalCubeObje;
    }
    private void OnDisable()
    {
        EventManager.getFinalCubeObject -= GetFinalCubeObje;
    }
    FinalCubesObject GetFinalCubeObje()
    {
        return GetComponent<FinalCubesObject>();
    }
}
