using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayArea : MonoBehaviour {
    public List<Transform> playAreaCells = new List<Transform> ();
    public int numberOfCells = 4;
    public float deltaZPerSecond = 1.0f;

    private List<Transform> currentCells = new List<Transform> ();
    private int nearEdgeZ = 0;
    private int farEdgeZ = 0;

    void Start () {
        for (; farEdgeZ < numberOfCells; farEdgeZ++) {
            int prefabCellIndex = UnityEngine.Random.Range (0, playAreaCells.Count);
            currentCells.Add (Instantiate (playAreaCells[prefabCellIndex],
                new Vector3 (0, 0, farEdgeZ), Quaternion.identity, transform));
        }
        StartCoroutine ("LowPeriodUpdate");
    }

    IEnumerator LowPeriodUpdate () {
        while (true) {
            yield return new WaitForSeconds (0.2f);
            Vector3 currentPosition = transform.position;
            int currentPositionZ = (int) currentPosition.z;

            while (nearEdgeZ < -currentPositionZ) {
                Destroy (currentCells[0].gameObject);
                currentCells.RemoveAt (0);
                nearEdgeZ += 1;
            }
            while (currentCells.Count < numberOfCells) {
                int prefabCellIndex = UnityEngine.Random.Range (0, playAreaCells.Count);
                currentCells.Add (Instantiate (
                    playAreaCells[prefabCellIndex],
                    new Vector3 (0, 0, farEdgeZ + currentPosition.z), Quaternion.identity, transform));
                farEdgeZ += 1;
            }
        }
    }

    void Update () {
        Vector3 currentPosition = transform.position;
        currentPosition.z += deltaZPerSecond * Time.deltaTime;
        transform.position = currentPosition;
    }
}