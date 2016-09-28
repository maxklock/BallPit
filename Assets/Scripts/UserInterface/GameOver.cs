using UnityEngine;

namespace UserInterface
{
    using Spawner;

    using UnityEngine.SceneManagement;
    using UnityEngine.UI;

    public class GameOver : MonoBehaviour
    {
        #region methods

        public Text WinnerText;
        public SortColor Winner;

        // Use this for initialization
        private void Start()
        {
        }

        // Update is called once per frame
        private void Update()
        {
            WinnerText.text = Winner.ToString();
            WinnerText.color = Winner == SortColor.Blue ? Color.blue : Color.red;
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.JoystickButton7))
            {
                Restart();
            }
        }

        public void Restart()
        {
            BallSpawner.BallCount = 0;
            ItemSpawner.ItemCount = 0;
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }

        #endregion
    }
}