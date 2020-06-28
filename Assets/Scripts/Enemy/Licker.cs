using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Licker : Enemy
{

    private Vector3 _currentTarget;

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
        Movement();
    }

    void Movement()
    {
        if (transform.position == pointA.position)
        {
            _currentTarget = pointB.position;

        }
        else if (transform.position == pointB.position)
        {
            _currentTarget = pointA.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, _currentTarget, speed * Time.deltaTime);

    }
}
