using UnityEngine;

namespace Spawner
{
    using Objects;

    public class ItemSpawner : MonoBehaviour
    {
        #region member vars

        private Collider _collider;
        private float _timer;
        public Item Item;

        public bool TimeBasedSpawning = true;
        public int ItemsPerMinute = 10;

        public bool WaveBasedSpawning = false;
        public int ItemsPerWave = 25;


        #endregion

        #region constants

        public static int ItemCount;

        #endregion

        #region methods

        public void Spawn()
        {
            var pos = Utils.RandomBoundsPosition(_collider.bounds);
            var obj = Instantiate(Item);
            obj.transform.position = pos;
            obj.transform.parent = transform;

            ItemCount++;
        }

        // Use this for initialization
        private void Start()
        {
            _collider = GetComponent<Collider>();
            _timer = 0;
        }

        // Update is called once per frame
        private void Update()
        { 

            if (TimeBasedSpawning)
            {
                _timer -= Time.deltaTime;
                if (_timer <= 0)
                {
                    Spawn();
                    _timer = 60f / ItemsPerMinute;
                }

            }
        }

        public void SpawnWave()
        {
            if (WaveBasedSpawning)
            {
                for (int i = 0; i < ItemsPerWave; i++)
                {
                    Spawn();
                }
            }
            
        }

        #endregion
    }
}