using UnityEngine;

public static class Utils
{
    #region methods

    public static Vector3 RandomBoundsPosition(Bounds bounds)
    {
        var x = Random.Range(-bounds.extents.x, bounds.extents.x);
        var y = Random.Range(-bounds.extents.y, bounds.extents.y);
        var z = Random.Range(-bounds.extents.z, bounds.extents.z);

        return bounds.center + new Vector3(x, y, z);
    }

    #endregion
}