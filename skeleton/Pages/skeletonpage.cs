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

        //What you return is what is drawn to the watch screen the screen will be updated everytime you press a button
        public override string OnGetScreenContent()
        {
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
                    ReturnToMainMenu();
                    break;
            }
        }
    }
}
