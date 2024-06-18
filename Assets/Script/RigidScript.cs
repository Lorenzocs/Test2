using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidScript : MonoBehaviour
{

    public Rigidbody myRigid;
    public float jumpForce;
    public float speed;

    void Start()
    {
        myRigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myRigid.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    /*   public void FixedUpdate()
       {
           float xAxis = Input.GetAxis("Horizontal");
           float yAxis = Input.GetAxis("Vertical");

           Vector3 direction = new Vector3(xAxis, 0, yAxis) * speed;
           rigid.velocity= new Vector3(direction.x, rigid.velocity.y ,direction.z) ;
       }*/

    public void FixedUpdate()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(yAxis, 0, -xAxis);
        myRigid.AddTorque(direction * speed); 
    }
}
