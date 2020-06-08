using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRocket : MonoBehaviour, IGun
{
    public void Fire(params object[] param)
    {
        GameObject prefab = (param[0] as GameObject);
        Rocket rocket = Instantiate(prefab.gameObject, transform.position, transform.rotation).GetComponent<Rocket>();
        rocket.RocketLaunch(transform.up);
    }
}
