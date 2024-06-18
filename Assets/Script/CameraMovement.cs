using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float velocidad = 5.0f;
    public float sencibilidadMouse = 100.0f;
    public float rangoApertura = 60.0f;

    private float rotacionVertical = 0; 

    private float xAxis, zAxis;
    public Rigidbody rigid;
    public Transform manos;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked; 
    }

    void FixedUpdate()
    {
     
        xAxis = Input.GetAxisRaw("Horizontal");
        zAxis = Input.GetAxisRaw("Vertical");

        if (xAxis != 0 || zAxis != 0)
        {
            Movement();
        }
    }

    public void Movement()
    {
        Vector3 direction = (transform.forward * zAxis + transform.right * xAxis).normalized * velocidad;
        rigid.velocity = new Vector3(direction.x, rigid.velocity.y, direction.z);
    }

    void Update()
    {
        float rotacionHorizontal = Input.GetAxis("Mouse X") * sencibilidadMouse * Time.deltaTime;
        rotacionVertical -= Input.GetAxis("Mouse Y") * sencibilidadMouse * Time.deltaTime;
        rotacionVertical = Mathf.Clamp(rotacionVertical, -rangoApertura, rangoApertura);
        transform.Rotate(0, rotacionHorizontal, 0);

        manos.localRotation = Quaternion.Euler(rotacionVertical, 0, 0);
    }
}