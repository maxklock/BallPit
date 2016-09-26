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
            _sortItems = new SortItems[0];
        }

        // Update is called once per frame
        private void Update()
        {
            if (HasWinner)
            {
                return;
            }

            if (_sortItems.Length == 0)
            {
                _sortItems = FindObjectsOfType<SortItems>();
                if (_sortItems.Length > 0)
                {
                    _sortItems = _sortItems.Where(c => c.isActiveAndEnabled).ToArray();
                }
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