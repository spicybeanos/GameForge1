using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public float Speed = 10f;
    public float Sensitivity = 10f;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    float rotationX = 0;
    private void Move()
    {
        Vector3 velocity = new Vector3(0,0,0);

        float movex = Input.GetAxis("Horizontal") * Speed * Time.deltaTime;
        float movez = Input.GetAxis("Vertical") * Speed * Time.deltaTime;

        float rotx = Input.GetAxis("Mouse X") * Sensitivity * Time.deltaTime;
        float roty = Input.GetAxis("Mouse Y") * Sensitivity * Time.deltaTime;
        rotationX -= roty;
        rotationX = Mathf.Clamp(rotationX, -90, 90);
        cam.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.Rotate(Vector3.up * rotx);

        velocity = transform.right * movex + transform.forward * movez;

        controller.Move(velocity);
    }
}
