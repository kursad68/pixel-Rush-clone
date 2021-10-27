using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    string previous = "Idle";
    // Start is called before the first frame update
    void Start()
    {
        previous = "Idle";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnEnable()
    {
        EventManager.onAnimationPlay += AnimationPlayTriger;
    }
    private void OnDisable()
    {
        EventManager.onAnimationPlay -= AnimationPlayTriger;
    }
    public void AnimationPlayTriger(string Triger)
    {

        EventManager.onAnimatorAction.Invoke(Triger, previous);
        previous = Triger;

    }
}
