using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISituationAnalyzerRaycast : MonoBehaviour, IAISituationAnalyzer
{
    public event CustomEventHandler.EventHandler OnSitualionIsGoodForShoot;

    [SerializeField] private string _layerCollide = "Player";
    [SerializeField] private float _maxDistance = 50f;

    private LayerMask _collideLayer;

    void Awake()
    {
        _collideLayer = LayerMask.GetMask(_layerCollide);
    }

    void Update()
    {
        RaycastHit2D hit;
        Ray2D detectRay = new Ray2D(transform.position, transform.up);
        Debug.DrawLine(detectRay.origin, detectRay.direction * _maxDistance, Color.red);

        //if (Physics2D.Raycast(detectRay, out hit, _maxDistance, LayerMask.GetMask(_layerCollide)))
        if (hit = Physics2D.Raycast(detectRay.origin, detectRay.direction,_maxDistance, _collideLayer.value))
        {
            Debug.Log("Hit 1 "+hit.transform.name);
            //if(hit && hit.transform.tag == _aimTag)
            //{
            //    Debug.Log("Hit 2");
                OnSitualionIsGoodForShoot?.Invoke();
            //}
        }
    }
}
