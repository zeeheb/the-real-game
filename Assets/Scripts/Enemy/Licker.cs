using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Licker : Enemy
{

    private void Start()
    {
        Attack();
    }

    public override void Attack()
    {
        Debug.Log("Licker attack");
    }

    public override void Update()
    {

    }
}
