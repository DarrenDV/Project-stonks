using UnityEngine;

public class DobbelDraai : MonoBehaviour
{
    public string side;
    public bool set;
    public int location;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (set)
        {
            switch (location)
            {
                case 0:
                    transform.rotation = Quaternion.Euler(60, 270, 0);
                    break;
                case 1:
                    transform.rotation = Quaternion.Euler(60, 0, 0);
                    break;
                case -1:
                    transform.rotation = Quaternion.Euler(60, 180, 0);
                    break;
            }

            if (this.CompareTag("NumDice"))
            {
                switch (side)
                {
                    case "10":
                        transform.Rotate(270.0f, 180.0f, 0.0f, Space.Self);
                        break;
                    case "20":
                        transform.Rotate(90.0f, 180.0f, 0.0f, Space.Self);
                        break;
                }
                set = false;
            }

            if (this.CompareTag("MarketDice"))
            {
                switch (side)
                {
                    case "windmill":
                        transform.Rotate(270.0f, 180.0f, 0.0f, Space.Self);
                        break;
                    case "fish":
                        transform.Rotate(0.0f, 90.0f, 0.0f, Space.Self);
                        break;
                    case "flower":
                        transform.Rotate(180.0f, 180.0f, 0.0f, Space.Self);
                        break;
                    case "boat":
                        transform.Rotate(0.0f, 180.0f, 0.0f, Space.Self);
                        break;
                    case "wheel":
                        transform.Rotate(0.0f, 90.0f, 180.0f, Space.Self);
                        break;
                    case "stones":
                        transform.Rotate(90.0f, 180.0f, 0.0f, Space.Self);
                        break;
                }
                set = false;
            }
        }
    }
}
