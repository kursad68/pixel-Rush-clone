using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; 

public enum TypeEnemy
{
    obstacle,
    sledgehammer,
    pendulum
}
public class RotataObstacle : MonoBehaviour
{

    Sequence sq;
    [SerializeField]
    private int deger;
    [SerializeField]
    private float timeSize=1f;
    public TypeEnemy TypeEnum;
    private void Start()
    {
        if (TypeEnum == TypeEnemy.pendulum)
            DoRotateOnPendulum(deger);
        else if (TypeEnum == TypeEnemy.sledgehammer)
            DoRotateSledgehammer(deger);
    }

    private void DoRotateOnPendulum(int deger)
    {

        transform.DORotate(new Vector3(0, deger,0), 1f).SetEase(Ease.Linear).OnComplete(() =>
        {
            DoRotateOnPendulum(-deger);
        });
    }
    private void DoRotateSledgehammer(int deger)
    {
        transform.DORotate(new Vector3(0, 0, deger), timeSize).SetLoops(-1, LoopType.Yoyo);
    }
}
