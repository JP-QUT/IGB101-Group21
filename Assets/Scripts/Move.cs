using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Vector3 startPoint; // 起始位置
    public Vector3 endPoint; // 结束位置
    public float speed = 5f; // 移动速度

    private float distance; // 起始位置到结束位置的距离
    private float t; // 插值参数

    private void Start()
    {
        distance = Vector3.Distance(startPoint, endPoint);
    }

    private void Update()
    {
        t += Time.deltaTime * speed / distance;

        // 使用插值函数在起始位置和结束位置之间进行插值
        transform.position = Vector3.Lerp(startPoint, endPoint, Mathf.PingPong(t, 1f));
    }
}
