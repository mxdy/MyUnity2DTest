using UnityEngine;
using System.Collections;

public class PlayerContraller : MonoBehaviour {

    [SerializeField]
    float speed;

    [SerializeField]
    float speed_v;

    float up_time = 0;
    const float G = 10f;

    Rigidbody2D rg2d;

    enum PlayerState
    {
        JUMP_UP,
        JUMP_DOWN,
        RUNNING,
        IDLE
    }

    PlayerState ps = PlayerState.IDLE;

	// Use this for initialization
	void Start () {
        rg2d = transform.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate() {

        // 左
        if (Input.GetKey(KeyCode.A))
        {
            if (!IsJump())
            {
                Debug.Log("left");
                ps = PlayerState.RUNNING;
            }
            
            transform.Translate(Vector2.left * speed);
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            if (!IsJump())
            {
                Debug.Log("idle");
                ps = PlayerState.IDLE;
            }
        }

        // 右
        if (Input.GetKey(KeyCode.D))
        {
            if (!IsJump())
            {
                Debug.Log("right");
                ps = PlayerState.RUNNING;
            }

            transform.Translate(Vector2.right * speed);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            if (!IsJump())
            {
                Debug.Log("idle");
                ps = PlayerState.IDLE;
            }
        }

        // 上
        if (Input.GetKey(KeyCode.J))
        {
            if (IsJump())
                return;

            Debug.Log("up");
            ps = PlayerState.JUMP_UP;

            rg2d.velocity = Vector2.zero;
            rg2d.AddForce(Vector2.up * speed_v);
        }

        //switch (ps)
        //{
        //    case PlayerState.JUMP_UP:
        //        break;
        //    case PlayerState.JUMP_DOWN:

        //        break;
        //    case PlayerState.RUNNING:
        //        break;
        //    case PlayerState.IDLE:
        //        break;
        //    default:
        //        break;
        //}

        // 向下掉
        //if (rg2d.GetRelativePointVelocity(transform.localPosition).y < 0)
        //{
        //    //if (ps != PlayerState.IDLE)
        //    //{
        //        Debug.Log("down");
        //        ps = PlayerState.JUMP_DOWN;
        //    //}
        //}
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.transform.tag == "box")
        {
            Debug.Log("idle");
            ps = PlayerState.IDLE;

            rg2d.velocity = Vector2.zero;
        }
    }

    // 是否在jump中
    bool IsJump()
    {
        return ps == PlayerState.JUMP_UP || ps == PlayerState.JUMP_DOWN;
    }
}
