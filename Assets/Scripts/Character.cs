using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    private int lives = 10;
    [SerializeField]
    private float speed = 3.0F;
    [SerializeField]
    private float jumpForce = 15.0F;

    private bool isGrounded = false;
    public int maximumBoxes = 2;
    new private Rigidbody2D rigidbody;
    private Animator animator;
    private SpriteRenderer sprite;
    [SerializeField]
    private BlocksController controller;

    private void Awake() //получене ссылок на компоненты
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        controller = GetComponent<BlocksController>();
    }

    private void FixedUpdate()
    {
        CheckGround(); 
    }

    private void Update()
    {
        if (Input.GetButton("Horizontal")) Run();
        if (isGrounded && Input.GetButtonDown("Jump")) Jump(); 
        if(Input.GetKey(KeyCode.LeftShift))
        {
            controller.StartCreating();
            if (Input.GetKeyDown(KeyCode.LeftArrow)){
                controller.CreateBlock("Left");
            }
            else if(Input.GetKeyDown(KeyCode.UpArrow))
            {
                controller.CreateBlock("Top");
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                controller.CreateBlock("Right");
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                controller.CreateBlock("Bottom");
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            controller.EndCreating();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            controller.Throw(sprite.flipX);
        }
    }

    private void Run()
    {
        Vector3 direction = transform.right * Input.GetAxis("Horizontal");

        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
        sprite.flipX = direction.x < 0.0F;

    }

    private void Jump()
    {
        rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    private void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.3F);

        isGrounded = colliders.Length > 1;
    }

   

}
