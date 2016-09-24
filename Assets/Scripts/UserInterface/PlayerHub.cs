namespace UserInterface
{
    using Behaviours;

    using UnityEngine;
    using UnityEngine.UI;

    public class PlayerHub : MonoBehaviour
    {
        #region member vars

        public Controller Player;
        public Text Text;
        public Slider Slider;

        private CollectItems _collect;

        #endregion

        #region methods

        // Use this for initialization
        private void Start()
        {
            _collect = Player.GetComponent<CollectItems>();
        }

        // Update is called once per frame
        private void Update()
        {
            if (_collect != null && _collect.enabled)
            {
                Text.text = _collect.Collected.ToString();
            }

            Slider.maxValue = Player.MaxEnergie;
            Slider.value = Player.Energie;
        }

        #endregion
    }
}