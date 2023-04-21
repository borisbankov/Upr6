using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills : MonoBehaviour
{
    // Start is called before the first frame update

    RaycastHit hit;
    public float cooldown = 1.0f;
    public float timer = -1.0f;

    public AudioSource blinkSource;
    public AudioClip blinkClip;
    void Start()
    {
        blinkSource.clip = blinkClip;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B) && Time.time > timer)
        {
            timer = Time.time + cooldown;
            blinkSource.Play();
            if(GetObjectAtDistance() != null)
            {
                Blink();
            }
            else
            {
                transform.Translate(Vector3.forward * 10.0f);
            }
        }
    }

    private GameObject GetObjectAtDistance()
    {
        Vector3 origin = transform.position;
        Vector3 direction = transform.forward;
        float range = 10.0f;
        if(Physics.Raycast(origin, direction, out hit, range))
        {
            return hit.collider.gameObject;
        } 
        else
        {
            return null;
        }
    }

    void Blink()
    {
        transform.position = hit.point + -hit.normal + Vector3.up;
    }
}
