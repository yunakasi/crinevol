using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatMotion : MonoBehaviour
{
    public float floatSpeed = 2f;
    public float floatAmount = 0.1f;

    Vector3 startLocalPos;

    public bool isFloating = true;

    void Start()
    {
        startLocalPos = transform.localPosition;
    }

    void Update()
    {
        if (!isFloating)
        {
            transform.localPosition = startLocalPos;
            return;
        }

        float y = Mathf.Sin(Time.time * floatSpeed) * floatAmount;
        transform.localPosition = startLocalPos + new Vector3(0, y, 0);
    }
}