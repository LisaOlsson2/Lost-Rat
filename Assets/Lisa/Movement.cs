using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    readonly float legStrength = 4300, jumpForce = 550, maxVelocity = 13, flipTime = 0.8f, maxJumpVelocity = 10, extraJumpForce = 140, timescale = 1.8f, camBorder = 110;

    [SerializeField]
    Transform cam;

    Rigidbody rb;
    GameObject ground;

    bool grounded, flipped;

    void Start()
    {
        Time.timeScale = timescale;
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if ((cam.position.x < camBorder && cam.position.x < transform.position.x) || (cam.position.x > -camBorder && cam.position.x > transform.position.x))
        {
            cam.position = new Vector3(transform.position.x, cam.position.y, cam.position.z);
            //cam.position += new Vector3(transform.position.x - cam.position.x, 0, 0) * camSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A) && rb.velocity.x > -maxVelocity)
        {
            rb.AddForce(Vector3.left * legStrength * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D) && rb.velocity.x < maxVelocity)
        {
            rb.AddForce(Vector3.right * legStrength * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (grounded)
            {
                rb.AddForce(Vector3.up * jumpForce);
            }
            else if (!flipped)
            {
                StartCoroutine(Flip());
            }
        }

        if (Input.GetKey(KeyCode.W) && rb.velocity.y > 0 && rb.velocity.y < maxJumpVelocity)
        {
            rb.AddForce(Vector3.up * extraJumpForce * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && collision.GetContact(0).normal == Vector3.up)
        {
            ground = collision.gameObject;
            flipped = false;
            grounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject == ground)
        {
            grounded = false;
        }
    }

    IEnumerator Flip()
    {
        flipped = true;
        rb.useGravity = false;
        rb.velocity = Vector3.zero;
        yield return new WaitForSeconds(flipTime);
        rb.useGravity = true;
    }
}
