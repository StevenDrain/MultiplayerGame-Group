using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeetAnimController : MonoBehaviour
{
    Animator animator;
    private Vector3 originalScale;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        originalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetBool("isWalking", true);
            transform.localScale = new Vector3(-originalScale.x, originalScale.y, originalScale.z); // Flip left
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetBool("isWalking", true);
            transform.localScale = new Vector3(originalScale.x, originalScale.y, originalScale.z); // Flip right
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        if (Input.GetKey(KeyCode.RightControl))
        {
            animator.SetBool("isJumping", true);
        }
        else
        {
            animator.SetBool("isJumping", false);
        }
    }
}