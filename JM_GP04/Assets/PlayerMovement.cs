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
        rb = GetComponent<Rigidbody>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
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
        // 새로운 Input System에서 마우스 오른쪽 버튼 입력 가져오기
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
     
        transform.Translate(
            movementValue.x * Time.deltaTime, 0, movementValue.y * Time.deltaTime);
        transform.Rotate(0, lookValue * Time.deltaTime, 0);

       
    }
   
    void Jump()
    {
        
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
         
     }






}
