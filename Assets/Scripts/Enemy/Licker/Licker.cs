using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Licker : Enemy, IDamageable
{
    public int Health { get; set; }
    //Use for initialize
    public override void Init()
    {
        base.Init();
        Health = base.health;
    }

    public void Damage()
    {

    }
}
