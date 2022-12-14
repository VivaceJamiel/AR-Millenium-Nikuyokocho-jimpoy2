using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ChicagoRotate : MonoBehaviour
{
    public GameObject cube;

    [SerializeField]
    private float zRotate;

    private bool upsideDown;
    private bool lightToggle;

    public Light lightOne;
    public Light lightTwo;
    public Light lightThree;
    public Light lightFour;
    public Light lightFive;
    public Light lightSix;
    public Light spotLight;

    // Start is called before the first frame update
    void Start()
    {
        upsideDown = false;
        lightToggle = false;
    }

    // Update is called once per frame
    void Update()
    {
        zRotate = cube.transform.localRotation.eulerAngles.z;
        if (zRotate > 170 && zRotate < 190 && !upsideDown && !lightToggle)
        {
            Debug.Log("UPSIDE DOWN TRIGGERED, SWITCHING LIGHT");
            switchLight();
            upsideDown = true;
            lightToggle = true;
        }
        else if (zRotate < 170 || zRotate > 190 && upsideDown)
        {
            upsideDown = false;
        }
        else if (zRotate > 170 && zRotate < 190 && lightToggle && !upsideDown)
        {
            Debug.Log("UPSIDE DOWN TRIGGERED, SWITCHING OFF LIGHT");
            switchLight();
            lightToggle = false;
            upsideDown = true;
        }
    }

    void switchLight()
    {
        lightOne.enabled = !lightOne.enabled;
        lightTwo.enabled = !lightTwo.enabled;
        lightThree.enabled = !lightThree.enabled;
        lightFour.enabled = !lightFour.enabled;
        lightFive.enabled = !lightFive.enabled;
        lightSix.enabled = !lightSix.enabled;

        spotLight.enabled = !spotLight.enabled;
    }
}
