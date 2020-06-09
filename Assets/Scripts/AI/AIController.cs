using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    [SerializeField] private ShootController _shootController;

    private IAISituationAnalyzer _situationAnalyzer;
    private IInput _input;
    private Coroutine _coolDown;
    private bool _isCoolDown = false;

    private float _coolDownInSeconds;

    private void Awake()
    {
        _situationAnalyzer = GetComponent<IAISituationAnalyzer>();
        _input = GetComponent<IInput>();
    }

    private IEnumerator Start()
    {
        yield return new WaitUntil(() => (_shootController.AmmoManager.Ammo as Rocket).Config != null);

        _coolDownInSeconds = (_shootController.AmmoManager.Ammo as Rocket).Config.CoolDown;
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
