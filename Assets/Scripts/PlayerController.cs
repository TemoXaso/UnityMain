using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float rotateSpeed;
    public float JumpForce;
    private Vector3 dir;
    private Rigidbody rb;
    private bool canJump;
    public Color playerColor;
    public Color collisionColor;
    public List<MeshRenderer> meshRenderer;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        dir = new Vector3();
        foreach(var item in meshRenderer)
        {
            item.material.color = playerColor;            
        }

    }

    void Update()
    {
        if(GameManager.Instance.gamepaused) return;
        dir.x = Input.GetAxisRaw("Vertical");
        dir.Normalize();

        transform.Translate(dir * speed * Time.deltaTime);
        transform.Rotate(0, Input.GetAxisRaw("Horizontal") * rotateSpeed * Time.deltaTime, 0);

        if (Input.GetKeyDown(KeyCode.Space) && canJump) 
        { 
            rb.AddForce(0, JumpForce, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            canJump = true;
        }
        // collision.transform.GetComponent<MeshRenderer>().material.color = collisionColor;
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            canJump = false;
        }
    }
}
