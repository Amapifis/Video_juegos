using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AppControl : MonoBehaviour
{
    public Button resetButton;
    public Button quitButton;

    void Start()
    {
        // Asignar los m�todos a los botones
        if (resetButton != null)
        {
            resetButton.onClick.AddListener(ResetApp);
        }

        if (quitButton != null)
        {
            quitButton.onClick.AddListener(QuitApp);
        }
    }

    // M�todo para reiniciar la aplicaci�n
    void ResetApp()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // M�todo para salir de la aplicaci�n
    void QuitApp()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
