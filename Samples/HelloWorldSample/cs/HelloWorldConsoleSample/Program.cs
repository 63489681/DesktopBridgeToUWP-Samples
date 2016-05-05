﻿//*********************************************************
//
// Copyright (c) Microsoft. All rights reserved.
// This code is licensed under the MIT License (MIT).
// THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
// IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
// PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.
//
//*********************************************************

using System;
using Windows.UI.Notifications;
using Windows.Data.Xml.Dom;

namespace HelloWorldConsoleSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Centennial!");
            Console.WriteLine("Enter the text for your Live Tile:");
            string liveTileText = Console.ReadLine();

            // Update the apps live tile
            XmlDocument tileXml = TileUpdateManager.GetTemplateContent(TileTemplateType.TileSquare150x150Text01);

            XmlNodeList textNodes = tileXml.GetElementsByTagName("text");
            textNodes[0].InnerText = liveTileText;
            textNodes[1].InnerText = DateTime.Now.ToString("HH:mm:ss");

            TileNotification tileNotification = new TileNotification(tileXml);
            TileUpdateManager.CreateTileUpdaterForApplication().Update(tileNotification);

            Console.WriteLine("Go to your tile and see how it receive the update live!");
            Console.ReadLine();
        }
    }
}
