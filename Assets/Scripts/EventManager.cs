using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using UnityEngine.Events;
public enum CubeType
{
    shoulder,
    body,
    head,
    handle,
    Cube
}

public static class EventManager 
{
    public static bool shoulder,
    body,
    head,
    handle;
    public static Action<string,string> onAnimatorAction;
    public static Action<string> onAnimationPlay;
    public static Func<GameManager> GetScriptGameManager;
    public static Func<ObjectPool> getPool;
    public static UnityEvent onCubeActiveTrue = new UnityEvent();
}
