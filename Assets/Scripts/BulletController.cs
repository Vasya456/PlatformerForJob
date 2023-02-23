using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    
    [SerializeField] private float _speed = 4f;


    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector2.left * _speed * Time.deltaTime);
        

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") 
        {
            Destroy(gameObject);
        }
    }

}
