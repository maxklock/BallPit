using UnityEngine;

namespace UserInterface
{
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
        }

        #endregion
    }
}