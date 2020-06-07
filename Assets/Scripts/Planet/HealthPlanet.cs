using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlanet : Health
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Rocket>())
        {
            TakeHit(0);
        }
    }
}
