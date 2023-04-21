using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blaster : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prefab;
    public float shootCooldown = 0.2f;
    public float shootTimer = -1.0f;

    public AudioSource bulletSource;
    public AudioClip bulletClip;

    private void Awake()
    {
        bulletSource.clip = bulletClip;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootBullet();
        }
    }
    
    void ShootBullet()
    {
        if(Time.time > shootTimer)
        {
            bulletSource.Play();
            shootTimer = Time.time + shootCooldown;
            GameObject bullet = Instantiate(prefab, transform.position, transform.rotation);
            StartCoroutine(DestroyDelay(bullet));
        }
    }

    IEnumerator DestroyDelay(GameObject bullet)
    {
        yield return new WaitForSeconds(5.0f);
        Destroy(bullet);
    }
}
