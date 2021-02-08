using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDevice : MonoBehaviour
{
    [SerializeField] Canvas myCanvas;
    // Start is called before the first frame update
    void Start()
    {
        CheckDeviceType();
    }

    private void CheckDeviceType()
    {
        //checking if device is mobile or not
        // if device is not mobile, I am deleting the canvas which includes left, right, jump buttons
        if (!SystemInfo.deviceType.Equals("Handheld"))
            Destroy(myCanvas);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
