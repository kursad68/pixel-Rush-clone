using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool isGameStarted;
    public int speed;
    void Start()
    {
        speed = 0;
    }
    private void OnEnable()
    {
        EventManager.GetScriptGameManager += GM;
    }
    private void OnDisable()
    {
        EventManager.GetScriptGameManager -= GM;

    }
    GameManager GM()
    {
        return GetComponent<GameManager>();
    }

    void Update()
    {
        if (isGameStarted == false && Input.GetMouseButton(0))
        {
            isGameStarted = true;
            EventManager.onAnimationPlay.Invoke("RunForward");
            speed = 1;
        }
    }
}
