using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    //Game Configuration Data
    string [] level1Passwords={"Books","Aisle","Self","Password","Font","Borrow"};
    string[] level2Passwords = { "Prisoner", "handcuffs", "holster", "uniform", "arrest"};
    //Game State
    int level;

    enum Screen{MainMenu,Password,Win};
    Screen currentScreen;
    string password;

    
    
    void Start()
    {
        
        ShowMainMenu();
        print("Hello World");

    }
    void ShowMainMenu (){
        Terminal.ClearScreen();
        Terminal.WriteLine("Hello");
        Terminal.WriteLine("What would you like to hack into ?");
        Terminal.WriteLine("Press 1 for the local library");

        Terminal.WriteLine("Press 2 for the police station");
        Terminal.WriteLine("Enter your selection:");
        currentScreen = Screen.MainMenu;
    }
    //This Should only decide who to handle input, not actually do it

    void OnUserInput(string input){
    
        if(input=="menu"){
            ShowMainMenu();
        }else if(currentScreen==Screen.MainMenu)
        {
            RunMainMenu(input);
        }else if (currentScreen==Screen.Password){
            CheckPassword(input);

        }

    }

     void RunMainMenu(string input)
    {
        bool isValidLevelNumber=(input=="1"||input=="2");
        if(isValidLevelNumber){
            level=int.Parse(input);
        }

        if (input == "1")
        {
            level = 1;
            password = level1Passwords[2];
            StartGame();
            
        }
        else if (input == "2")
        {
            level = 2;
            password=level2Passwords[1];
            StartGame();
          


        }
        else if (input == "3")
        {
            level = 3;
            StartGame();

        }
        else if (input == "31")
        {
            Terminal.WriteLine("Die Gruselgeschichte" + "der Nachtmahr" + "grimace" + "https://www.youtube.com/watch?v=P4ZQ7jk0D88");

        }
    }

    void StartGame(){
     print(level1Passwords.Length);
     print(level2Passwords.Length);
    currentScreen=Screen.Password;
    Terminal.ClearScreen();
        
    switch(level){
        
        case 1:
       
        password=level1Passwords[Random.Range(0, level1Passwords.Length)];
        break;
        case 2:
       
        password=level2Passwords[Random.Range(0, level1Passwords.Length)];
        break;
        default:
        Debug.LogError("Invalid Level Number");
        break;

    }
    Terminal.WriteLine("Please enter your password");

    }
    /* Use enums For Menu Items (Menu is resturant menu)
    *They may have numbers, but we don't care.
    *They group similar items Starter, Main, Dessert
    *Each grouping has a fixed list of items (e.g. Starter.Soup, Main.FishPie)
    *We choose the type names(Starter/Appetieser).
    *Soup is of type Starter, FishPie is of type Main.
    //////////////////////////////////////////////////
    enumerations in C#
    1.Define the new type of variable...
    enum Screen {MainMenu,Password, Win};
    
    Using Unity's Random.Range
    Random.Range(min,max)
    Min is inclusive,max is exclusive
    Example Random.Range(3,7) will generate one of the following numbers each time it's run:3, 4, 5, 6
    but not 7

    */
    void CheckPassword(string input){
        if(input==password)
        {
            DisplayWinScreen();
        }
        else
        {
            Terminal.WriteLine("Sorry, Wrong password");
        }
    }

    void DisplayWinScreen()
    {
        currentScreen=Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();

        

    }
    void ShowLevelReward(){
        switch(level){
            case 1:
            Terminal.WriteLine("Have a book......");
            Terminal.WriteLine(@"
    .s$P*.s$$$s.`*T$$b T TP$P.d$P .sd$s.                
        .s$P .s$$$$$$$b. T$$b T:P d$$P.d$$$$$$bs.             
       d$$P d$$$$P'`T$$$b $$$;:$bd$$$$$$b`T$$*$$$b.           
      d$$P d$$$P' .+. *$$:$$$;.$$$P^*""*^b.$$b T$$$b          
     d$P .d$$$b.s$$$$$b TP^TP dP',d$$$$$s.`T$$b T$$$b         
    d$P d$$P T$$$P*""*^b.b d,P^*          


            ");
            break;
            case 2:
                Terminal.WriteLine("You got the prison key !");
                Terminal.WriteLine(@"
                 ____ 
               | ___ |>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>       


            ");
                break;
            default:
            Terminal.WriteLine("Wrong");
            break;
            

        }
    }
}




