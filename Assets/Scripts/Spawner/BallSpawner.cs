using UnityEngine;

namespace Spawner
{
    using Objects;

    public class BallSpawner : MonoBehaviour
    {
        #region member vars

        private Collider _collider;
        public Ball Ball;
        public int BallsPerFrame = 2;

        public int MaxBalls = 1000;

        #endregion

        #region constants

        public static int BallCount;

        #endregion

        #region methods

        public void Spawn()
        {
            var pos = Utils.RandomBoundsPosition(_collider.bounds);
            var obj = Instantiate(Ball);
            obj.transform.position = pos;
            obj.transform.parent = transform;

            BallCount++;
        }

        // Use this for initialization
        private void Start()
        {
            _collider = GetComponent<Collider>();
        }

        // Update is called once per frame
        private void Update()
        {
            for (var i = 0; i < BallsPerFrame && BallCount < MaxBalls; i++)
            {
                Spawn();
            }
        }

        #endregion
    }
}