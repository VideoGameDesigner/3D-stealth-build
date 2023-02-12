using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public static float timecheck; // creating the variable for the time that has decimal places
    public static bool timeStarted = false; // making a variable that is always false
    public TextMeshProUGUI timeDisplay; // making the variable for timer text font
    public TextMeshProUGUI AllClear;
    public TextMeshProUGUI HackDisplay;
    public TextMeshProUGUI ComputerDisplay;
    public TextMeshProUGUI BonusDiscDisplay;
    public static int NumberofHacks;
    public static bool hacksleft = false;
    public static int ComputersLeft;
    public static int NumberofDiscs;
    public GameObject secretmessage;
    
    

    // Start is called before the first frame update
    void Start()
    {
        ComputersLeft = 4;
        hacksleft = true;
        NumberofHacks = 3;
        NumberofDiscs = 3;
        hacksleft = GetComponent<GameControl>();
        timeStarted = GetComponent<GameControl>();        
        TimeStart();
        secretmessage.SetActive(false);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        BonusDiscDisplay.text = "Bonus Discs found: " + (NumberofDiscs.ToString("D1"));

        if(NumberofDiscs == 0)

        {
            secretmessage.SetActive(true);
            
        }

        

        ComputerDisplay.text = "Computers Left: " + (ComputersLeft.ToString("D1"));
        if(ComputersLeft == 0)
        {
            SceneManager.LoadScene("Winner");

        }

        HackDisplay.text = "Hacks: " + (NumberofHacks.ToString("D2"));
        if(NumberofHacks <= 0 )
        {           
            NumberofHacks = 0;
            HackDisplay.text = "Hacks: " + (NumberofHacks.ToString("0"));
        }

        else if (NumberofHacks >= 0)
        {
            HackDisplay.text = "Hacks: " + (NumberofHacks.ToString("D2"));

        }
                    

        if(NumberofHacks == 0)

        {
            hacksleft = false;
        }

        if(NumberofHacks > 0)
        {
            hacksleft = true;

        }

        

        TimeLeft();
    }

    private void TimeLeft ()

    {
        if (timeStarted == true) // a condition that can only activate if the variable is equal to true not if the variable IS true
        {
            timecheck -= Time.deltaTime; // if the condition is met then the timer will go down every second
            
        }
        if(timeStarted == false)

        {
            timecheck = 10;
            
        }

        if (timecheck <= 0) // a condition that can only activate if the timer at 0 or under 0;
        {
            timeDisplay.text = "Times Up! "; // if the cindtion above is activated then the words Times Up will replace the timer
            SceneManager.LoadScene("GameOver");
        }
        else // this means that if the previous if statements aren't met then activate this code below.
        {
            int minutes = Mathf.FloorToInt(timecheck / 60f); // round the decimal places down instead of up to whole numbers then divide by 60 in decimals
            int seconds = Mathf.FloorToInt(timecheck - minutes * 60); //  round the decimals down to whole numbers then minus the minutes and times by 60
            string formattedTime = string.Format("{0:0}:{1:00}", minutes, seconds); // turn the numbers into reable text BUT put them into 2 values
            timeDisplay.text = "Timer: " + formattedTime; // display the timer going down in minutes and seconds
        }

    }

     void TimeStart()

    {
        timeDisplay.enabled = false;
        AllClear.enabled = true;
        timecheck = 10; // the time at the start of the game is set to 60 seconds
        timeStarted = false; // as soon as the game starts the variable is true
    }

    public void minusHack()

    {
        NumberofHacks--;
    }

    public void extraHack()

    {
        NumberofHacks += 2;

    }

    public void minusComputer()
    {

        ComputersLeft--;
    }

    public void minusDiscs()
    {
        NumberofDiscs--;

    }

}
