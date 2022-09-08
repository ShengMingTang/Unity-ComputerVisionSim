using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// using DepthCapture;

public class CameraManager : MonoBehaviour
{

    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public Transform cameraPrefab;
    public int numOfCameras = 2;
    public string LoadData;
    
    protected FileInfo theSourceFile = null;
    protected StreamReader reader = null;
    protected string text = " ";
    

    // This script will simply instantiate the Prefab when the game starts.
    private void Start()
    {
        // theSourceFile = new FileInfo ("./Assets/Data/test.csv");
        // reader = theSourceFile.OpenText();
        // text = reader.ReadLine(); // skip the first line
        // print (text);

        for(int i = 0; i < numOfCameras; i++){
            Transform camera = Instantiate(cameraPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            camera.transform.parent = transform;
            // camera initial potition and orientation
            camera.localPosition = new Vector3(3*(i), 0.0f, -10.0f);
            camera.localRotation = Quaternion.Euler(0.0f,0.0f,0.0f);
            camera.name = "sv" + i;
        }
    }

    private void Update()
    {
        // if(text != null){
        //     text = reader.ReadLine();
        //     print (text);
        // }
    }
}
