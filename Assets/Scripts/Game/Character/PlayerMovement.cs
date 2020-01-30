using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float crouchingSpeed;

    private Animator animator;
    private Rigidbody2D rigidbody2D;
    private SpriteRenderer spriteRenderer;

    [SerializeField] private Collider2D walkingCollider;

    private bool isCrouching;
    private bool isClimbing;
    private bool isTouchingLadder;
    private Ladder touchingLadder;

    private void Start()
    {
        Camera.main.GetComponent<CameraMovement>().SetTarget(this.gameObject);
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void Update()
    {
        if (rigidbody2D.velocity.y < 0)
            print(rigidbody2D.velocity.y);
    }
    public void Loop()
    {
        Move();
        if (Input.GetAxisRaw("Vertical") < 0 && !isCrouching && !isClimbing)
            Crouch();
        else if (isCrouching && CanGetUp() && !isClimbing)
            GetUp();
        else if (Input.GetKeyDown(KeyCode.UpArrow) && isTouchingLadder && !isClimbing)
            StartCoroutine(Climbing());
    }
    private void Move()
    {
        var s = isCrouching ? crouchingSpeed : speed;
        var input = Input.GetAxisRaw("Horizontal");
        animator.SetBool("walking", input != 0);
        if(input != 0) 
            spriteRenderer.flipX = input < 0;
        rigidbody2D.velocity = new Vector2(input* s, rigidbody2D.velocity.y);
    }
    private void Crouch()
    {
        animator.SetBool("crouching", true);
        isCrouching = true;
        walkingCollider.enabled = false;
    }
    private void GetUp()
    {
        animator.SetBool("crouching", false);
        isCrouching = false;
        walkingCollider.enabled = true;
    }
    private bool CanGetUp()
    {
        return true;
    }
    private IEnumerator Climbing()
    {
        isClimbing = true;
        animator.SetBool("climbing", true);
        float gScale = rigidbody2D.gravityScale;
        rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionX;
        rigidbody2D.gravityScale = 0;
        transform.position = touchingLadder.GetNearPosition(transform);
        Vector2[] bounds = touchingLadder.GetBounds();
        while (true)
        {
            yield return null;
            var input = Input.GetAxisRaw("Vertical");
            rigidbody2D.velocity = new Vector2(0, input * speed);
            if (Input.GetKeyDown(KeyCode.X) || transform.position.y > bounds[0].y || transform.position.y < bounds[1].y)
            {
                rigidbody2D.velocity = new Vector2(0, 0);
                rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
                rigidbody2D.gravityScale = gScale;
                isClimbing = false;
                animator.SetBool("climbing", false);
                yield break;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ladder")
        {
            isTouchingLadder = true;
            touchingLadder = collision.gameObject.GetComponent<Ladder>();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ladder")
        {
            isTouchingLadder = false;
            touchingLadder = null;
        }
    }
}
