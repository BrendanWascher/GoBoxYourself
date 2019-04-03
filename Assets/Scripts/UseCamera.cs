using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class UseCamera : MonoBehaviour
{
    [SerializeField]
    private Material picture;

    private WebCamTexture webCamTexture;
    private Texture materialTexture;
    private Texture2D pictureTexture;
    private bool canTakePicture;

    void Start()
    {
        webCamTexture = new WebCamTexture();
        //materialTexture = GetComponent<Renderer>().material.mainTexture;
        ResetPicture();
    }

    public void ResetPicture()
    {
        //webCamTexture = new WebCamTexture();
        //materialTexture = picture.mainTexture;
        picture.mainTexture = webCamTexture;
        //pictureTexture = (Texture2D)materialTexture;
        //FlipPicture(pictureTexture);
        webCamTexture.Play();
    }

    public void TakeNewPicture()
    {
        canTakePicture = false;
        StartCoroutine("StartTakePicture");
    }

    /*
    private void FlipPicture(Texture2D picTexture)
    {
        int pictureWidth = picTexture.width;
        int pictureHeight = picTexture.height;
        Texture2D flippedPicture =
            new Texture2D(pictureWidth, pictureHeight);
        for(int widthCount = 0; widthCount < pictureWidth; widthCount++)
        {
            for(int heightCount = 0; heightCount < pictureHeight; heightCount++)
            {
                flippedPicture.SetPixel(pictureWidth - widthCount - 1, heightCount,
                    picTexture.GetPixel(widthCount, heightCount));
            }
        }
        flippedPicture.Apply();
        picture.mainTexture = flippedPicture;
    }
    */

    private IEnumerator StartTakePicture()
    {
        yield return new WaitForEndOfFrame();
        Texture2D thisPicture = new Texture2D(webCamTexture.width, webCamTexture.height);
        thisPicture.SetPixels(webCamTexture.GetPixels());
        thisPicture.Apply();
        picture.mainTexture = thisPicture;
        canTakePicture = true;
    }
}
