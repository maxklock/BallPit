using UnityEngine;
using System.Collections;
using System.Linq;

using Behaviours;

using Level;

public class CollectLevel : MonoBehaviour, ILevel
{
    #region methods

    private CollectItems[] _collectItems;

    public SortColor Winner { get; private set; }
    public bool HasWinner { get; private set; }
    public int Count = 10;

    // Use this for initialization
    private void Start()
    {
        HasWinner = false;
        _collectItems = new CollectItems[0];
    }

    // Update is called once per frame
    private void Update()
    {
        if (HasWinner)
        {
            return;
        }

        if (_collectItems.Length == 0)
        {
            _collectItems = FindObjectsOfType<CollectItems>();
            if (_collectItems.Length > 0)
            {
                _collectItems = _collectItems.Where(c => c.isActiveAndEnabled).ToArray();
            }
        }

        foreach (var sorter in _collectItems)
        {
            if (sorter.Collected >= Count)
            {
                Winner = sorter.GetComponent<Controller>().Color;
                HasWinner = true;
            }
        }
    }

    #endregion
}
