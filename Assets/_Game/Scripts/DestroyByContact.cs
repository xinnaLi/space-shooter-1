﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    public GameObject explosion;
    public int scoreValue;
    private GameController gameController;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if(gameControllerObject!=null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(this.gameObject);
        //gameController.AddScore(scoreValue);
    }
    
}
