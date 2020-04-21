using System.Collections;
using System.Collections.Generic;
using OpenGlove_API_C_Sharp_HL;
using OpenGlove_API_C_Sharp_HL.OGServiceReference;
using System;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{


    public Transform theDest;
    static Glove guante;
    static List<Glove> gloves;
    public  OpenGloveAPI api = OpenGloveAPI.GetInstance();
    List<int> regions = new List<int>() { 0, 1, 2, 3, 25, 18 };
    List<int> intensity = new List<int>() { 255, 255, 255, 255, 255, 255 };
    List<int> intensityOff = new List<int>() { 0, 0, 0, 0, 0, 0 };
   
    public void OnMouseDown()
    {

        try
        {
            gloves = api.Devices;
            Debug.Log("dsadas");
            Debug.Log(gloves);
        }
        catch
        {
            Debug.Log("ERROR: El servicio no esta activo");
        }
        //List<int> regions = new List<int>() { 0, 1, 2, 3, 25, 18 };
        //List<int> intensity = new List<int>() { 255, 255, 255, 255, 255, 255 };
        Debug.Log("ssss");
        guante = gloves[0];
        api.Activate(guante, regions, intensity);
        GetComponent<Rigidbody>().useGravity = false;
        this.transform.position = theDest.position;
        this.transform.parent = GameObject.Find("Destination").transform;


    }
    
    public void OnMouseUp()
    {
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
        api.Activate(guante, regions, intensityOff);
    }
}
