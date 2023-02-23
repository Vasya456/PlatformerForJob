using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomController : MonoBehaviour
{

    [SerializeField] float _speed = 5f;

    [SerializeField] Transform leftPoint, rightPoint;

    private bool movingRight;

    private Rigidbody2D rigidbody;
    private SpriteRenderer sprite;
    private Animator animator;
    private Collider2D colider;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        colider = GetComponent<Collider2D>();

        movingRight = true;
    }




    void Update()
    {
        if (movingRight)
        {
            rigidbody.velocity = new Vector2(_speed, rigidbody.velocity.y);

            sprite.flipX = true;

            if (transform.position.x > rightPoint.position.x)
            {
                movingRight = false;
            }
        }
        else
        {
            rigidbody.velocity = new Vector2(-_speed, rigidbody.velocity.y);

            sprite.flipX = false;

            if (transform.position.x < leftPoint.position.x)
            {
                movingRight = true;
            }



        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "HitBox") 
        {
            animator.SetTrigger("hurt");
            colider.enabled = false;
            Destroy(gameObject,0.1f);
            PlayerController.instance.Bounce();
        }
    }


}



