using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VIDEO_FINAL : MonoBehaviour
{
    public VideoPlayer videofinal;
    // Start is called before the first frame update
    void Awake()
    {
        videofinal = GetComponent<VideoPlayer>();
        videofinal.Play();
        videofinal.loopPointReached += cuandoTermineVideo2;
    }

    // Update is called once per frame
    void cuandoTermineVideo2(VideoPlayer player)
    {
        player.Stop();
        SceneManager.LoadScene("MENU");
    }
}