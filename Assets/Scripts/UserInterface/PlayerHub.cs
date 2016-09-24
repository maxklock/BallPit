namespace UserInterface
{
    using System.Linq;

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
        private SortItems _sort;

        #endregion

        #region methods

        // Use this for initialization
        private void Start()
        {
            _collect = Player.GetComponent<CollectItems>();
            _sort = FindObjectsOfType<SortItems>().FirstOrDefault(p => p.Color == Player.Color);
        }

        // Update is called once per frame
        private void Update()
        {
            if (_collect != null && _collect.enabled)
            {
                Text.text = _collect.Collected.ToString();
            }

            if (_sort != null)
            {
                Text.text = _sort.Collected.ToString();
            }

            Slider.maxValue = Player.MaxEnergie;
            Slider.value = Player.Energie;
        }

        #endregion
    }
}