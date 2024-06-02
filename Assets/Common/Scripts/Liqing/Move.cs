using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Vector3 startPoint; // ��ʼλ��
    public Vector3 endPoint; // ����λ��
    public float speed = 5f; // �ƶ��ٶ�

    private float distance; // ��ʼλ�õ�����λ�õľ���
    private float t; // ��ֵ����

    private void Start()
    {
        distance = Vector3.Distance(startPoint, endPoint);
    }

    private void Update()
    {
        t += Time.deltaTime * speed / distance;

        // ʹ�ò�ֵ��������ʼλ�úͽ���λ��֮����в�ֵ
        transform.position = Vector3.Lerp(startPoint, endPoint, Mathf.PingPong(t, 1f));
    }
}
