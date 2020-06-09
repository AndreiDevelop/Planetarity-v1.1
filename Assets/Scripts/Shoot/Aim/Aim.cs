using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour, IAim
{
    [SerializeField] private float _speedRotate = 100f;
    private Coroutine _rotateUpdate;
    
    public void StartAim(Action afterStartAim)
    {
        StopRotateUpdate();
        _rotateUpdate = StartCoroutine(RotateUpdate());

        afterStartAim?.Invoke();
    }

    public void StopAim(Action afterStopAim)
    {
        StopRotateUpdate();
        afterStopAim?.Invoke();
    }

    private IEnumerator RotateUpdate()
    {
        while(true)
        {
            transform.Rotate(0, 0, Time.deltaTime * _speedRotate);
            yield return new WaitForEndOfFrame();
        }
    }

    private void StopRotateUpdate()
    {
        if(_rotateUpdate!=null)
        {
            StopCoroutine(_rotateUpdate);
        }
    }
}
