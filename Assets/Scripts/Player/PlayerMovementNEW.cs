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
    private bool _grounded = false;

    [SerializeField]
    private float _speed = 3.0f;

    private PlayerAnimation _playerAnim;
    private SpriteRenderer _playerSprite;


    // Start is called before the first frame update
    void Start()
    {
        rg2d = GetComponent<Rigidbody2D>();
        _playerAnim = GetComponent<PlayerAnimation>();
        _playerSprite = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        Movement();
        Attack();
    }

    void Movement()
    {
        float move = Input.GetAxisRaw("Horizontal");
        _grounded = IsGrounded();
        if (move > 0)
        {
            Flip(true);
        }
        else if (move < 0)
        {
            Flip(false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded() == true)
        {
            rg2d.velocity = new Vector2(rg2d.velocity.x, _jumpForce);
            StartCoroutine(ResetJumpRoutine());
            _playerAnim.Jump(true);
        }
        rg2d.velocity = new Vector2(move * _speed, rg2d.velocity.y);

        _playerAnim.Move(move);
    }

    void Attack()
    {
        if (Input.GetMouseButtonDown(0) && IsGrounded() == true)
        {
            _playerAnim.Melee();
        }

        if (Input.GetKeyDown(KeyCode.R) && IsGrounded() == true)
        {
            _playerAnim.Ranged();
        }
    }

    bool IsGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 1.1f, 1 << 8);
        Debug.DrawRay(transform.position, Vector2.down * 1.1f, Color.blue);
        if (hitInfo.collider != null)
        {
            if (_resetJump == false)
            {
                _playerAnim.Jump(false);
                return true;
            }
        }
        return false;
    }

    void Flip(bool faceRight)
    {
        if (faceRight == true)
        {
            _playerSprite.flipX = false;
        }
        else if (faceRight == false)
        {
            _playerSprite.flipX = true;
        }
    }

    IEnumerator ResetJumpRoutine()
    {
        _resetJump = true;
        yield return new WaitForSeconds(0.1f);
        _resetJump = false;

    }
}