using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayArea : MonoBehaviour {
    public List<Transform> playAreaCells = new List<Transform> ();
    public int numberOfCells = 8;
    public float deltaZPerFrame = 0.01f;

    List<Transform> currentCells = new List<Transform> ();
    int lastZ = 0;
    int nextZ = 0;

    void Start () {
        for (int i = 0; i < numberOfCells; i++) {
            nextZ = i;
            currentCells.Add (Instantiate (playAreaCells[i % playAreaCells.Count],
                new Vector3 (0, 0, nextZ), Quaternion.identity, transform));
        }
        StartCoroutine ("moveCells");
    }

    IEnumerator moveCells () {
        while(true) {
            UnityEngine.Debug.Log ("Couroutine!");
            yield return new WaitForSeconds (0.5f);
        }
     }

    void Update () {
        Vector3 currentPosition = transform.position;
        currentPosition.z += deltaZPerFrame;
        transform.position = currentPosition;
        if (lastZ > (int) currentPosition.z) {
            Destroy (currentCells[0].gameObject, 2.0f);
            currentCells.RemoveAt (0);
            lastZ = (int) currentPosition.z;
            currentCells.Add (Instantiate (
                playAreaCells[(-lastZ) % playAreaCells.Count],
                new Vector3 (0, 0, nextZ), Quaternion.identity, transform));
            nextZ += 1;
        }
    }
}