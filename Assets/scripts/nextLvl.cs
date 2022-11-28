using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class nextLvl : MonoBehaviour
{
    public int nextScene;
    // Start is called before the first frame update
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("stopPoint"))
        {
            SceneManager.LoadScene(nextScene);

            if(nextScene > PlayerPrefs.GetInt("LevelAt"))
            {
                PlayerPrefs.GetInt("levelAt", nextScene);
            }
        }
    }
    void Start()
    {
        nextScene = SceneManager.GetActiveScene().buildIndex + 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
