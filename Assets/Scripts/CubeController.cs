using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    private ObjectPool objectPool;
    [SerializeField]
    private CubeType typeCube;
    private void Start()
    {

        objectPool = EventManager.getPool.Invoke();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<obstacleControl>())
        {
            trigger();
        }
    }
    private void trigger()
    {
        if (typeCube == CubeType.shoulder)
        {
            EventManager.shoulder = true;
        }else if(typeCube == CubeType.body)
        {
            EventManager.body = true;
        }else if(typeCube == CubeType.handle)
        {
            EventManager.handle = true;
        }else if(typeCube == CubeType.head)
        {
            EventManager.head = true;
        }
        GameObject obj = objectPool.GetPooledObject(0);
        obj.transform.position = transform.position;
        gameObject.SetActive(false);
    }
}
