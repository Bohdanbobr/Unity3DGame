using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class attackPlayer : MonoBehaviour
{
   public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
           animator.SetBool("IsAttack", true);
        else if (Input.GetButtonUp("Fire1"))
            animator.SetBool("IsAttack", false);
    }
}
