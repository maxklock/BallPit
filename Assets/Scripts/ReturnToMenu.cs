using UnityEngine;
using System.Collections;
using Spawner;
using UnityEngine.SceneManagement;

public class ReturnToMenu : MonoBehaviour {


	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.JoystickButton7))
        {
            BallSpawner.BallCount = 0;
            ItemSpawner.ItemCount = 0;
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
    }
}
