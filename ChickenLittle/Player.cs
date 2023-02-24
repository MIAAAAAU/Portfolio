using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float jumpTime;
    public float fallMultiplier;
    public float groundDetectorRadius;
       
    public Transform groundDetectionLeft;
    public Transform groundDetectionRight;
    public LayerMask whatIsGround;


    bool _isGrounded;
    bool _isJumping;
    bool _isRunning;
    bool _isFalling;
    bool _holdingSpace;

    float _jumpTimeCounter;
    float _directionX;

    Rigidbody2D _rb;
    Animator _animation;
    SpriteRenderer _sprite;


    void Start()
    {
        _rb = this.GetComponent<Rigidbody2D>();
        _animation= GetComponent<Animator>();  
        _sprite= _rb.GetComponent<SpriteRenderer>();        
    }

    #if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundDetectionLeft.position,groundDetectorRadius);
        Gizmos.DrawWireSphere(groundDetectionRight.position,groundDetectorRadius);
    }
    # endif


    void Update()
    {
        _directionX = Input.GetAxis("Horizontal");


        _isGrounded = Physics2D.OverlapCircle(groundDetectionLeft.position, groundDetectorRadius, whatIsGround) || 
            Physics2D.OverlapCircle(groundDetectionRight.position, groundDetectorRadius, whatIsGround);       //ground Detector
        _isRunning = _directionX != 0 && _isGrounded? true : false;


        SpriteFlip();  
        JumpSettings();   //set complex jump settings
        AnimSettings();   //set the animation parameters
    }


    private void FixedUpdate()   
    {
        Run(new Vector2(_directionX * speed, _rb.velocity.y));
        Jump(_jumpTimeCounter);
    }

    /*

    -------Methods-------

    */

    void Jump(float actualTime)  //the actual jump calculation
    {
        if (actualTime > 0f)
        {
            float controle = 1;
            if (_holdingSpace)
            {
                controle -= Time.deltaTime;
            } else controle = 1;

            _rb.velocity = new Vector2(_rb.velocity.x, jumpForce * controle);
        } 
    }


    void JumpSettings ()  //the complex jump settings
    {
        if (_isGrounded && Input.GetButtonDown("Jump"))
        {
            _jumpTimeCounter = jumpTime;   
            _isJumping= true;  
            
        } 
        else if (Input.GetButton("Jump") && _jumpTimeCounter > 0f)
        {
            _jumpTimeCounter -= Time.deltaTime;
            _holdingSpace = true;
            _isJumping= false;

        } 
        else if (Input.GetButtonUp("Jump"))
        {
            _jumpTimeCounter = 0f;
            _holdingSpace= false;
        }

        if (!_isJumping && _jumpTimeCounter <= 0 && !_isGrounded)
        {
            _rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;  
            _isFalling = true;      
        }
        else
        {
            _isFalling = false;
        }
    }


    void AnimSettings() //set the animation parameters
    {
        _animation.SetBool("IsRunning", _isRunning);                                                              
        _animation.SetBool("IsJumping", _isJumping);
        _animation.SetBool("IsFalling", _isFalling && !_isGrounded);
        _animation.SetBool("IsOnGround", _isGrounded);
    }


    void Run(Vector2 movement)
    {
        _rb.velocity = movement;
    }


    void SpriteFlip()
    {
        if(_directionX < 0) _sprite.flipX = true;

        if(_directionX > 0) _sprite.flipX = false;
    }
}