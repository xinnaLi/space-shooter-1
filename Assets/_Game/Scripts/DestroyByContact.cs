using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;
    public float scoreValue;
    
    private void OnCollisionEnter(Collision other)
    {
        Instantiate(explosion, transform.position, transform.rotation);
        if (other.gameObject.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
        }
        Destroy(other.gameObject);
        Destroy(this.gameObject);
    }
}
