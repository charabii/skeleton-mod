using Photon.Realtime;
using System.Text;
using UnityEngine;
using System.IO;
using ExitGames.Client.Photon;
using HarmonyLib;
using BananaOS;
using Photon.Pun;
using BepInEx.Configuration;
using BepInEx;
using System;
using GorillaNetworking;


namespace BananaOS.Pages
{
    [BepInPlugin("com.shivriochilly.gorillatag.skeleton", "skeleton", "1.0.0")]
    public class skeletonpage : WatchPage
    {
        //What will be shown on the main menu if DisplayOnMainMenu is set to true
        public override string Title => "<color=white>Skeleton</color>";

        //Enabling will display your page on the main menu if you're nesting pages you should set this to false
        public override bool DisplayOnMainMenu => true;

        public bool Skele;

        

        //This method will be ran after the watch is completely setup
        public override void OnPostModSetup()
        {
            //max selection index so the indicator stays on the screen
            selectionHandler.maxIndex = 1;
            //BackgroundSkinConfigCheck = false;
        }

        /*static void lineChanger(string newText, string fileName, int line_to_edit)
        {
            string[] arrLine = File.ReadAllLines(fileName);
            BananaNotifications.DisplayNotification($"{fileName}", Color.yellow, Color.white, 1);
            arrLine[line_to_edit - 1] = newText;
            File.WriteAllLines(fileName, arrLine);
        }*/

        /*public void FixedUpdate()
        {
            String line;
            if (!BackgroundSkinConfigCheck)
            {
                try
                {
                    //Pass the file path and file name to the StreamReader constructor
                    StreamReader sr = new StreamReader("C:\\Program Files (x86)\\Steam\\steamapps\\common\\Gorilla Tag\\BepInEx\\config\\BananaOS.cfg");
                    //Read the first line of text
                    line = sr.ReadLine();
                    //Continue to read until you reach end of file
                    while (line != null && !BackgroundSkinConfigCheck)
                    {
                        if (line.Contains("Background Skin = "))
                        {
                            OriginalBackgroundSkinConfig = line;
                            BackgroundSkinConfigCheck = true;
                            BananaNotifications.DisplayNotification("background skin config check" + $"{OriginalBackgroundSkinConfig}", Color.yellow, Color.white, 1);
                        }
                        else
                        {
                            //Read the next line
                            line = sr.ReadLine();
                        }
                    }
                    //close the file
                    sr.Close();
                    Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
                finally
                {
                    Console.WriteLine("Executing finally block.");
                }
            }
        }*/

        

        //What you return is what is drawn to the watch screen the screen will be updated everytime you press a button
        public override string OnGetScreenContent()
        {
            /*if (BackgroundSkinConfigCheck)
            {
                lineChanger("Background Skin = ShiversUtils", "C:\\Program Files (x86)\\Steam\\steamapps\\common\\Gorilla Tag\\BepInEx\\config\\BananaOS.cfg", 80);
                BananaNotifications.DisplayNotification("set background", Color.yellow, Color.white, 1);
            }*/
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("<color=white>==</color> Skeleton <color=white>==</color>");
            if (Skele)
            {
                stringBuilder.AppendLine(selectionHandler.GetOriginalBananaOSSelectionText(0, "turn off"));
            }
            else
            {
                stringBuilder.AppendLine(selectionHandler.GetOriginalBananaOSSelectionText(0, "turn on"));
            }
            return stringBuilder.ToString();
        }

        public override void OnButtonPressed(WatchButtonType buttonType)
        {
            switch (buttonType)
            {
                case WatchButtonType.Up:
                    selectionHandler.MoveSelectionUp();
                    break;

                case WatchButtonType.Down:
                    selectionHandler.MoveSelectionDown();
                    break;

                case WatchButtonType.Right:
                    //BaSkPa.ApplySkin("ShiversUtils");
                    break;

                case WatchButtonType.Left:
                    break;

                case WatchButtonType.Enter:
                    if (selectionHandler.currentIndex == 0)
                    {
                        if (Skele)
                        {
                            GorillaTagger.Instance.offlineVRRig.ShowSkeleton(false);
                            Skele = false;
                        }
                        else if (Skele)
                        {
                            GorillaTagger.Instance.offlineVRRig.ShowSkeleton(true);
                            Skele = true;
                        }
                        else
                        {
                            GorillaTagger.Instance.offlineVRRig.ShowSkeleton(true);
                            Skele = true;
                        }
                    }
                        return;

                //It is recommended that you keep this unless you're nesting pages if so you should use the SwitchToPage method
                case WatchButtonType.Back:
                    /*if (BackgroundSkinConfigCheck)
                    {
                        lineChanger($"{OriginalBackgroundSkinConfig}", "C:\\Program Files (x86)\\Steam\\steamapps\\common\\Gorilla Tag\\BepInEx\\config\\BananaOS.cfg", 80);
                        BananaNotifications.DisplayNotification("got rid of background", Color.yellow, Color.white, 1);
                    }*/
                    //BaSkPa.ApplySkin("Default");
                    ReturnToMainMenu();
                    break;
            }
        }
    }
}