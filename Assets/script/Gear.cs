using UnityEngine;
using System.Collections;

public class Gear : MonoBehaviour {

    [SerializeField]
    float hforce;

    bool isRunning = false;

    Rigidbody2D target;

	// Use this for initialization
	void Start () {
	
	}
	
    void FixedUpdate()
    {
        if (isRunning)
        {
            target.AddForce(Vector2.left * hforce, ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Player")
        {
            target = other.gameObject.GetComponent<Rigidbody2D>();
            isRunning = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.tag == "Player")
        {
            target = null;
            isRunning = false;
        }
    }
}

