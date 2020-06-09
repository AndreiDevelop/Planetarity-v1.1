using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookDown : MonoBehaviour
{
    void Update()
    {
        transform.eulerAngles = Vector3.down;
    }
}
