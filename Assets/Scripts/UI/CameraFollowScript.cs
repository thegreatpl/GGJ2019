﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    public static CameraFollowScript Camera; 

    public GameObject FollowObject; 

    // Start is called before the first frame update
    void Start()
    {
        Camera = this; 
    }

    // Update is called once per frame
    void Update()
    {
        if (FollowObject != null)
            transform.position = FollowObject.transform.position; 
    }
}
