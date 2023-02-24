using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Scene1Controller : MonoBehaviour
{
    public GameObject vpGo;
    public GameObject loginImageGo;

    void Start()
    {
        StartCoroutine(PlayVideo());
    }

    IEnumerator PlayVideo()
    {
        VideoPlayer vp = vpGo.GetComponent<VideoPlayer>();
        vp.Prepare();
        vp.loopPointReached += (source) =>
        {
            vpGo.SetActive(false);
            loginImageGo.SetActive(true);
        };
        while (!vp.isPrepared)
        {
            yield return new WaitForSeconds(0.5f);
        }
        vp.Play();
    }

    void Update()
    {
        
    }
}
