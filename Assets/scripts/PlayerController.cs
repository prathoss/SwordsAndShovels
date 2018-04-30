using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    private int count;
    public Text Points;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        count = 0;
        SetPoints();
    }
    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Vector3 up = transform.TransformDirection(Vector3.up);
            rb.AddForce(up * 5, ForceMode.Impulse);
        }
    }
    void FixedUpdate()
    {
        float moveHoriznotal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHoriznotal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetPoints();
            if (GameObject.FindGameObjectsWithTag("PickUp").Length == 0)
            {
                Time.timeScale = 0;
                // WON Text
                System.Threading.Thread.Sleep(2000);
                Application.Quit();
            }
        }
    }
    private void SetPoints()
    {
        Points.text = "Number of points: " + count.ToString();
    }
}
