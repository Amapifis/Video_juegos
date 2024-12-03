using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BOTONES_UI : MonoBehaviour
{
    // Start is called before the first frame update
    public void menuAintro()
    {
        SceneManager.LoadScene("INTRO");
    }
}
