using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody myRigid;
    public float force;
    public float speed;
    public float speedRotation;

    [SerializeField] private bool isGrounded;
    private float xAxis;
    private float zAxis;

    public Animator anim;
    void Start()
    {
        myRigid = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        
        AudioManager.instance.PlaySound("click");
    }


    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded == true)
            {
                myRigid.AddForce(Vector3.up * force, ForceMode.Impulse);
            }
        }
        xAxis = Input.GetAxis("Horizontal");
        zAxis = Input.GetAxis("Vertical");

        anim.SetFloat("ZAxis", zAxis);
        anim.SetFloat("XAxis", xAxis);

        if (Input.GetKeyDown(KeyCode.R))
        {
            anim.SetTrigger("Reload");
        }

    }


    void FixedUpdate()
    {
        if (xAxis != 0 || zAxis != 0)
        {
            Movement();
        }

    }


    public void SoundFoot()
    {
        AudioManager.instance.PlaySoundFoot();
    }

    public void Movement()
    {
        Vector3 direction = (transform.forward * zAxis) * speed;
        myRigid.velocity = new Vector3(direction.x, myRigid.velocity.y, direction.z);

        transform.Rotate(0, xAxis * Time.deltaTime * speedRotation, 0);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            isGrounded = true;
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            isGrounded = false;
        }
    }

}
