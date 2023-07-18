using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuButtons : MonoBehaviour
{
    // Start is called before the first frame update
    public void yenidenBasla()
    {
        SceneManager.LoadScene("BetaScene");
    }
    public void astronutCanlandir()
    {
        SceneManager.LoadScene("BetaScene");
    }
    public void oyunaBasla()
    {
        SceneManager.LoadScene("BetaScene");
    }
}
