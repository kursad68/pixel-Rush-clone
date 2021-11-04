using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreaterObject : MonoBehaviour
{
    private void OnEnable()
    {
        EventManager.getCreator += getCreator;
    }
    private void OnDisable()
    {
        EventManager.getCreator -= getCreator;
    }
    CreaterObject getCreator()
    {
        return GetComponent<CreaterObject>();
    }
}
