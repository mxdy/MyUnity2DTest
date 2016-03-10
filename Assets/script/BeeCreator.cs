using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BeeCreator : MonoBehaviour {

    [SerializeField]
    float itime;
    float timeIdx;

    [SerializeField]
    float speed;

    [SerializeField]
    float beeCount;

    List<Transform> bees = new List<Transform>();
    GameObject bee;

    [SerializeField]
    float liveTime;

    [SerializeField]
    Transform player;

	// Use this for initialization
	void Start () {
        bee = Resources.Load<GameObject>("bee");
	}
	
	// Update is called once per frame
	void Update () {
        timeIdx += Time.deltaTime;

        if (timeIdx > itime)
        {
            timeIdx = 0;

            CreatBee();
        }

        if (bees.Count > 0)
        {
            BeeMoving();
        }
	}

    void CreatBee()
    {
        for (int i = 0; i < beeCount; i++)
        {
            Transform be = Instantiate<GameObject>(bee).transform;
            be.transform.SetParent(transform);

            float rand_num = Random.Range(0, 1.5f);
            be.transform.localPosition = new Vector2(rand_num,rand_num);

            bees.Add(be);
        }
    }

    void BeeMoving()
    {
        for (int i = 0; i < bees.Count; i++)
        {
            if (Vector2.Distance(bees[i].position, player.position) > 0)
            {
                Vector2 dir = player.position - bees[i].position;
                dir.Normalize();

                bees[i].Translate(dir * Time.deltaTime * speed);
            }
        }
        
    }
}
