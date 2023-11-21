using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    
    public float speed;
    public float rotationSpeed;
    public float jumpForce = 5f;

    private Vector2 movementValue;
    private float lookValue;
    private Rigidbody rb;
 
    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
    }
  
    public void OnMove(InputValue value)
    {
        movementValue = value.Get<Vector2>() * speed;
    }
    
    public void OnLook(InputValue value)
    {
        lookValue = value.Get<Vector2>().x * rotationSpeed;
    }
    // Update is called once per frame
    void Update()
    {
       
        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            speed *= 3;
        }

        if (Mouse.current.rightButton.wasReleasedThisFrame)
        {
            speed /= 3;
        }
        if (Keyboard.current.spaceKey.wasPressedThisFrame )
        {
           Jump(); 
        }
     
        //transform.Translate(
        //   movementValue.x * Time.deltaTime, 0, movementValue.y * Time.deltaTime);
        //transform.Rotate(0, lookValue * Time.deltaTime, 0);

        rb.AddRelativeForce(movementValue.x * Time.deltaTime, 0, movementValue.y * Time.deltaTime,ForceMode.Impulse);
        rb.AddRelativeTorque(0, lookValue * Time.deltaTime, 0);

       
    }
   
    void Jump()
    {
        
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
         
     }






}
