using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform target;//đối tượng follow

    [SerializeField]
    private float speed=0.2f;

    [SerializeField]
    private Vector3 offset; //khoảng cách từ camera tới mục tiêu

    private void Start()
    {
        offset = transform.position - target.position;
    }
    void LateUpdate()
    {
        
        // tạo vị trí mới mà camera sẽ di chuyển tới
        Vector3 newPos = target.position + offset;
        Vector3 smoothCam = Vector3.Lerp(transform.position, newPos, speed * Time.deltaTime);

        //cập nhật vị trí cho camera
        transform.position = smoothCam;
    }
}
