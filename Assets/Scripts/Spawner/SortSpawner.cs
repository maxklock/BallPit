namespace Spawner
{
    using Objects;

    using UnityEngine;

    public class SortSpawner : MonoBehaviour
    {
        #region member vars

        private Collider _collider;
        public SortBall[] Balls;

        public int MaxSortBalls = 100;
        public int MinBallCount = 500;

        private int _count = 0;

        #endregion

        #region methods

        public void Spawn(int index)
        {
            var pos = Utils.RandomBoundsPosition(_collider.bounds);
            var obj = Instantiate(Balls[index]);
            obj.transform.position = pos;
            obj.transform.parent = transform;
        }

        // Use this for initialization
        private void Start()
        {
            _collider = GetComponent<Collider>();
        }

        // Update is called once per frame
        private void Update()
        {
            if (BallSpawner.BallCount > MinBallCount)
            {
                for (var k = 0; k < Balls.Length && _count < MaxSortBalls; k++)
                {
                    Spawn(k);
                    _count++;
                }
            }
        }

        #endregion
    }
}