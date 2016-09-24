using UnityEngine;

public class Controller : MonoBehaviour
{
    #region member vars

    public float Energie = 10;
    public int MaxEnergie = 10;
    public float Speed = 2;

    #endregion

    #region methods

    // Use this for initialization
    private void Start()
    {
        FallDown = 0;
        BallRemover.BallRemoved += (sender, args) =>
        {
            FallDown++;
        };
    }

    // Update is called once per frame
    private void Update()
    {
        var move = new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime, 0, Input.GetAxis("Vertical") * Time.deltaTime);

        move *= Speed;
        if (Input.GetAxis("Fire1") > 0)
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

    #endregion

    #region properties

    public int FallDown { get; set; }

    #endregion
}