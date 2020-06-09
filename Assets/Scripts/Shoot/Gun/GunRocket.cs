using Lean.Pool;
using UnityEngine;

public class GunRocket : MonoBehaviour, IGun
{
    public void Fire(params object[] param)
    {
        GameObject prefab = (param[0] as GameObject);
        Rocket rocket = LeanPool.Spawn(prefab.gameObject, transform.position, transform.rotation).GetComponent<Rocket>();
        rocket.RocketLaunch(transform.up);
    }
}
