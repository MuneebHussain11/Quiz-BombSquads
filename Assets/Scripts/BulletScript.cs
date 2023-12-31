using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public ParticleSystem ecplosionParticle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward  * Time.deltaTime * 20f);

        if(transform.position.x < -20 || transform.position.x > 20)
        {
            Destroy(gameObject);
        }
        else if(transform.position.z < -20 || transform.position.z > 20)
        {
            Destroy(gameObject) ;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
