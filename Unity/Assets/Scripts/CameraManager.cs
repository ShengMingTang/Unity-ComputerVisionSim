using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// using DepthCapture;

public class CameraManager : MonoBehaviour
{

    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public Transform cameraPrefab;

    // This script will simply instantiate the Prefab when the game starts.
    private void Start()
    {
        int numOfCameras = 1;
        for(int i = 0; i < numOfCameras; i++){
            Transform camera = Instantiate(cameraPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            camera.transform.parent = transform;
            camera.localPosition = new Vector3(3*(i), 0.0f, -10.0f);
            camera.localRotation = Quaternion.Euler(0.0f,0.0f,0.0f);
            camera.name = "sv" + i;
        }
    }

    private void Update()
    {
        
    }

    // private StreamReader readCsv(string csvfilePath)
    // {
    //     if (path == null)
    //         return null;
    //     if (!File.Exists(path))
    //         File.CreateText(path);
    //     return new StreamReader(path);
    // }

    // public List<string[]> ReadCsv(string path)
    // {
    //     List<string[]> list = new List<string[]>();
    //     string line;
    //     StreamReader stream = Read(path);
    //     while ((line = stream.ReadLine()) != null)
    //     {
    //         list.Add(line.Split(','));
    //     }
    //     stream.Close();
    //     stream.Dispose();
    //     return list;
    // }

}
