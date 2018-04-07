using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    public GameObject explosion;
    public float scoreValue;
    
    private void OnCollisionEnter(Collision other)
    {
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
}
