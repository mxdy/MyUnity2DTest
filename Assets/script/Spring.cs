using UnityEngine;
using System.Collections;

public class Spring : MonoBehaviour {

    enum DirForce
    {
        UP,DOWN,LEFT,RIGHT
    }

    [SerializeField]
    DirForce dirForce = DirForce.UP;

    [SerializeField]
    float forceValue;

    [SerializeField]
    float distance; // 上弹高度

    //[SerializeField]
    //float runTime; // 运动时间

	// Use this for initialization
	void Start () {
	
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log("---------");

        Transform trans = coll.transform;
        switch (dirForce)
        {
            case DirForce.UP:
                AddForce(trans, Vector2.up);
                break;
            case DirForce.DOWN:
                AddForce(trans, Vector2.down);
                break;
            case DirForce.LEFT:
                AddForce(trans, Vector2.left);
                break;
            case DirForce.RIGHT:
                AddForce(trans, Vector2.right);
                break;
            default:
                break;
        }
    }

    void AddForce(Transform trans, Vector2 vec2)
    {
        Rigidbody2D rigid = trans.transform.GetComponent<Rigidbody2D>();
        rigid.Sleep();
        rigid.WakeUp();
        rigid.AddForce(vec2 * forceValue, ForceMode2D.Force);
    }

    // Update is called once per frame
    void Update () {
	
	}
}
