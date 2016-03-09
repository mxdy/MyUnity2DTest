using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AIHideSprite : MonoBehaviour
{
    // 初始状态
    public enum CurState { hide, display };
    public CurState curState = CurState.display;
    // 等待CD
    public float initDelayCDTime = 1;
    // 隐藏CD
    public float hideCdTime = 1;
    // 显示CD
    public float displayCdTime = 1;

    // 消失时间
    public float hideUseTime = 1;

    // 保存初始颜色
    List<Color> colorList = new List<Color>();

    // childs
    List<GameObject> childsList = new List<GameObject>();

    // 计时器
    float timeIdx = 0;

    // Use this for initialization
    void Start()
    {
        saveChilds();
        timeIdx = initDelayCDTime;
    }

    /// <summary>
    /// 获得子对象集
    /// </summary>
    void saveChilds()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            childsList.Add(gameObject.transform.GetChild(i).gameObject);
            colorList.Add(gameObject.transform.GetChild(i).GetComponent<SpriteRenderer>().color);
        }
    }

    /// <summary>
    /// 设置子对象集的隐藏
    /// </summary>
    /// <param name="tag"> false 为隐藏</param>
    bool setChildDisenable(float ofs)
    {
        bool isReady = false;
        for (int i = 0; i < childsList.Count; i++)
        {
            SpriteRenderer render = childsList[i].GetComponent<SpriteRenderer>();
            float a = render.color.a;
            a -= ofs;
            if (a < 0) a = 0;
            render.color = new Color(colorList[i].r, colorList[i].g, colorList[i].b, a);

            if (render.color.a == 0)
            {
                if (!isReady) isReady = true;
                childsList[i].GetComponent<SpriteRenderer>().enabled = false;
                childsList[i].GetComponent<BoxCollider2D>().enabled = false;
            }
        }

        return isReady;
    }

    /// <summary>
    /// 显示子对象集
    /// </summary>
    void setChildEnable()
    {
        for (int i = 0; i < childsList.Count; i++)
        {
            SpriteRenderer render = childsList[i].GetComponent<SpriteRenderer>();
            render.enabled = true;
            render.color = new Color(colorList[i].r, colorList[i].g, colorList[i].b, 1);
            childsList[i].GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // 显示状态
        if (curState == CurState.display)
        {
            if (timeIdx > 0)
            {
                timeIdx -= Time.deltaTime;
            }
            else
            {
                // 隐藏
                if (setChildDisenable(Time.deltaTime * (1 / hideUseTime)))
                {
                    timeIdx = hideCdTime;
                    curState = CurState.hide;
                }

            }
        }
        else
        {
            timeIdx -= Time.deltaTime;
            if (timeIdx <= 0)
            {
                // 显示
                setChildEnable();
                timeIdx = displayCdTime;
                curState = CurState.display;
            }
        }
    }
}
