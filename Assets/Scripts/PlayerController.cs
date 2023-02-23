using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _jump = 5f;
    [SerializeField] private float _doubleJump = 7f;
    [SerializeField] private float _bounceForce = 5f;


    private Rigidbody2D rigidbody;

    private bool _isGrounded;

    [SerializeField] private Transform groundCheckPoint;
    [SerializeField] private LayerMask whatIsGround;

    [SerializeField] private float knockBackLenght;
    [SerializeField] private float knockBackForce;

    private float knockBackCounter;

    private bool _isDoubleJump;

    private Animator animator;
    private SpriteRenderer sprite;


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        if (knockBackCounter <= 0)
        {

            rigidbody.velocity = new Vector2(_speed * Input.GetAxis("Horizontal"), rigidbody.velocity.y);

            _isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, .2f, whatIsGround);

            if (_isGrounded)
            {
                _isDoubleJump = true;
            }

            if (Input.GetButtonDown("Jump"))
            {
                if (_isGrounded)
                {
                    rigidbody.velocity = new Vector2(rigidbody.velocity.x, _jump);
                }
                else
                {
                    if (_isDoubleJump)
                    {
                        rigidbody.velocity = new Vector2(rigidbody.velocity.x, _doubleJump);
                        _isDoubleJump = false;
                    }

                }


            }

            if (rigidbody.velocity.x < 0)
            {
                sprite.flipX = true;
            }
            else if (rigidbody.velocity.x > 0)
            {
                sprite.flipX = false;
            }
        }
        else 
        {
            knockBackCounter -= Time.deltaTime;
            if (!sprite.flipX)
            {
                rigidbody.velocity = new Vector2(-knockBackForce, rigidbody.velocity.y);
            }
            else 
            {
                rigidbody.velocity = new Vector2(knockBackForce, rigidbody.velocity.y);
            }
        }

            animator.SetFloat("speed", Mathf.Abs(rigidbody.velocity.x));
            animator.SetBool("isGrounded", _isGrounded);
        
    }
    public void KnockBack() 
    {
        knockBackCounter = knockBackLenght;
        rigidbody.velocity = new Vector2(0f, knockBackForce);
        animator.SetTrigger("hurt");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Spike") 
        {
            PlayerHealthController.instance.DealDamage();
           
            if (PlayerHealthController.instance.currentHealth <= 0)
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    public void Bounce() 
    {
        rigidbody.velocity = new Vector2(rigidbody.velocity.x, _bounceForce);
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Platform") 
        {
            transform.parent = other.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Platform") 
        {
            transform.parent = null;
        }
    }

}
