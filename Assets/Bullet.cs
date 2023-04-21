using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource explosionSource;
    public AudioClip explosionClip;
    void Start()
    {
        explosionSource = GameObject.Find("ExplosionSound").GetComponent<AudioSource>();
        explosionSource.clip = explosionClip;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * 20.0f * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            explosionSource.Play();
            Destroy(other.gameObject);
        }

        if(other.gameObject.tag != "Enemy" & other.gameObject.tag != "PickUp")
        {
            Destroy(this.gameObject);
        }
    }


}
