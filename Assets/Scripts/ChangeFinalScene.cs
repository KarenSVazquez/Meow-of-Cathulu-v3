using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeFinalScene : MonoBehaviour
{
    public string CutScene_Final;
    public string CutScene_Inicial;
    public SO_CatCounting catCounting;
    /* private bool finalSceneCompleted = false;*/


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (catCounting.CatNumber >= 8)
            {
                SwitchScene(CutScene_Final);
            }
           
        }
    }

    /*
      void Update()
      {
          Debug.Log("Update ");
          if (finalSceneCompleted && Input.GetKeyDown(KeyCode.J))
          {
              Debug.Log("if?? J.");
              SwitchScene(CutScene_Inicial);
          }
      }
      */

    void SwitchScene(string sceneName)
    {
        Debug.Log("Change scene: " + sceneName);

        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.Log("Nombre de la escena no especificado.");
        }
    }

    // escena final ha sido completada
    /*
       public void FinalSceneCompleted()
       {
           finalSceneCompleted = true;
       }
       */

}
