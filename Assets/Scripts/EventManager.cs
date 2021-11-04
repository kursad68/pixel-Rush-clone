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
    //values
    public static bool shoulder,body,head,handle;
    public static int shoulderSize, bodySize, headSize, handleSize;
    //action in
    public static Action<string,string> onAnimatorAction;
    public static Action<string> onAnimationPlay;
    //get
    public static Func<GameManager> GetScriptGameManager;
    public static Func<ObjectPool> getPool;
    public static Func<CreaterObject> getCreator;
    public static Func<prefabObjectPlayer> getPrefabObject;
    public static Func<FinalSceneObject> getFinalSceneObject;
    public static Func<FinalCubesObject> getFinalCubeObject;
    //unityEvent
    public static UnityEvent onCubeActiveTrue = new UnityEvent();
    public static UnityEvent onCubeActiveFalse = new UnityEvent();
    public static UnityEvent onFinalCubeActive= new UnityEvent();
    public static UnityEvent OnGameLost = new UnityEvent();
    public static UnityEvent OnGameWin = new UnityEvent();
}
