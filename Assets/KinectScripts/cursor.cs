﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class cursor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CursorLocked()
    {
       
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }
}
