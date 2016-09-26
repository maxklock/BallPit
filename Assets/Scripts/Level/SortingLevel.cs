namespace Level
{
    using System.Linq;
    using System.Xml.XPath;

    using Behaviours;

    using UnityEngine;

    public class SortingLevel : MonoBehaviour, ILevel
    {
        #region methods

        private SortItems[] _sortItems;

        public SortColor Winner { get; private set; }
        public bool HasWinner { get; private set; }
        public int Count = 10;

        // Use this for initialization
        private void Start()
        {
            HasWinner = false;
            _sortItems = FindObjectsOfType<SortItems>().Where(c => c.isActiveAndEnabled).ToArray();
        }

        // Update is called once per frame
        private void Update()
        {
            if (HasWinner)
            {
                return;
            }
            foreach (var sorter in _sortItems)
            {
                if (sorter.Collected >= Count)
                {
                    Winner = sorter.Color;
                    HasWinner = true;
                }
            }
        }

        #endregion
    }
}