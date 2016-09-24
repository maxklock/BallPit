namespace Behaviours
{
    using System.Linq;

    using Objects;

    using UnityEngine;

    public class SortItems : MonoBehaviour
    {
        #region methods

        public SortColor Color;

        // Use this for initialization
        private void Start()
        {
        }

        // Update is called once per frame
        private void Update()
        {
        }

        private void OnCollisionEnter(Collision coll)
        {
            var item = coll.gameObject.GetComponent<SortBall>() ?? coll.gameObject.GetComponentInChildren<SortBall>() ?? coll.gameObject.GetComponentInParent<SortBall>();
            if (item == null || item.Color != Color)
            {
                return;
            }

            Destroy(item.gameObject);
            Collected++;
        }

        #endregion

        #region properties

        public int Collected { get; set; }

        #endregion
    }
}