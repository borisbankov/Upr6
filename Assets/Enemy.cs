using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().UpdateHealth(-damage);
            //collision.gameObject.GetComponent<Rigidbody>().useGravity = false;
        }
    }


}
