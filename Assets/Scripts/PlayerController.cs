using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 1000.0f;
    private Rigidbody playerRb;
    private GameObject focalPoint;
    public GameObject centerOfMass;
    public GameObject powerupIndicator;
    public bool hasPowerup;
    public int powerUpDuration;
    public GameObject pozycja;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    
        //  playerRb.centerOfMass = centerOfMass.transform.position;
        powerupIndicator.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        playerRb.AddForce(focalPoint.transform.forward * verticalInput* speed *Time.deltaTime);
        playerRb.AddTorque(transform.up * horizontalInput * 100);
        powerupIndicator.transform.position = pozycja.transform.position;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup )
        {
            Destroy(collision.gameObject);

        }
        else if (collision.gameObject.CompareTag("Friend"))
        {
            Destroy(collision.gameObject);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {
            Destroy(other.gameObject);
            hasPowerup = true;
            powerupIndicator.SetActive(true);
            StartCoroutine(PowerupCooldown());
        }
    }
    IEnumerator PowerupCooldown()
    {
        yield return new WaitForSeconds(powerUpDuration);
        hasPowerup = false;
        powerupIndicator.SetActive(false);
    }
}
