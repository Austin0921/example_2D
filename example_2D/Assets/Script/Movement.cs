using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public FixedJoystick joystick;
    public Animator animator;
    public float speed;
    float hInput, vInput;

    private void FixedUpdate()
    {
        //float horizontal = Input.GetAxisRaw("Horizontal");
        //float vertical = Input.GetAxisRaw("Vertical");

        hInput = joystick.Horizontal * speed * Time.deltaTime;
        vInput = joystick.Vertical * speed * Time.deltaTime;

        Vector3 direction = new Vector3 (hInput, vInput);

        AnimateMovement(direction);

        transform.Translate(hInput, vInput, 0);

        transform.position += direction * speed * Time.deltaTime;
    }
    void AnimateMovement(Vector3 direction)
    {
        if (animator != null)
        {
            if(direction.magnitude > 0)
            {
                animator.SetBool("isMoving", true);
                animator.SetFloat("horizontal", direction.x);
                animator.SetFloat("vertical", direction.y);
            }
            else
            {
                animator.SetBool("isMoving", false);
            }
        }
    }
}
