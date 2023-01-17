using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftWeapon : PlayerWeapon
{
    protected override void SetDirection(int dir)
    {
        pushDirection = new Vector3(-250, 0, 250) * dir;
    }
}
