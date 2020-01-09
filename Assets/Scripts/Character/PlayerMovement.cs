using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    private Animator animator;
    private Rigidbody2D rigidbody2D;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        Camera.main.GetComponent<CameraMovement>().SetTarget(this.gameObject);
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if(!GlobalFlags.dialog)
            Move();
        else
            animator.SetBool("walking", false);
    }
    private void Move()
    {
        var input = Input.GetAxisRaw("Horizontal");
        animator.SetBool("walking", input != 0);
        if(input != 0) 
            spriteRenderer.flipX = input < 0;
        rigidbody2D.velocity = new Vector2(input*speed, rigidbody2D.velocity.y);
    }
}
