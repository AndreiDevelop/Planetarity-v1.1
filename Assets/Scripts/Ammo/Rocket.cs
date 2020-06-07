using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour, IAmmo
{
    private string DestroyLayerName = "Sun";
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer(DestroyLayerName))
        {
            Destroy(gameObject);
        }
    }
}
