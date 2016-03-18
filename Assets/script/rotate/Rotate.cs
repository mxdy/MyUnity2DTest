using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

    public Transform cube;
    public Transform sphere;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        cube.Rotate(Vector3.up, 2.5f,Space.World);
	}
}
