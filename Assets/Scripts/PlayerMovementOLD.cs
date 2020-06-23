// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PlayerMovement : MonoBehaviour
// {

//     private Rigidbody2D rg2d;

//     [SerializeField]
//     private float _jumpForce = 5.0f;

//     [SerializeField]
//     private bool _grounded = false;

//     [SerializeField]
//     private LayerMask _groundLayer;

//     private bool resetJumpNeeded = false;

//     // Start is called before the first frame update
//     void Start()
//     {
//         rg2d = GetComponent<Rigidbody2D>();
//     }

//     // Update is called once per frame
//     void Update()
//     {

//         Movement();
//         CheckGrounded();


//     }

//     void Movement()
//     {
//         float move = Input.GetAxisRaw("Horizontal");

//         if (Input.GetKeyDown(KeyCode.Space) && _grounded == true)
//         {
//             rg2d.velocity = new Vector2(rg2d.velocity.x, _jumpForce);
//             _grounded = false;
//             resetJumpNeeded = true;
//             StartCoroutine(ResetJumpNeededRoutine());
//         }
//         rg2d.velocity = new Vector2(move, rg2d.velocity.y);
//     }

//     void CheckGrounded()
//     {
//         RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 0.8f, 1 << 8);
//         Debug.DrawRay(transform.position, Vector2.down * 0.8f, Color.green);

//         if (hitInfo.collider != null)
//         {
//             if (resetJumpNeeded == false)
//                 _grounded = true;
//         }

//     }

//     IEnumerator ResetJumpNeededRoutine()
//     {
//         yield return new WaitForSeconds(0.1f);
//         resetJumpNeeded = false;
//     }
// }