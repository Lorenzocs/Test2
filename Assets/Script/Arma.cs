using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{
    private Animator animator;
    public int amountBullets;
    public int bulletsCharger;
    public GameObject effect;
    public Transform puntaArma;
    public GameObject line;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (bulletsCharger > 0)
            {
                animator.SetBool("Fire", true);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (bulletsCharger > 0)
            {
                animator.SetBool("Fire", false);

            }
            Invoke("ApagarLine", 0.3f);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (amountBullets > 0)
            {
                animator.SetTrigger("Reload");
            }
        }
    }

    public void Reload()
    {
        amountBullets -= 20;
        bulletsCharger = 20;
    }

    public void Fire()
    {
        if (bulletsCharger <= 0)
        {
            animator.SetBool("Fire", false);
            return;
        }
        line.SetActive(true);
        Instantiate(effect, puntaArma.position, Quaternion.identity);
        bulletsCharger--;

    }

    public void ApagarLine()
    {
        line.SetActive(false);
    }
}
