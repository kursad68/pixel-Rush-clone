using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateLocal : MonoBehaviour
{   [SerializeField]
    private Transform transformcha;
    [SerializeField]
    private Transform dancePosition;
    private GameManager gM;
    private bool isWin;
    void Start()
    {
        isWin = false;
        gM = EventManager.GetScriptGameManager.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        if (gM.OnGameWin == false) {
            transform.localRotation = transformcha.localRotation;
        }
        else if(isWin==false)
        {
            isWin = true;
            transform.SetParent(null);
            transform.position = dancePosition.position;
            transform.rotation = Quaternion.Euler(0, 180, 0);
            EventManager.onAnimationPlay.Invoke("dance");
        }
    }
}
