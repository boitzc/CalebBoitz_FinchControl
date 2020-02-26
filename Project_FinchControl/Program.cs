using System;
using System.Collections.Generic;
using System.IO;
using FinchAPI;
using System.Linq;

namespace CalebBoitz_FinchControl
{

    // *************************************************************
    // Program Title:   Finch Control
    // Type:            Console
    // Author:          Boitz, Caleb
    // Description:     A remote contol for Finch robots
    // Date Created:    02/25/2020
    // Date Revised:    BLAH
    // *************************************************************

    class Program
    {
        /// <summary>
        /// first method run when the app starts up
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            SetTheme();

            DisplayWelcomeScreen();
            DisplayMenuScreen();
            DisplayClosingScreen();
        }

        /// <summary>
        /// setup the console theme
        /// </summary>
        static void SetTheme()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Magenta;
        }

        /// <summary>
        ///                      Main Menu
        /// </summary>
        static void DisplayMenuScreen()
        {
            Console.CursorVisible = true;

            bool quitApplication = false;
            string menuChoice;

            Finch finchRobot = new Finch();

            do
            {
                DisplayScreenHeader("Main Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Connect Finch Robot");
                Console.WriteLine("\tb) Talent Show");
                Console.WriteLine("\tc) Data Recorder");
                Console.WriteLine("\td) Alarm System");
                Console.WriteLine("\te) User Programming");
                Console.WriteLine("\tf) Disconnect Finch Robot");
                Console.WriteLine("\tq) Quit");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        DisplayConnectFinchRobot(finchRobot);
                        break;

                    case "b":
                        DisplayTalentShowMenuScreen(finchRobot);
                        break;

                    case "c":
                        DataRecorderMenu(finchRobot);
                        break;

                    case "d":

                        break;

                    case "e":

                        break;

                    case "f":
                        DisplayDisconnectFinchRobot(finchRobot);
                        break;

                    case "q":
                        DisplayDisconnectFinchRobot(finchRobot);
                        quitApplication = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitApplication);
        }

        #region TALENT SHOW

        /// <summary>
        ///                      Talent Show Menu                         
        /// </summary>
        static void DisplayTalentShowMenuScreen(Finch myFinch)
        {
            Console.CursorVisible = true;

            bool quitTalentShowMenu = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("Talent Show Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Light and Sound");
                Console.WriteLine("\tb) ");
                Console.WriteLine("\tc) ");
                Console.WriteLine("\td) ");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        DisplayLightAndSound(myFinch);
                        break;

                    case "b":

                        break;

                    case "c":

                        break;

                    case "d":

                        break;

                    case "q":
                        quitTalentShowMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitTalentShowMenu);
        }

        /// <summary>
        ///                Talent Show > Light and Sound                 
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        static void DisplayLightAndSound(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Light and Sound");

            Console.WriteLine("\tThe Finch robot will now show off its glowing talent!");
            DisplayContinuePrompt();

            for (int soundLevel = 0; soundLevel < 10000; soundLevel = soundLevel + 50)
            {
                finchRobot.noteOn(soundLevel);
            }
            finchRobot.noteOff();
            for (int i = 0; i < 100; i++)
            {
                finchRobot.setLED(255, 0, 0);
                finchRobot.wait(10);
                finchRobot.setLED(0, 0, 0);
                finchRobot.wait(10);
            }
            for (int soundLevel = 10000; soundLevel > 0; soundLevel = soundLevel - 50)
            {
                finchRobot.noteOn(soundLevel);
            }
            finchRobot.noteOff();

            finchRobot.setMotors(255, -255);
            finchRobot.wait(1000);
            finchRobot.setMotors(0, 0);

            finchRobot.setMotors(-255, 255);
            finchRobot.wait(1000);
            finchRobot.setMotors(0, 0);

            finchRobot.setMotors(255, -255);
            finchRobot.wait(1000);
            finchRobot.setMotors(0, 0);

            finchRobot.setMotors(-255, 255);
            finchRobot.wait(1000);
            finchRobot.setMotors(0, 0);

            finchRobot.setMotors(255, -255);
            finchRobot.wait(1000);
            finchRobot.setMotors(0, 0);

            finchRobot.setMotors(-255, 255);
            finchRobot.wait(1000);
            finchRobot.setMotors(0, 0);

            DisplayMenuPrompt("Talent Show Menu");
        }

        static void DisplayMovement(Finch finchRobot)
        {
            DisplayScreenHeader("Movement");

            finchRobot.setMotors(255, 255);
            finchRobot.wait(1000);
            finchRobot.setMotors(0, 0);

            DisplayMenuPrompt("Talent Show");
        }

        #endregion

        #region DATA RECORDER

        static void DataRecorderMenu(Finch finchRobot)
        {
            bool quitDataRecorderMenu = false;

            do
            {
                DisplayScreenHeader("Data Recorder Menu");

                int numberOfPoints = 0;
                double dataPointFrequency = 0;
                double[] temperatures = null;



                string menuChoice;


                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Number of data points");
                Console.WriteLine("\tb) Frequency of data points");
                Console.WriteLine("\tc) Get Data");
                Console.WriteLine("\td) Show Data");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        numberOfPoints = GetNumberOfDataPoints();
                        break;

                    case "b":
                        dataPointFrequency = drdGetDataPointFrequency();
                        break;

                    case "c":
                        temperatures = DataRecorderDisplayGetData(numberOfPoints, dataPointFrequency, finchRobot);
                        break;

                    case "d":
                        DataRecorderDisplayData(temperatures);
                        break;

                    case "q":
                        quitDataRecorderMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (quitDataRecorderMenu);
        }

        static void DataRecorderDisplayData(double[] temperatures)
        {
            DisplayScreenHeader("data");

            Console.WriteLine(
                "data point".PadLeft(12) +
                "temp".PadLeft(10)
                );

            Console.WriteLine(
                "----------".PadLeft(12) +
                "----".PadLeft(10)
                );


            //table data
            for (int index = 0; index < temperatures.Length; index++)
            {
                Console.WriteLine(
                (index + 1).ToString().PadLeft(12) +
                temperatures[index].ToString("n2").PadLeft(10)
                );
            }

            Console.WriteLine();
            Console.WriteLine("current data");
            DataRecorderDisplayData(temperatures);

            DisplayContinuePrompt();
        }

        static void dataRecorderDisplayTable(double[] temperatures)
        {

        }

        static double drdGetDataPointFrequency()
        {
            double dataPointFrequency;

            DisplayScreenHeader("Data point frequency.");

            Console.WriteLine("data points frequency seconds");

            //validate response
            double.TryParse(Console.ReadLine(), out dataPointFrequency);

            Console.WriteLine();
            Console.WriteLine($"");

            DisplayContinuePrompt();

            return dataPointFrequency;
        }

        static int GetNumberOfDataPoints()
        {
            int numberOfDataPoints;

            DisplayScreenHeader("Number of data points.");

            Console.WriteLine("Number of data points");

            //validate response
            int.TryParse(Console.ReadLine(), out numberOfDataPoints);

            Console.WriteLine();
            Console.WriteLine($"");

            DisplayContinuePrompt();

            return numberOfDataPoints;
        }

        static double[] DataRecorderDisplayGetData(int numberOfPoints, double dataPointFrequency, Finch finchRobot)
        {
            double[] temperatures = new double[numberOfPoints];
            int frequencyInSeconds;

            DisplayScreenHeader("Get Data");

            // echo number of data points and frequency

            Console.WriteLine("The Finch robot is ready to record temperatures");
            DisplayContinuePrompt();

            for (int index = 0; index < numberOfPoints; index++)
            {
                temperatures[index] = finchRobot.getTemperature();
                Console.WriteLine($"data #{index + 1}: {temperatures[index]} celsius");
                frequencyInSeconds = ((int)(dataPointFrequency * 1000));
                finchRobot.wait(frequencyInSeconds);
            }

            DisplayContinuePrompt();

            return temperatures;
        }
        #endregion

        #region FINCH ROBOT MANAGEMENT

        /// <summary>
        ///                Disconnect the Finch Robot                      
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        static void DisplayDisconnectFinchRobot(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Disconnecting Finch Robot");

            Console.WriteLine("\tYou're about to disconnect from the Finch robot.");
            DisplayContinuePrompt();

            finchRobot.disConnect();

            Console.WriteLine();

            Console.WriteLine("\tThe Finch robot is now disconnected.");

            DisplayMenuPrompt("Main");
        }

        /// <summary>
        ///                   Connect the Finch Robot                     
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        /// <returns>notify if the robot is connected</returns>
        static bool DisplayConnectFinchRobot(Finch finchRobot)
        {
            Console.CursorVisible = false;

            bool robotConnected;

            DisplayScreenHeader("Connecting to Finch Robot");

            Console.WriteLine("\tYou're about to connect to a Finch robot, please be sure the USB cable is connected to");
            Console.WriteLine();
            Console.WriteLine("\tthe robot and computer now.");
            Console.WriteLine();
            DisplayContinuePrompt();

            robotConnected = finchRobot.connect();

            // TODO test connection and provide user feedback - text, lights, sounds
            Console.WriteLine("\tYou're now connected.");
            Console.WriteLine();
            DisplayMenuPrompt("Main");

            //
            // reset finch robot
            //
            finchRobot.setLED(0, 0, 0);
            finchRobot.noteOff();

            return robotConnected;
        }

        #endregion

        #region USER INTERFACE

        /// <summary>
        ///                      Welcome Screen                            
        /// </summary>
        static void DisplayWelcomeScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine("\n\n\tCalebs' kick ass Finch control");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        ///                      Closing Screen                            
        /// </summary>
        static void DisplayClosingScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tThank you for using Finch Control!");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display continue prompt
        /// </summary>
        static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("\tPress any key to continue.");
            Console.ReadKey();
        }

        /// <summary>
        /// display menu prompt
        /// </summary>
        static void DisplayMenuPrompt(string menuName)
        {
            Console.WriteLine();
            Console.WriteLine($"\tPress any key to return to the {menuName} Menu.");
            Console.ReadKey();
        }

        /// <summary>
        /// display screen header
        /// </summary>
        static void DisplayScreenHeader(string headerText)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\t" + headerText);
            Console.WriteLine();
        }

        #endregion
    }
}
