using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public enum RotationAxis { X, Y, Z } // ö�����Ͷ�����

    public RotationAxis rotationAxis; // ѡ������
    public float speed = 5f; // ��ת�ٶ�

    private void Update()
    {
        // ����ѡ�����������ת
        switch (rotationAxis)
        {
            case RotationAxis.X:
                transform.Rotate(Vector3.right, speed * Time.deltaTime);
                break;
            case RotationAxis.Y:
                transform.Rotate(Vector3.up, speed * Time.deltaTime);
                break;
            case RotationAxis.Z:
                transform.Rotate(Vector3.forward, speed * Time.deltaTime);
                break;
        }
    }
}
