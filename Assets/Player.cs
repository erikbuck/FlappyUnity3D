using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float deltaYPerFrame = 0.1f;

    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKey ("up")) {
            Vector3 currentPosition = transform.position;
            currentPosition.y += deltaYPerFrame;
            transform.position = currentPosition;
        }

        if (Input.GetKey ("down")) {
            Vector3 currentPosition = transform.position;
            currentPosition.y -= deltaYPerFrame;
            transform.position = currentPosition;
        }
    }
}