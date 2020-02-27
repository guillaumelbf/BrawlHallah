using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class PlayerController : MonoBehaviour
{
    public XboxController ctrl;
    float speed = 10, jumpForce = 300;
    [SerializeField]
    bool isGrounded, canMove, isAtck = false, isTp = false;

    Rigidbody rb;

    float turnSmoothVelocity;

    Vector2 inputDir = Vector2.zero;

    Animator annim;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        annim = gameObject.GetComponent<Animator>();
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = Vector2.ClampMagnitude(new Vector2(XCI.GetAxisRaw(XboxAxis.LeftStickX, ctrl), XCI.GetAxisRaw(XboxAxis.LeftStickY, ctrl)), 1f);
        inputDir = input.normalized;

        if(canMove && inputDir != Vector2.zero)
        {
            float targetRotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + 0;
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, 0.05f);
        }

        if (isGrounded && XCI.GetButtonDown(XboxButton.A, ctrl))
            rb.AddForce(new Vector3(0, jumpForce, 0));

        if (!isGrounded)
            rb.AddForce(new Vector3(0, -1, 0));

        //Debug annim
        if (!isAtck && annim.GetBool("Atck"))
            annim.SetBool("Atck", false);
        if (!isTp && annim.GetBool("Tp"))
            annim.SetBool("Tp", false);

        annim.SetBool("Tp", false);
        if (XCI.GetButtonDown(XboxButton.B, ctrl))
        if (Input.GetButtonDown("Fire1") && !isAtck)
            annim.SetBool("Atck", true);

        if (Input.GetButtonDown("Fire2") && !isTp)
            annim.SetBool("Tp", true);
    }
    private void startTp()
    {
        rb.isKinematic = true;
        canMove = false;
    }
    private void tp()
    {
        transform.position += transform.forward * 5;
    }
    private void endTp()
    {
        rb.isKinematic = false;
        canMove = true;
        annim.SetBool("Tp", false);
    }

    private void startAtck()
    {
        isAtck = true;
    }

    private void endAtck()
    {
        annim.SetBool("Atck", false);
        isAtck = false;
    }

    private void FixedUpdate()
    {
        if(canMove && inputDir != Vector2.zero)
            transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.tag == "Ground") isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Ground") isGrounded = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && isAtck)
            other.GetComponent<Rigidbody>().AddForce((transform.forward * 500)+Vector3.up*200);
    }
}
