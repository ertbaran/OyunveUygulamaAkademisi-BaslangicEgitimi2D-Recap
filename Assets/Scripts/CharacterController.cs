using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpForce = 10f;

    Rigidbody2D _rigid;
    Animator _animator;
    bool started;
    bool grounded;
    bool jumping;

    void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigid = GetComponent<Rigidbody2D>();
        grounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (started && grounded)
            {
                _animator.SetTrigger("Jump");
                grounded = false;
                jumping = true;
            }
            else
            {
                _animator.SetBool("GameStarted", true);
                started = true;
            }
        }
        _animator.SetBool("Grounded", grounded);
    }
    private void FixedUpdate()
    {
        if (started)
        {
            _rigid.velocity = new Vector2(speed, _rigid.velocity.y);
        }

        if (jumping)
        {
            _rigid.velocity = new Vector2(_rigid.velocity.x, jumpForce);
            jumping = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }
}
