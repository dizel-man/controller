using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class display_manager : MonoBehaviour {

    public Text test_text;
    string new_text = "";
    public bool Lock_orientation = false;
    public int plus = 0;
    public int screen_numder;
    public Text screenN; // временный текст для просмотра номера экрана
    void Start () {

        

       
     
    }
	
	
	void Update () {

        screenN.text = screen_numder.ToString();// временный текст для просмотра номера экрана


        orient_checker(); // смотрим какая в данный момент ориентация, пишем на кнопке и пересылаем в доп.переменную

        Reshatel_lock();

        text_colores();
        //Reshatel();



     //   Lock_text(Lock_orientation);// отключаем / включаем все вращения экрана 

      

     //   orient_locker(Lock_orientation, screen_numder, plus); // блокируем ориентацию либо кнопеой плюс минус либо кнопкой блокировки


      

    }


    public void orient_checker() // check orientation
    {
        
        if (Screen.orientation == ScreenOrientation.LandscapeLeft)
        {
            screen_numder = 4;
        }
        if (Screen.orientation == ScreenOrientation.LandscapeRight)
        {
            screen_numder = 2;
        }
        if (Screen.orientation == ScreenOrientation.Portrait)
        {
            screen_numder = 1;
        }
        if (Screen.orientation == ScreenOrientation.PortraitUpsideDown)
        {
            screen_numder = 3;
        }
        if (Screen.orientation == ScreenOrientation.AutoRotation)
        {
            screen_numder = 0;
        }
    
    }
  
    public void Lock() // this bind to button
    {
          
     Lock_orientation = !Lock_orientation;

    }


    public void plus_screen() // плюсуем
    {
        Debug.Log("plus");
        plus += 1;
        if (plus == 5)
        {
            plus = 0;
        }
              
    }
   
    public void minus_screen() // минусуем
    {
        Debug.Log("minus");
        plus -= 1;
        if (plus == -1)
        {
            plus = 4;
        }
     }


    void Reshatel_lock()
    {
        if (Lock_orientation == true) // locking
        {
              

            if (screen_numder == 4)
            {
                Screen.orientation = ScreenOrientation.LandscapeLeft;

            }

            if (screen_numder == 2)
            { 
                Screen.orientation = ScreenOrientation.LandscapeRight;

            }
            if (screen_numder == 1)
            {
                Screen.orientation = ScreenOrientation.Portrait;

            }
            if (screen_numder == 3)
            {

                Screen.orientation = ScreenOrientation.PortraitUpsideDown;
            }

            Screen.autorotateToLandscapeLeft = false;
            Screen.autorotateToLandscapeRight = false;
            Screen.autorotateToPortrait = false;
            Screen.autorotateToPortraitUpsideDown = false;



    }

        if (Lock_orientation == false) // unlocking
        {
            Screen.orientation = ScreenOrientation.AutoRotation;
           
          // screen_numder = 0;

            Screen.autorotateToLandscapeLeft = true;
            Screen.autorotateToLandscapeRight = true;
            Screen.autorotateToPortrait = true;
            Screen.autorotateToPortraitUpsideDown = true;


        }
    }




    void Reshatel()
    {
        if(plus > 0)// && Lock_orientation == false) // locking
        {
            Lock_orientation = true;

            test_text.color = Color.red;
            new_text = "Lock";
            test_text.text = new_text;
        }
        if (plus == 0) // unlocking
        {
            Lock_orientation = false;

            test_text.color = Color.green;
            new_text = "Auto";
            test_text.text = new_text;
        }
        if (Lock_orientation == true) // locking
        {
            plus = screen_numder;

            test_text.color = Color.red;
            new_text = "Lock";
            test_text.text = new_text;
        }
        if (Lock_orientation == false) // unlocking
        {
            plus = 0;
            screen_numder = 0;
           // plus = screen_numder;

            test_text.color = Color.green;
            new_text = "Auto";
            test_text.text = new_text;
        }
    }

    public void Lock_text(bool locking) // отключаем / включаем все вращения экрана 
    {
        if (locking == false)
        {

            Screen.autorotateToLandscapeLeft = true;
            Screen.autorotateToLandscapeRight = true;
            Screen.autorotateToPortrait = true;
            Screen.autorotateToPortraitUpsideDown = true;

        }
        if (locking == true)
        {

            Screen.autorotateToLandscapeLeft = false;
            Screen.autorotateToLandscapeRight = false;
            Screen.autorotateToPortrait = false;
            Screen.autorotateToPortraitUpsideDown = false;

        }

    }

    public void orient_locker(bool locking, int scr_N, int pl) // Lock orientation
    {


        /*
          if (locking && Screen.orientation == ScreenOrientation.Landscape )//1
          {
              Screen.orientation = ScreenOrientation.LandscapeLeft;
              //plus = 1;
          }
          */
        if ((locking && scr_N == 4) || pl == 4)//4
        {
            Screen.orientation = ScreenOrientation.LandscapeLeft;

        }
        if ((locking && scr_N == 2) || pl == 2)//2
        {
            Screen.orientation = ScreenOrientation.LandscapeRight;

        }
        if ((locking && scr_N == 1) || pl == 1)//1
        {
            Screen.orientation = ScreenOrientation.Portrait;

        }
        if ((locking && scr_N == 3) || pl == 3)//3
        {

            Screen.orientation = ScreenOrientation.PortraitUpsideDown;
        }

        if (!locking || pl == 0)//0
        {
            Screen.orientation = ScreenOrientation.AutoRotation;
        }


    }

    void text_colores()
    {
        if(Lock_orientation == false)
        {
            new_text = "Auto";
            test_text.text = new_text;
            test_text.color = Color.green;
        }
        if (Lock_orientation == true)
        {
            new_text = "Lock";
            test_text.text = new_text;
            test_text.color = Color.red;
        }
    }
         
}
