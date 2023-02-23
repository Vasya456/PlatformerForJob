using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantController : MonoBehaviour
{

    private Animator animator;

    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletPosition;

    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(CreateBullet());
    }


   
    void Update()
    {
       
       // CreateBullet();
    }

    IEnumerator CreateBullet() 
    {
        animator.SetTrigger("Attack");
        Instantiate(bullet, bulletPosition.position, Quaternion.identity);
        yield return new WaitForSeconds(4);
        StartCoroutine(CreateBullet());
        

    }


}
