using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    [SerializeField] private float _coolDownInSeconds = 1f;

    private IAISituationAnalyzer _situationAnalyzer;
    private IInput _input;
    private Coroutine _coolDown;
    private bool _isCoolDown = false;

    private void Awake()
    {
        _situationAnalyzer = GetComponent<IAISituationAnalyzer>();
        _input = GetComponent<IInput>();

        _input.CallInputDown();
    }

    private void OnEnable()
    {
        _situationAnalyzer.OnSitualionIsGoodForShoot += SitualionIsGoodForShoot;
    }

    private void OnDisable()
    {
        _situationAnalyzer.OnSitualionIsGoodForShoot -= SitualionIsGoodForShoot;
    }

    private void SitualionIsGoodForShoot()
    {
        if(!_isCoolDown)
        {
            _input.CallInputUp();
            StopCoolDown();
            _coolDown = StartCoroutine(CoolDown());
        }    
    }

    private void StopCoolDown()
    {
        if(_coolDown!=null)
        {
            StopCoroutine(_coolDown);
        }
    }

    private IEnumerator CoolDown()
    {
        _isCoolDown = true;
        yield return new WaitForSeconds(_coolDownInSeconds);
        _input.CallInputDown();
        _isCoolDown = false;
    }
}
