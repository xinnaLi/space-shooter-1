using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Leap;
//using Leap.Unity;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour {
    /*
    public Controller controller;
    public float handPalmPitch;
    public float handPalmYam;
    public float handPalmRoll;
    public float handWristRot;
    */
    public float speed;
    public Boundary boundary;

    public GameObject shot;
    public Transform shotSpawn;

    public float nextFire;
    private float fireRate;

    void Update()
    {
        //moveHand();

        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            //controller.audio.Play();
        }
       
    }

    void FixedUpdate()
    {
        float moveLeftAndRight = Input.GetAxis("Horizontal");
        float moveUpAndDown = Input.GetAxis("Vertical");
        
        Vector3 movement = new Vector3(moveLeftAndRight, moveUpAndDown, 0.0f);
        GetComponent<Rigidbody>().velocity = movement * speed;
        GetComponent<Rigidbody>().position = new Vector3(
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(GetComponent<Rigidbody>().position.y, boundary.yMin, boundary.yMax),
            0.0f
        );
        
    }
    /*
    bool moveHand()
    {
        controller = new Controller();
        Frame frame = controller.Frame();
        List<Hand> hands = frame.Hands;

        if (frame.Hands.Count == 0)
        {
            return false;
        }

        Hand firstHand = hands[0];
        handPalmPitch = hands[0].PalmNormal.Pitch;
        handPalmYam = hands[0].PalmNormal.Yaw;
        handPalmRoll = hands[0].PalmNormal.Roll;
        handWristRot = hands[0].WristPosition.Pitch;

        Debug.Log("Pitch :" + handPalmPitch);
        Debug.Log("Roll :" + handPalmRoll);
        Debug.Log("Yam :" + handPalmYam);

        if (handPalmYam > -2f && handPalmYam < 3.5f)
        {
            transform.Translate(new Vector3(0, 0, 1 * Time.deltaTime));
        }
        else if (handPalmYam < -2.2f) {
            transform.Translate(new Vector3(0, 0, -1 * Time.deltaTime));
        }

        return true;
    }
    */
}
