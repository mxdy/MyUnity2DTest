using UnityEngine;
using System.Collections;

public class DropGround : MonoBehaviour {

    bool isWork = false;

    [SerializeField]
    float a;
    float time = 0;
    float timeIdx = 0;

    [SerializeField]
    float waiteTime;

    [SerializeField]
    float distroyTime;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (isWork)
        {
            time += Time.deltaTime;
            if (time > waiteTime)
            {
                timeIdx += Time.deltaTime;
                transform.Translate(Vector3.down * a * timeIdx);

                if (timeIdx >= distroyTime)
                {
                    isWork = false;
                    Destroy(this.gameObject);
                }
            }
            
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Player")
        {
            isWork = true;
        }
    }
}
