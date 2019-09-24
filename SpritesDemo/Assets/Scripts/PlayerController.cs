using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private SpriteRenderer _sprite;
    private Rigidbody2D _rb;
    private Animator _animator;
    private Vector3 movingPos;
    [SerializeField] private Vector3 stepMoving;
    private Transform _transform;
    //[SerializeField] float speed = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        _transform = GetComponent<Transform>();
        stepMoving = new Vector3(0.05f, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (HorizontalMoving())
        {
            //    float moveHorizontal = Input.GetAxis("Horizontal");
            //    print(moveHorizontal);
            //    Vector2 movement = new Vector2(moveHorizontal, 0);

            _animator.SetBool("isRunning", true);
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.D))
            {
                _sprite.flipX = true;
                movingPos = _transform.position - stepMoving;
            }
            else
            {
                _sprite.flipX = false;
                movingPos = _transform.position + stepMoving;
            }
            _transform.position = movingPos;
            //_rb.AddForce(movement * speed * Time.deltaTime);

        }
        else if (VerticalMoving())
        {
            _animator.SetTrigger("isJumping");
            _rb.AddForce(new Vector2(0, 0.2f), ForceMode2D.Impulse);
        }
        else
        {
            _animator.SetBool("isRunning", false);
        }
    }

    private bool HorizontalMoving()
    {
        return Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A);
    }

    private bool VerticalMoving()
    {
        return Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S);
    }
}
