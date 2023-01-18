using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;

public class SceneManaging : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }


    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Lava")
        {
            Invoke("ReloadScene", 0.5f);
           
        }
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.tag == "Finish")
        {
            SceneManager.LoadScene(1);
        }
        if (collider2D.tag == "Start Line")
        {
            SceneManager.LoadScene(0);
        }
        if (collider2D.tag == "End Line")
        {
            SceneManager.LoadScene(0);
        }

        
    }
    
  

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void FinishScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OnClickPlay()
    {
        SceneManager.LoadScene(1);
    }

    public void OnClickTutorial()
    {
        SceneManager.LoadScene(2);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LevelOne()
    {
        SceneManager.LoadScene(3);
    }
    public void LevelTwo()
    {
        SceneManager.LoadScene(4);
    }
    public void LevelThree()
    {
        SceneManager.LoadScene(5);
    }
    public void LevelFour()
    {
        SceneManager.LoadScene(6);
    }
    public void LevelFive()
    {
        SceneManager.LoadScene(7);
    }
    public void LevelSix()
    {
        SceneManager.LoadScene(8);
    }
    public void LevelSeven()
    {
        SceneManager.LoadScene(9);
    }
    public void LevelEight()
    {
        SceneManager.LoadScene(10);
    }
    public void LevelNine()
    {
        SceneManager.LoadScene(11);
    }
}

