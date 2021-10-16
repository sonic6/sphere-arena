using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleWeapon : PlayerWeapon
{
    protected override void SetDirection()
    {
        pushDirection = new Vector3(0, 0, 1);
    }
}
