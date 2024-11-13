using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ControllerP : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float limitX;
    [SerializeField] private float limitY;
    private Rigidbody rb;
    private Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetAxisRaw("Vertical") == 0 && Input.GetAxisRaw("Horizontal") == 0 )
        {
            animator.SetInteger("Horizontal", 0);
            rb.velocity = Vector3.zero;
            return;
        }
        float valorZ = Input.GetAxisRaw("Vertical");
        float valorX = Input.GetAxisRaw("Horizontal");

        animator.SetInteger("Horizontal", (int)valorX);
       // transform.Translate(new Vector3(valorX * speed, 0, valorZ * speed) * Time.deltaTime);
       rb.velocity = new Vector3 (valorX * speed, 0, valorZ * speed);

    }
}
