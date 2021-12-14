using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    new public Rigidbody2D rigidbody2D;
    Vector2 movement;
    private Animator animator;

    public float speed = 0f;

    public Player playerData;

    float lastMovementY = 0;
    float lastMovementX = 0;

    Vector2 lastMovement;

    private void Start()
    {
        animator = this.GetComponent<Animator>();

        speed = playerData.speed;
        animator.runtimeAnimatorController = playerData.animatorController;
    }

    // Update is called once per frame
    private void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        setUpAnimator();

    }

    void setUpAnimator()
    {
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        //todo fix bug where the down animation is being played after moving just a bit in any direction
        //bug related to the blend tree?
        if (movement.sqrMagnitude > 0)
        {
            lastMovement.x = movement.x;
            lastMovement.y = movement.y;

            animator.SetFloat("LastMovementX", lastMovement.x);
            animator.SetFloat("LastMovementY", lastMovement.y);
        }


    }

    private void FixedUpdate()
    {
        rigidbody2D.MovePosition(rigidbody2D.position + movement * speed * Time.fixedDeltaTime);
    }
}
