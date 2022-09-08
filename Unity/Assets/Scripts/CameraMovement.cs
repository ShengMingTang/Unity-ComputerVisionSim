using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraMovement : MonoBehaviour
{
    public string transformName = null;
    protected FileInfo theSourceFile = null;
    protected StreamReader reader = null;
    protected string text = " ";
    protected bool moveable = true;

    // Start is called before the first frame update
    void Start()
    {
        transformName = transform.name;
        theSourceFile = new FileInfo ($"./Assets/Data/{transformName}.csv");
        reader = theSourceFile.OpenText();
        text = reader.ReadLine(); // skip the first line
        // print(text);
    }

    // Update is called once per frame
    void Update()
    {
        // if(moveable){
        //     ReadAndMove();
        // }
    }

    public void ReadAndMove(){
        if(text != null){
            text = reader.ReadLine();
            if(text == null){
                moveable = false;
                print($"{transformName} finish moving");
            }
            else{
                text = text.Replace(" ", "");
                string[] subs = text.Split(",");
                MoveCamera(float.Parse(subs[1]),float.Parse(subs[2]),float.Parse(subs[3]),float.Parse(subs[4]),float.Parse(subs[5]),float.Parse(subs[6]));
            }
        }
        else{
            print($"{transformName} end");
        }
        return;
    }

    void MoveCamera(float x, float y, float z, float yaw, float pitch, float roll){
        print($"{transformName} move to {x},{y},{z},{yaw},{pitch},{roll}");
        transform.localPosition = new Vector3(x, y, z);
        transform.localRotation = Quaternion.Euler(yaw, pitch, roll);
        return;
    }

}
