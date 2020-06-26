using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golemm : Enemy
{
    private Vector3 _currentTarget;

    private void Start()
    {

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
