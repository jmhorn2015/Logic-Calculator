using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour{
    public void BackToMain()
    {
        TextRender.assumptions = new Variable[3];
        TextRender.conclusion = null;
        SceneManager.LoadScene("Main Area");
    }
}
