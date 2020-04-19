using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class startCamera : MonoBehaviour
{
    public GameObject MouseFlightRig;
    public Image crosshair;
    public GameObject StartScreenCamera;
    // Start is called before the first frame update
    void Start()
    {
        MouseFlightRig.SetActive(false);
        crosshair.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKey)
        {
            MouseFlightRig.SetActive(true);
            StartScreenCamera.SetActive(false);
            crosshair.enabled = true;
        }
    }
}
