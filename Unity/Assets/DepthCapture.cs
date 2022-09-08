using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthCapture : MonoBehaviour
{

    public GameObject CameraManager;
    public GameObject camera;
    private Camera sourceCamera;
    public Camera depthCam;
    public List<Camera> sourceCameras;
    public Camera[] depthCams;
    
    // YuanChun add
    public int captureFrame = 5;
    public int frameIdx = 0;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        Camera[] tmpList = CameraManager.GetComponentsInChildren<Camera>();
        foreach(Camera child in tmpList){
            if(child.tag == "MainCamera"){
                sourceCameras.Add(child);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // print(sourceCameras.Count);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Time.timeScale = 0;
            for(int i = 0; i < sourceCameras.Count; i++){
                Capture(i, frameIdx);
            }
            frameIdx++;
            Time.timeScale = 1;
        }   
    }
    
    public void Capture(int cameraNum, int frameNum)
    {
        int captureWidth = 1080;
        int captureHeight = 720;
        string sourceCameraName = sourceCameras[cameraNum].name;
        print(sourceCameraName);
        sourceCameras[cameraNum].GetComponent<ImageSynthesis>().OnCameraChange();

        // image capture
        // RenderTexture rt = new RenderTexture(Screen.width, Screen.height, 16);
        RenderTexture rt = new RenderTexture(captureWidth, captureHeight, 16);
        sourceCameras[cameraNum].targetTexture = rt;
        sourceCameras[cameraNum].Render();

        RenderTexture.active = rt;
        Texture2D tex = new Texture2D(rt.width, rt.height);
        print(tex);
        tex.ReadPixels(new Rect(0, 0, tex.width, tex.height), 0, 0);
        RenderTexture.active = null;

        // save to png
        byte[] bytes = tex.EncodeToPNG();
        string path = Application.dataPath + "/../output/image_v" + cameraNum + '_' + frameNum + ".png";
        System.IO.File.WriteAllBytes(path, bytes);

        // // save to yuv
        // bytes = tex.YUV2();
        // path = Application.dataPath + "/../output/image_v" + cameraNum + '_' + frameNum + ".yuv";
        // System.IO.File.WriteAllBytes(path, bytes);

        // depth capture
        // rt = new RenderTexture(Screen.width, Screen.height, 16);
         rt = new RenderTexture(captureWidth, captureHeight, 16);
        depthCam.targetTexture = rt;
        depthCam.Render();

        RenderTexture.active = rt;
        tex = new Texture2D(rt.width, rt.height);
        tex.ReadPixels(new Rect(0, 0, tex.width, tex.height), 0, 0);
        RenderTexture.active = null;

        bytes = tex.EncodeToPNG();
        path = Application.dataPath + "/../output/depth_v" + cameraNum + '_' + frameNum + ".png";
        System.IO.File.WriteAllBytes(path, bytes);

        print("Export image and depth successfully");

    }

    // public void Capture(int frameNum)
    // {
    //     sourceCamera.GetComponent<ImageSynthesis>().OnCameraChange();

    //     // image capture
    //     RenderTexture rt = new RenderTexture(Screen.width, Screen.height, 16);
    //     sourceCamera.targetTexture = rt;
    //     sourceCamera.Render();

    //     RenderTexture.active = rt;
    //     Texture2D tex = new Texture2D(rt.width, rt.height);
    //     tex.ReadPixels(new Rect(0, 0, tex.width, tex.height), 0, 0);
    //     RenderTexture.active = null;

    //     byte[] bytes = tex.EncodeToPNG();
    //     string path = Application.dataPath + "/../output/image_" + frameNum + ".png";
    //     System.IO.File.WriteAllBytes(path, bytes);

    //     // depth capture
    //     rt = new RenderTexture(Screen.width, Screen.height, 16);
    //     depthCam.targetTexture = rt;
    //     depthCam.Render();

    //     RenderTexture.active = rt;
    //     tex = new Texture2D(rt.width, rt.height);
    //     tex.ReadPixels(new Rect(0, 0, tex.width, tex.height), 0, 0);
    //     RenderTexture.active = null;

    //     bytes = tex.EncodeToPNG();
    //     path = Application.dataPath + "/../output/depth_" + frameNum + ".png";
    //     System.IO.File.WriteAllBytes(path, bytes);

    //     print("Export image and depth successfully");

    // }
}
