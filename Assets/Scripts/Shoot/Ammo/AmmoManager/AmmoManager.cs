using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoManager : MonoBehaviour
{
    public virtual Ammo Ammo { get; set; }

    public virtual void InitializeAmmo(params object[] param)
    {
    }
}
