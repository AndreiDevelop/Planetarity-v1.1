using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainEnviromentController : EnviromentController
{
    void Start()
    {
        SwitchEnviromentOn<EnviromentEmpty>();
    }
}
