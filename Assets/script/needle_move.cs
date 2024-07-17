using UnityEngine;


public class needle : MonoBehaviour
{
    public float speed = 20.0f;
    private float rotationAmount = 0.0f;
    private bool gearshift = true;
    public int gear = 1;
    public bool isright;
    public bool isleft;
    public bool isjump;
    public countdownscript pause;

    private void Start()
    {
        pause = GameObject.FindGameObjectWithTag("pause").GetComponent<countdownscript>();
    }
    // Update is called once per frame
    void Update()
    {
        if (!pause.ispaused)
        {
            if (gearshift)
            {
                if ((Input.GetKeyDown(KeyCode.Space) || isjump))
                {
                    if (rotationAmount < -180 && rotationAmount > -200 && gear < 6)
                    {
                        gearshift = false;
                        gear += 1;
                        speed -= 3f;
                        isjump = false;

                    }
                    else if (gear > 1)
                    {
                        gearshift = false;
                        gear -= 1;
                        speed += 3f;
                        isjump = false;

                    }
                }

                // Check for left and right arrow key inputs
                else if ((Input.GetKey(KeyCode.LeftArrow) || isleft) && rotationAmount < 0)
                {
                    float rotation = Time.deltaTime * speed;
                    transform.Rotate(0, 0, rotation, Space.Self);
                    rotationAmount += rotation;
                }
                else if ((Input.GetKey(KeyCode.RightArrow) || isright) && rotationAmount > -284)
                {
                    float rotation = -Time.deltaTime * speed * 3;
                    transform.Rotate(0, 0, rotation, Space.Self);
                    rotationAmount += rotation;
                }

                else if (rotationAmount < 0 && rotationAmount > -290)
                {
                    float rotation = Time.deltaTime * speed * 2;
                    transform.Rotate(0, 0, rotation, Space.Self);
                    rotationAmount += rotation;
                }

            }

            else
            {
                gearchange();
            }
            // Print the rotation amount
        }
       
    }


    void gearchange()
    {
        float rotation = Time.deltaTime * speed * 100;
        transform.Rotate(0, 0, rotation, Space.Self);
        rotationAmount += rotation;

        if (rotationAmount > -50)
        {
            gearshift = true;
        }
    }

    public void leftbutton()
    {
        isleft = true;
        isright = false;
    }

    public void rightbutton()
    {
        isleft = false;
        isright = true;
    }


    public void jumpbutton()
    {
        isjump = true;
    }

    public void jumpupbutton()
    {
        isjump = false;
    }



    public void upbutton()
    {
        isleft = false;
        isright = false;
    }
}
