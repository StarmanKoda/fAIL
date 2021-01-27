using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class MovementScript : MonoBehaviour
{
    public float Speed;
    public int Health = 100;
    public Text HealthDisplay;
    public GameObject Bob;
    public KeyCode Right;
    public KeyCode Left;
    public KeyCode Jump;
    public Rigidbody RB;
    public float JumpForce;
    public bool IsGrounded;
    public float TargetDistance;
    


// Update is called once per frame
public void Update()
    {
        
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.TransformDirection(0, -1, 0), Color.red);

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, TargetDistance))
        {
            IsGrounded = true;
            Debug.Log("Did Hit");
        }
        else
        {
            IsGrounded = false;
            Debug.Log("No Hit");
        }

        if (Input.GetKey(Right))
        {
            Bob.transform.Translate(new Vector2(Speed * Time.deltaTime, 0));
        }

        if (Input.GetKey(Left))
        {
            Bob.transform.Translate(new Vector2(-Speed * Time.deltaTime, 0));
        }
        

        if (IsGrounded && Input.GetKey(Jump))
        {
            RB.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        }

        
    }

    private void OnTriggerEnter()
    {
        Health = Health - 5;
        HealthDisplay.text = Health.ToString();
    }

    private void Kill()
    {
        Destroy(this.gameObject);
    }
}
