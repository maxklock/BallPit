namespace Level
{
    using System.Linq;
    using System.Xml.XPath;

    using Behaviours;

    using UnityEngine;

    public interface ILevel
    {
        bool HasWinner { get; }
        SortColor Winner { get; }
    }
}