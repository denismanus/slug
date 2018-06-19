﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{

    [SerializeField] private float speed = 2.0F;
    [SerializeField] private Transform target;

    private void Awake()
    {
        if (!target)
            target = FindObjectOfType<Character>().transform;
    }

    void Update()
    {
        Vector3 position = target.position;
        position.z = -10F;
        transform.position = Vector3.Lerp(transform.position, position, speed * Time.deltaTime);

    }
}
