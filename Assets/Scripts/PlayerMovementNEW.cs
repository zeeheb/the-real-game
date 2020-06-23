using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementNEW : MonoBehaviour
{

    private Rigidbody2D rg2d;

    [SerializeField]
    private float _jumpForce = 5.0f;
    private bool _resetJump = false;

    [SerializeField]
    private float _speed = 3.0f;

    private PlayerAnimation _anim;


    // Start is called before the first frame update
    void Start()
    {
        rg2d = GetComponent<Rigidbody2D>();
        //assign handle to player animation
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        float move = Input.GetAxisRaw("Horizontal");
        rg2d.velocity = new Vector2(move * _speed, rg2d.velocity.y);
        // Debug.DrawRay(transform.position, Vector2.down * 0.8f, Color.green);
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded() == true)
        {
            rg2d.velocity = new Vector2(rg2d.velocity.x, _jumpForce);
            StartCoroutine(ResetJumpRoutine());
        }
    }

    bool IsGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down * 0.8f, 1 << 8);
        if (hitInfo.collider != null)
        {
            if (_resetJump == false)
                return true;
        }
        return false;
    }

    IEnumerator ResetJumpRoutine()
    {
        _resetJump = true;
        yield return new WaitForSeconds(0.1f);
        _resetJump = false;

    }
}