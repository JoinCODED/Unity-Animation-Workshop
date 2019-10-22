using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator anim;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("space")){
            anim.SetBool("isWalking", true);
            anim.SetBool("isRunning", true);
            rb.AddForce(transform.forward*10000);
        } else {
            anim.SetBool("isWalking", false);
            anim.SetBool("isRunning", false);
        }
        
    }
}
