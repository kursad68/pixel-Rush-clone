using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;
public class CameraControl : MonoBehaviour
{

    [SerializeField]
    CinemachineVirtualCamera cinemachine;
    CinemachineTransposer cinemachineTransposer;
    private void Start()
    {
        cinemachineTransposer = cinemachine.GetCinemachineComponent<CinemachineTransposer>();
    }
    private void OnEnable()
    {
      
        EventManager.onCubeActiveFalse.AddListener(finishCAmera);

    }
    private void OnDisable()
    {
        
        EventManager.onCubeActiveFalse.RemoveListener(finishCAmera);
    }
    private void finishCAmera()
    {
        cinemachine.Priority = 8;
    }
}
