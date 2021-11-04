using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject buttonGameobject;
    private bool isGameStarted;
    public int speed;
    bool isGameEnd;
   public bool OnGameWin = false;
    void Start()
    {
        speed = 0;
        buttonGameobject.SetActive(false);
        isGameEnd = false;
 
    }
    private void OnEnable()
    {
        EventManager.GetScriptGameManager += GM;
        EventManager.OnGameLost.AddListener(onGameLost);
        EventManager.OnGameWin.AddListener(() => {
            SceneWinControl(); onGameLost();
        });
    }
    private void OnDisable()
    {
        EventManager.GetScriptGameManager -= GM;
        EventManager.OnGameLost.RemoveListener(onGameLost);
        EventManager.OnGameWin.RemoveListener(() => {
            SceneWinControl(); onGameLost();
        });

    }
    GameManager GM()
    {
        return GetComponent<GameManager>();
    }

    void Update()
    {
        if (EventManager.handleSize <= 8 && EventManager.headSize <= 8 && EventManager.bodySize <= 8 && EventManager.shoulderSize == 0)
        {
            speed = 0;
            EventManager.onAnimationPlay.Invoke("creed");
            onGameLost();
        }
        if (EventManager.shoulderSize <= 10)
        {
            EventManager.onAnimationPlay.Invoke("creed");
        }
        if (isGameStarted == false && Input.GetMouseButton(0))
        {
            isGameStarted = true;
            EventManager.onAnimationPlay.Invoke("RunForward");
            speed = 1;
        }
     
    }
    IEnumerator enumerator()
    {
        yield return new WaitForSeconds(1.5f);
        buttonGameobject.SetActive(true);
       

    }
    private void onGameLost()
    {
        StartCoroutine(enumerator());
    }
    private void SceneWinControl()
    {
        OnGameWin = true;

        int temp;
        temp = PlayerPrefs.GetInt("CurrentLevel");
        temp++;
        PlayerPrefs.SetInt("CurrentLevel", temp);
        Debug.Log("new level " + temp + " " + PlayerPrefs.GetInt("CurrentLevel"));


    }
    public void onclick()
    {
        SceneManager.LoadScene(0);
    }
}
