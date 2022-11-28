using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuCtrl : MonoBehaviour
{
    public AudioSource buttonSound;

    public void buttonsound()
    {
        buttonSound.Play();
    }
    public void returnMenu()
    {
        SceneManager.LoadScene("menu");
    }
    public void trylostlevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void tragain()
    {
        SceneManager.LoadScene("level1");
    }
    public void quitButton()
    {
        Application.Quit();
    }

    public void loadFirstLvl()
    {
        SceneManager.LoadScene("level1");
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
