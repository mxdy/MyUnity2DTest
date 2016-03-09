using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Aciculas : MonoBehaviour {

    [SerializeField]
    List<SpriteRenderer> aciculaList = new List<SpriteRenderer>();

    [SerializeField]
    float iTime; // 间隔时间
    float itime;

    [SerializeField]
    float runTime; // 运动时间（总）
    float runTimeEach;

    [SerializeField]
    float length; // 长到多长

    int idx = 0; // 当前位置

    float velocity_a = 1;

    bool direction = true;

    // Use this for initialization
    void Start ()
    {
        iTime = 2f;
        runTime = 2f;
        length = 10f;

        runTimeEach = runTime / aciculaList.Count;
        itime = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (idx >= aciculaList.Count)
        {
            idx = 0;
            itime = iTime;
        }

        if (itime > 0)
        {
            itime -= Time.deltaTime;
        }
        else
        {
            float each_second_change = (length / (runTimeEach / 2)) * velocity_a;

            if (idx < aciculaList.Count - 1)
            {
                ChangeLength(aciculaList[idx].transform, each_second_change, true);

                if (idx > 0 && aciculaList[idx - 1].transform.localScale.y > 0)
                {
                    ChangeLength(aciculaList[idx - 1].transform, each_second_change, false);
                }

                if (aciculaList[idx].transform.localScale.y >= length)
                {
                    ResetLastLength();

                    idx++;
                }
            }
            else
            {
                if (aciculaList[idx].transform.localScale.y >= length)
                {
                    ResetLastLength();

                    ChangeLength(aciculaList[idx].transform, each_second_change, false);

                    if (aciculaList[idx].transform.localScale.y <= 0)
                    {
                        idx++;
                    }
                }
                else
                {
                    ChangeLength(aciculaList[idx].transform, each_second_change, true);
                    ChangeLength(aciculaList[idx - 1].transform, each_second_change, false);
                }
            }

        }
	}

    void ChangeLength(Transform tran, float speed, bool dir)
    {
        // 向下
        if (dir)
        {
            tran.localScale += new Vector3(0, speed * Time.deltaTime, 0);
        }
        else
        {
            tran.localScale -= new Vector3(0, speed * Time.deltaTime, 0);
        }
    }

    void ResetLastLength()
    {
        if (idx > 0)
        {
            Transform last_tran = aciculaList[idx - 1].transform;
            float x = last_tran.localScale.x;

            if (x > 0)
            {
                last_tran.localScale = new Vector3(last_tran.localScale.x, 0, 1);
            }
        }
    }
}
