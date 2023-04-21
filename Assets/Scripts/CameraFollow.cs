using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;

    public float rotateSpeed = 5.0f;
    public float currentDistance = 0.0f;
    public float cameraSpeed = 10.0f;
    public float maxZoom = 3.0f;
    public float minZoom = -3.0f;

    public Vector3 resetPosition;
    public Quaternion resetRotation;
    void Start()
    {
        player = GameObject.Find("Player");
        offset = transform.position - player.transform.position;
        resetPosition = offset;
        resetRotation = transform.rotation;
    }

    void LateUpdate()
    {
        if (Input.GetMouseButton(1))
        {

            Quaternion angle = Quaternion.Euler(transform.TransformDirection(Input.GetAxisRaw("Mouse Y") * -rotateSpeed, Input.GetAxisRaw("Mouse X") * rotateSpeed, 0));
            offset = angle * offset;
        }

        if (Input.GetMouseButtonDown(2))
        {
            CameraReset();
        }

        currentDistance += Input.GetAxisRaw("Mouse ScrollWheel") * cameraSpeed;
        currentDistance = Mathf.Clamp(currentDistance, minZoom, maxZoom);

        //offset.y = Mathf.Clamp(offset.y, 0, 7);
        transform.position = player.transform.position + offset + currentDistance * transform.forward;

        transform.LookAt(player.transform);
    }

    public void CameraReset()
    {
        offset = resetPosition;
        transform.rotation = resetRotation;
        currentDistance = 0.0f;
    }
}