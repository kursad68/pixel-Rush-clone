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
        if (EventManager.handleSize == 0 && EventManager.headSize == 0 && EventManager.bodySize == 0 && EventManager.shoulderSize == 0)
        {
            Debug.Log("finish");
        }
        if (isGameStarted == false && Input.GetMouseButton(0))
        {
            isGameStarted = true;
            EventManager.onAnimationPlay.Invoke("RunForward");
            speed = 1;
        }
    }
}
