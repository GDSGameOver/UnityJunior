using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _speed;

    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private bool _isGround;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            _spriteRenderer.flipX = false;
            _animator.SetTrigger("Move");
            transform.Translate(_speed * Time.deltaTime, 0, 0);        
        }
         if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift))
        {
            _spriteRenderer.flipX = false;
            transform.Translate((_speed+5) * Time.deltaTime, 0, 0);
            _animator.SetTrigger("Run");
        }
         if (Input.GetKey(KeyCode.A))
        {
            _spriteRenderer.flipX=true;
            transform.Translate(_speed * Time.deltaTime*-1, 0, 0);
            _animator.SetTrigger("Move");
        }
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift))
        {
            _spriteRenderer.flipX = true;
            transform.Translate((_speed + 5) * Time.deltaTime*-1, 0, 0);
            _animator.SetTrigger("Run");
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            _animator.SetTrigger("Attack");
        }
        if (Input.GetKey(KeyCode.Mouse1) && _isGround)
        {
            _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _animator.SetTrigger("Jump");
            _animator.SetBool("IsGround", false);
            _isGround = false;
        }
        if (Input.anyKey == false)
        {
            _animator.SetTrigger("Idle");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Platform>(out Platform platform))
        {
            _animator.SetBool("IsGround", true);
            _isGround = true;
        }
    }
}
 