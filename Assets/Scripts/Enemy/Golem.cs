﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem : Enemy
{
    private bool movingRight = true;
    public Transform groundDetection;
    public float distance;

    public override void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if (groundInfo == false)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = false;
            }
        }
    }
}
