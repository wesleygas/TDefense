using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapLoaderScript : MonoBehaviour
{
    // Start is called before the first frame update


    public void LoadMap(int map)
    {
        GameState.reset();
        Maps.currentMap = map;
        SceneManager.LoadScene("Mapa"+(map+1).ToString());
    }
}
