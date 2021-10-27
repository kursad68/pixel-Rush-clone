using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class EventManager 
{
    public static Action<string,string> onAnimatorAction;
    public static Action<string> onAnimationPlay;
    public static Func<GameManager> GetScriptGameManager;
}
