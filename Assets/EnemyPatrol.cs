using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform pointA = null, pointB = null;
    public float speed = 3.0f;
    bool _switch = false;

    void Start()
    {

    }

    void Update()
    {
        if (!_switch)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointA.position, speed * Time.deltaTime);
        }

        if (_switch)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointB.position, speed * Time.deltaTime);
        }

        if (transform.position == pointA.position)
        {
            _switch = true;
        }
        if (transform.position == pointB.position)
        {
            _switch = false;
        }

    }

}