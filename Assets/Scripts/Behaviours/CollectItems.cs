using UnityEngine;

namespace Behaviours
{
    public class CollectItems : MonoBehaviour
    {
        #region methods

        // Use this for initialization
        private void Start()
        {
            Collected = 0;
        }

        // Update is called once per frame
        private void Update()
        {
        }

        private void OnCollisionEnter(Collision coll)
        {
            var item = coll.gameObject.GetComponent<Item>() ?? coll.gameObject.GetComponentInChildren<Item>() ?? coll.gameObject.GetComponentInParent<Item>();
            if (item == null)
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