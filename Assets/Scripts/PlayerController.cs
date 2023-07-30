using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private float speed = 5.0f;
    public GameObject bulletPrefab;
    public GameObject bulletPrefab2;
    public GameObject bulletPrefab3;
    public GameObject Enemy;
    public bool hasPowerUp = false;
    public GameObject powerUpicom;
    public ParticleSystem pickupParticle;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        

    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");


        playerRb.AddForce(Vector3.forward * forwardInput * speed);
        playerRb.AddForce(Vector3.right * horizontalInput * speed);


        if (Input.GetKeyDown(KeyCode.Space) && hasPowerUp == false)
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.Space) && hasPowerUp == true)
        {
            // Instantiate(bulletPrefabs[bulletPrefabs.Length], transform.position, Quaternion.identity);
            //for (int i = 0; i < bulletPrefabs.Length; i++)
            //{
            Instantiate(bulletPrefab, transform.position, bulletPrefab.transform.rotation);
            Instantiate(bulletPrefab2, transform.position, bulletPrefab2.transform.rotation);
            Instantiate(bulletPrefab3, transform.position, bulletPrefab3.transform.rotation);
            //}
        }
        powerUpicom.transform.position = transform.position + new Vector3(0, -0.3f, 0);

        if(transform.position.y < -5)
        {
            Destroy(gameObject);
        }

        //transform.Rotate(focalPoint.transform.up, rotationSpeed * horizontalInput * Time.deltaTime);
    }

  
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            powerUpicom.SetActive(true);
            Destroy(collision.gameObject);
            pickupParticle.Play();
            StartCoroutine(PowerupCountdownRoutine());
        }
    }
    IEnumerator PowerupCountdownRoutine() {
        yield return new WaitForSeconds(10);
        hasPowerUp = false;
    }
}

    
