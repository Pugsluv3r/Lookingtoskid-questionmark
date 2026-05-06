using UnityEngine;

public class Playermove : MonoBehaviour
{
    [Header("Jump shit")] //This is unoptimized i dont recomend using it
    public bool isGrounded;
    public bool isfalling;
    [Header("Gameobjects")]
    public GameObject Playercapsule;
    public GameObject Playercamera;
    public GameObject Groundcheck;
    [Header("Movement settings")]
    public float Velocity;
    public float Jumpforce;
    public float Gravity;
    public float Maxspeed;
    public float jumpcooldown;
    public float checkdelay;
    public float Currentvelocity;

    [Header("Mouse settings")]
    public float mouseSens;
    void Start()
    {

    }
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Playercapsule.GetComponent<Rigidbody>().AddForce(transform.forward * Velocity, ForceMode.Acceleration);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Playercapsule.GetComponent<Rigidbody>().AddForce(-transform.forward * Velocity, ForceMode.Acceleration);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Playercapsule.GetComponent<Rigidbody>().AddForce(-transform.right * Velocity, ForceMode.Acceleration);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Playercapsule.GetComponent<Rigidbody>().AddForce(transform.right * Velocity, ForceMode.Acceleration);
        }
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > checkdelay)
        {
            Jump();
            checkdelay = Time.time + jumpcooldown;
        }
        if (Playercapsule.GetComponent<Rigidbody>().velocity.magnitude > Maxspeed)
        {
            Playercapsule.GetComponent<Rigidbody>().velocity = Playercapsule.GetComponent<Rigidbody>().velocity.normalized * Maxspeed;
        }
        if (isfalling = false && Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            VelocityClamp();
        }
        UpdateMouseLook();
        keepthat2running();
        Currentvelocity = Playercapsule.GetComponent<Rigidbody>().velocity.magnitude;

    }

    void Jump()
    {
            if (isGrounded == true)
            {
                Playercapsule.GetComponent<Rigidbody>().AddForce(transform.up * Jumpforce, ForceMode.Impulse);
            }
    }

    void keepthat2running()
    {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("ground"))
        {

            if (Groundcheck.GetComponent<Collider>().bounds.Intersects(obj.GetComponent<Collider>().bounds))
            {
                isGrounded = true;
                Debug.Log("Grounded");
            }
            else
            {
                isGrounded = false;
            }
            //isfalling
            if(Playercapsule.GetComponent<Rigidbody>().velocity.y < -0.1f)
            {
                isfalling = true;
            }
            else
            {
                isfalling = false;
            }
        }
        
    }

    void UpdateMouseLook()
    {
        float mouseY = Input.GetAxis("Mouse Y");
        float mouseX = Input.GetAxis("Mouse X");
        Camera camera = this.gameObject.GetComponentInChildren<Camera>();
        camera.transform.Rotate(Vector3.right * mouseY * -mouseSens);
        this.gameObject.transform.Rotate(Vector3.up * mouseX * mouseSens);
    }
    void VelocityClamp()
    {
        this.gameObject.GetComponent<Rigidbody>().velocity = this.gameObject.GetComponent<Rigidbody>().velocity.normalized * 0.3f;
        Debug.Log("datshizzclampedboi");

    }
}
