using TMPro;
using UnityEngine;

public class countdownscript : MonoBehaviour
{
    public int countdowntime = 3;
    private TextMeshPro countdisplay;
    private float timer = 0f;
    private bool isCountingDown = true;
    public bool ispaused = true;

    void Start()
    {
        countdisplay = GetComponent<TextMeshPro>();
    }

    void Update()
    {


       


        if (isCountingDown)
        {
            timer += Time.deltaTime;
            if (timer > 1)
            {
                timer = 0;
                countdowntime--;
            }

            if (countdowntime > 0)
            {
                countdisplay.text = countdowntime.ToString();
            }
            else if (countdowntime == 0)
            {
                countdisplay.text = "GO!";
                isCountingDown = false;
                Invoke("ClearText", 1f); // Clear text after 1 second
            }
        }
    }

    void ClearText()
    {
        countdisplay.text = "";
        ispaused = false;
    }
}
