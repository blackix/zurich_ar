using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UserClickRay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {

        
            Vector2 mousePosition = Mouse.current.position.ReadValue();

            if (Keyboard.current.anyKey.wasPressedThisFrame)
            {
                Debug.Log("A key was pressed");
            }

            if (Gamepad.current.aButton.wasPressedThisFrame)
            {
                Debug.Log("A button was pressed");
            }
        
        /*
        if (Input.GetMouseButtonDown(0) )
        {
            OnUserClick();

        }
        */

    }

        // See Order of Execution for Event Functions for information on FixedUpdate() and Update() related to physics queries
        void OnUserClick()
    {
        Debug.Log("hello");

        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, 10))
            print("There is something in front of the object!");
    }
}
