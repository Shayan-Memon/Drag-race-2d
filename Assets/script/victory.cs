using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;




public class victory : MonoBehaviour
{
    public CarMove lamb;
    public pagani_move pagani;
    private TextMeshPro victorytext;
    public bool win_or_lose = true;
    private Finish finishline;


    // Start is called before the first frame update
    void Start()
    {
        lamb = GameObject.FindGameObjectWithTag("Player").GetComponent<CarMove>();
        pagani = GameObject.FindGameObjectWithTag("pagani").GetComponent<pagani_move>();
        finishline = GameObject.FindGameObjectWithTag("Finish").GetComponent<Finish>();
        victorytext = GetComponent<TextMeshPro>();

    }

    // Update is called once per frame
    void Update()
    {

        
        if (lamb.transform.position.x > finishline.targetPositionX+100 && lamb.transform.position.x > pagani.transform.position.x && win_or_lose)
        {
            win_or_lose = false;
            victorytext.text = "YOU WIN!";
            
        }

        else if (lamb.transform.position.x > finishline.targetPositionX+100 && lamb.transform.position.x < pagani.transform.position.x && win_or_lose)
        {
            win_or_lose = false;
            victorytext.text = "YOU LOSE!";
        }


    }
}
