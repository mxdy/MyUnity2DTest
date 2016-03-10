using UnityEngine;
using System.Collections;

public class ChangeBox : MonoBehaviour {

    bool toShort = true;

    [SerializeField]
    float changeValue;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (toShort)
        {
            transform.localScale -= new Vector3(changeValue, 0, 0);

            if (transform.localScale.x <= 0)
            {
                transform.localScale = new Vector3(0, transform.localScale.y, 1);
                toShort = false;
            }
        }
	}
}
