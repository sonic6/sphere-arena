using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightWeapon : PlayerWeapon
{
    protected override void SetDirection()
    {
        pushDirection = new Vector3(1, 0, 1);
    }
}
