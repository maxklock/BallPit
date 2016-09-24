namespace UserInterface
{
    using UnityEngine;
    using UnityEngine.UI;

    public class PlayerHub : MonoBehaviour
    {
        #region member vars

        public Controller Player;
        public Text Text;
        public Slider Slider;

        #endregion

        #region methods

        // Use this for initialization
        private void Start()
        {
        }

        // Update is called once per frame
        private void Update()
        {
            Text.text = Player.FallDown.ToString();
            Slider.maxValue = Player.MaxEnergie;
            Slider.value = Player.Energie;
        }

        #endregion
    }
}