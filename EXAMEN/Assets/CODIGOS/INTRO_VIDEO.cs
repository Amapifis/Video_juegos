using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class INTRO_VIDEO : MonoBehaviour
{
    public VideoPlayer videoIntro;
    // Start is called before the first frame update
    void Awake()
    {
        videoIntro = GetComponent<VideoPlayer>();
        videoIntro.Play();
        videoIntro.loopPointReached += cuandoTermineVideo;
    }

    // Update is called once per frame
    void cuandoTermineVideo(VideoPlayer player)
    {
        player.Stop();
        SceneManager.LoadScene("NIVEL_UNO");
    }
}
