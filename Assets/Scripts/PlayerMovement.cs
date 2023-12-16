using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private float force;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Thêm lực tác động vào nhân vật
            rb.AddForce(Vector3.up * force, ForceMode.Impulse);
            rb.AddTorque(Vector3.right * force, ForceMode.Impulse);
        }
    }
}
