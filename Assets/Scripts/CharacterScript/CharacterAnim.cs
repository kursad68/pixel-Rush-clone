using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnim : MonoBehaviour
{
    private Animator animator;
    public Animator Animator { get { return (animator == null) ? animator = GetComponent<Animator>() : animator; } }



    private void OnEnable()
    {

        EventManager.onAnimatorAction += SetTriger;
    }
    private void OnDisable()
    {
        EventManager.onAnimatorAction -= SetTriger;

    }
    public void SetTriger(string value, string previous)
    {

        Animator.SetTrigger(value);
        if (value != previous)
            Animator.ResetTrigger(previous);
    }


}
