using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapLoaderScript : MonoBehaviour
{
    // Start is called before the first frame update


    public void LoadMapa1()
    {
        GameState.reset();
        SceneManager.LoadScene("Mapa1");
    }
}
