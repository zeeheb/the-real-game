using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golemm : Enemy
{
    private Vector3 _currentTarget;
    private Animator _anim;
    private SpriteRenderer _golemSprite;

    private void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        _golemSprite = GetComponentInChildren<SpriteRenderer>();
    }

    public override void Update()
    {
        if (_anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            return;
        }

        Movement();
    }


    void Movement()
    {

        if (_currentTarget == pointB.position)
        {
            _golemSprite.flipX = true;
        }
        else
        {
            _golemSprite.flipX = false;
        }

        if (transform.position == pointA.position)
        {
            _currentTarget = pointB.position;
            _anim.SetTrigger("Idle");
        }
        else if (transform.position == pointB.position)
        {
            _currentTarget = pointA.position;
            _anim.SetTrigger("Idle");
        }

        transform.position = Vector3.MoveTowards(transform.position, _currentTarget, speed * Time.deltaTime);

    }
}
