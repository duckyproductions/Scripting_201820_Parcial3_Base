using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text timerText;
 
    GameController gC;
    // Use this for initialization
    private void Start()
    {
        if (timerText == null)
        {
            enabled = false;
        }

        gC = GetComponent<GameController>();
       

    }

    // Update is called once per frame
    private void Update()
    {
        //TODO: Set text from GameController
        timerText.text = gC.CurrentGameTime.ToString("F2");
    }
}