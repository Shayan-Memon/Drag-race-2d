using UnityEngine;
using TMPro; // Add this namespace

public class Gear : MonoBehaviour
{
    public needle need;
    private TextMeshPro score;

    // Start is called before the first frame update
    void Start()
    {
        // Try to get the TextMeshProUGUI component attached to the same GameObject
        score = GetComponent<TextMeshPro>();
        need = GameObject.FindGameObjectWithTag("needle").GetComponent<needle>();

        // Check if the TextMeshProUGUI component is found
        if (score == null)
        {
            Debug.LogError("TextMeshProUGUI component not found on the GameObject.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (score != null)
        {
            score.text = need.gear.ToString();
        }
    }
}
