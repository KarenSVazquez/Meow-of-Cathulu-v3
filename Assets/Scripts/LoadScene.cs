using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string scene;

    private void OnMouseDown()
    {
        Debug.Log("Intentando cargar escena: " + scene);
        if (scene == "VictoryScene")
        {
            // Agrega aquí cualquier lógica adicional que necesites antes de cargar la escena de victoria
            Debug.Log("Cargando escena de victoria...");

            // Llama a la función específica para cargar la escena de victoria
            Debug.Log("Cargando escena de victoria...");
            LoadVictoryScene();
        }
        else
        {
            // Si no es la escena de victoria, carga la escena normalmente
            SceneManager.LoadScene(scene);
        }
    }

    // Nueva función para cargar la escena de victoria
    public void LoadVictoryScene()
    {
        // Carga la escena de victoria
        UnityEngine.SceneManagement.SceneManager.LoadScene("VictoryScene");
    }
}
