using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float maxDist;
    [SerializeField] float minDist;
    [SerializeField] float movingSpeed;
    SpriteRenderer _sprite;
    Animator animator;
    Vector3 initialPosition;
    int direction;

    // Start is called before the first frame update
    void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        initialPosition = transform.position;
        direction = -1;
        //maxDist += transform.position.x;
        //minDist -= transform.position.x;
        movingSpeed = 0.3f;
    }

    // Update is called once per frame
    void Update()
    {
        switch (direction)
        {
            case -1:
                // Moving Left
                if (transform.position.x > minDist)
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(-movingSpeed, GetComponent<Rigidbody2D>().velocity.y);
                    _sprite.flipX = false;
                    animator.SetBool("isMoving", true);
                }
                else
                {
                    direction = 1;
                    animator.SetBool("isMoving", false);

                }
                break;
            case 1:
                //Moving Right
                if (transform.position.x < maxDist)
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(movingSpeed, GetComponent<Rigidbody2D>().velocity.y);
                    _sprite.flipX = true;
                    animator.SetBool("isMoving", true);

                }
                else
                {
                    direction = -1;
                    animator.SetBool("isMoving", false);

                }
                break;
        }
    }
}