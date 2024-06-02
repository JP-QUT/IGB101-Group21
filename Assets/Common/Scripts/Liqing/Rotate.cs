using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public enum RotationAxis { X, Y, Z } // 枚举类型定义轴

    public RotationAxis rotationAxis; // 选定的轴
    public float speed = 5f; // 自转速度

    private void Update()
    {
        // 根据选定的轴进行自转
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
