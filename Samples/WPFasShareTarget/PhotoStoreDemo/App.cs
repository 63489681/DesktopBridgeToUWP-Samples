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

// // Copyright (c) Microsoft. All rights reserved.
// // Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.IO;
using System.Reflection;


namespace PhotoStoreDemo
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        public static string CommandLineArgOne = string.Empty;
        public App()
        {
            ProcessCommandLine(Environment.GetCommandLineArgs());
        }

        private static void ProcessCommandLine(string[] args)
        {
            if (args.Length > 1)
            {
                var path = args[1];
                var sourcePath = new FileInfo(path);
                if (sourcePath.Exists)
                {
                    CommandLineArgOne = sourcePath.FullName;
                    var destPath = new FileInfo(Path.Combine(PhotosFolder.Current, sourcePath.Name));
                    if (!destPath.Exists)
                    {
                        File.Copy(sourcePath.FullName, destPath.FullName);
                    }
                }
            }
        }
    }
}