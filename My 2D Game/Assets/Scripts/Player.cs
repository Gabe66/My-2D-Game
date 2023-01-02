using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Config
    [SerializeField] float _moveSpeed = 5;
    [SerializeField] float _jumpForce = 10;
    [SerializeField] float _climbSpeed = 5f;

    // States
    bool _isAlive = true;
    bool _isOnGround;

    // Cached component references
    Rigidbody2D _myRigidBody;
    Animator _myAnimator;
    CapsuleCollider2D _myBodyCollider;
    BoxCollider2D _myFeet;
    GameManager _gameManager;


    // Start is called before the first frame update
    void Start()
    {
        _myRigidBody = GetComponent<Rigidbody2D>();
        _myAnimator = GetComponent<Animator>();
        _myBodyCollider = GetComponent<CapsuleCollider2D>();
        _myFeet = GetComponent<BoxCollider2D>();
        //gravityScaleAtStart = myRigidBody.gravityScale;
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isAlive) { return; }

        Run();
        //ClimbLadder();
        Jump();
        FlipSprite();
       //Die();
    }

    void Run()
    {
        // Get directional input from the keyboard
        float _horizontalInput = Input.GetAxis("Horizontal");
        
        // Move the player in the direction based on directional input from above statement
        _myRigidBody.velocity = new Vector2(_horizontalInput * _moveSpeed, _myRigidBody.velocity.y);
        
        // Does the player have movement in either direction
        bool playerHasHorizontalSpeed = Mathf.Abs(_myRigidBody.velocity.x) > Mathf.Epsilon;

        // Tell the animator to switch the animation if there is movement
        _myAnimator.SetBool("Running", playerHasHorizontalSpeed);

    }
    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(_myRigidBody.velocity.x) > Mathf.Epsilon;

        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(_myRigidBody.velocity.x), 1f);
        }
    }

    void Jump()
    {
        if (_myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            _myAnimator.SetBool("OnGround", true);
            _isOnGround = true;
        }
        else
        {
            _myAnimator.SetBool("OnGround", false);
            _isOnGround = false;
        }

        if (Input.GetButton("Jump") && _isOnGround)
        {
            _myRigidBody.velocity = new Vector2(_myRigidBody.velocity.x, _jumpForce);
        }
    }
}
