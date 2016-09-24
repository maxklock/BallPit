using UnityEngine;

public enum PlayerId
{
    One = 1,
    Two = 2,
    Three = 3,
    Four = 4
}

public class Controller : MonoBehaviour
{
    #region member vars

    public float Energie = 10;
    public int MaxEnergie = 10;
    public float Speed = 2;

    public PlayerId Id;

    #endregion

    #region methods

    // Use this for initialization
    private void Start()
    {
        Collected = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        var move = new Vector3(Input.GetAxis("Horizontal " + (int)Id) * Time.deltaTime, 0, Input.GetAxis("Vertical " + (int)Id) * Time.deltaTime);

        move *= Speed;
        if (Input.GetAxis("Speed " + (int)Id) > 0)
        {
            Energie -= Time.deltaTime * 3;
            if (Energie < 0)
            {
                Energie = 0;
            }
            else
            {
                move *= Speed;
            }
        }

        if (Energie < MaxEnergie)
        {
            Energie += Time.deltaTime;
        }
        else if (Energie > MaxEnergie)
        {
            Energie = MaxEnergie;
        }

        transform.Translate(move);
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