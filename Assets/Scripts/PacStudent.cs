using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudent : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isDead", false);
        animator.SetBool("isAlive", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}