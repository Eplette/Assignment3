using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayDead : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.Play("Dead_PacStudent");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
