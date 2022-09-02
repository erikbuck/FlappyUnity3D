using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float flapForceMagnitued = 1.0f;
    public float deltaYPerFrame = 0.001f;
    public GameObject pegasus;
    private Animator animator;
    private Rigidbody rigidbody;

    private void OnTriggerEnter (Collider other) {
        SendMessageUpwards ("GameOver");
    }

    // Start is called before the first frame update
    void Start () {
        animator = pegasus.GetComponent<Animator> ();
        animator.SetBool ("isFlapping", true);
        rigidbody = gameObject.GetComponent<Rigidbody> ();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown ("space")) {
            animator.SetBool ("isFlapping", true);
            rigidbody.AddForce (new Vector3 (0, 1, 0) * flapForceMagnitued,
                ForceMode.Impulse);
        } else {
            Vector3 velocity = rigidbody.velocity;
            if (velocity.y < -1.5f && animator.GetBool ("isFlapping")) {
                animator.SetBool ("isFlapping", false);
            }
            Vector3 currentPosition = transform.position;
            animator.SetBool ("onGround", 0.1f > currentPosition.y);
        }
    }
}