namespace UserInterface
{
    using Spawner;

    using UnityEngine;
    using UnityEngine.UI;

    public class Loading : MonoBehaviour
    {
        #region member vars

        private BallSpawner _spawner;

        public Slider Slider;

        public bool IsLoading { get; set; }

        #endregion

        #region methods

        // Use this for initialization
        private void Start()
        {
            IsLoading = true;
            _spawner = FindObjectOfType<BallSpawner>();
        }

        // Update is called once per frame
        private void Update()
        {
            Slider.maxValue = _spawner.MaxBalls;
            Slider.value = BallSpawner.BallCount;

            if (Slider.value >= Slider.maxValue)
            {
                IsLoading = false;
            }
        }

        #endregion
    }
}