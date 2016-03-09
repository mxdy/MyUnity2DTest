/*
 * 跟踪小蜜蜂
 * mxdy
 */
using UnityEngine;
using System.Collections;

public class AIFollowBee : MonoBehaviour {
    // 初始等待时间
    public float initDelayCd = 1;

    // 移动速度
    public float v = 1;

    // 生命周期
    public float liveCd = 10;

    //GameManager gameManager;

    float distance;
	// Use this for initialization
	void Start () {
        //gameManager = GameObject.Find("GameManagers").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
       

        if (initDelayCd > 0)
        {
            initDelayCd -= Time.deltaTime;
        }
        else
        {
            // 迭代生命周期
            //if (liveCd > 0)
            //{
            //    liveCd -= Time.deltaTime;
            //}
            //else
            //{
            //    DestroyImmediate(gameObject);
            //    return;
            //}

            // 向玩家移动
            //Debug.Log(gameManager.Player.transform.position);

            //// 玩家的平面坐标
            //float player_x = gameManager.Player.transform.position.x;
            //float player_y = gameManager.Player.transform.position.y;

            // bee的平面坐标
            float bee_x = gameObject.transform.position.x;
            float bee_y = gameObject.transform.position.y;

            // 参考点：在玩家 、、
            //gameObject.transform.Translate(new Vector3(player_x - bee_x, player_y - bee_y, 0) * Time.deltaTime * v);
        }
	}
}
