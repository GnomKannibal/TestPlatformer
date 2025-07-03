using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.Rendering;

public class MovementPlayer : MonoBehaviour
{
    private Rigidbody2D _rb;
    private SpriteRenderer _sr;
    private float _speed = 15f;
    private float _jumpForce = 30f;
    private float _groundRadius = 0.30f;                                                  // ������ ���������� ��� ���������� ��� �������� isGround 
    [SerializeField] private Transform groundCheck;                                      // ��� ���������� �����, ������� ����� �������� ������� ����������� ����������
    [SerializeField] private LayerMask groundMask;                                       // �������� ����, � ������� ����� ����������������� ��������
    [SerializeField] private Animator _animator;

    private bool isGround;

    private float moveVector;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        moveVector = Input.GetAxis("Horizontal");

        isGround = Physics2D.OverlapCircle(groundCheck.position, _groundRadius, groundMask);

        if (isGround == false) _animator.SetBool("isJumping", true);
        else _animator.SetBool("isJumping", false);

        if (moveVector != 0) Move(moveVector);
        else _animator.SetBool("isMoving", false);
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && isGround) Jump();
    }

    void Move(float moveVector) 
    {
        
        //rb.MovePosition(rb.position + moveVector * speed * Time.deltaTime);

        //if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) 
        //    rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);

        if (moveVector < 0) _sr.flipX = true;
        else if (moveVector > 0) _sr.flipX = false;
        _animator.SetBool("isMoving", true);
        Vector2 move = new Vector2(moveVector * _speed, _rb.linearVelocityY);
        _rb.linearVelocity = move;
    }
    void Jump() 
    {
        Vector2 jump = new Vector2(_rb.linearVelocityX, _jumpForce); 
        _rb.linearVelocity = jump;
    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Ground")
    //    {
    //        _animator.SetBool("isJumping", false);
    //    }
    //}


    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Ground")
    //    {
    //        isGround = false;
    //    }
    //}
}
