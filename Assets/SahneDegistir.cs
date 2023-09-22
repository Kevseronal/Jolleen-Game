using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SahneDegistir : MonoBehaviour
{
    public AudioSource tiklama;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            int hangiSahne = SceneManager.GetActiveScene().buildIndex;
            if(hangiSahne == 0)
            {
                tiklama.Play();
                SceneManager.LoadScene(1);
            }
            
            else if(hangiSahne == 2)
            {
                tiklama.Play();
                SceneManager.LoadScene(1);
            }
            else if (hangiSahne == 3)
            {
                tiklama.Play();
                SceneManager.LoadScene(1);
            }
        }
        
    }
}
