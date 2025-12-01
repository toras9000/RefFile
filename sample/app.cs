#!/usr/bin/env -S dotnet run --file
#:package RefFile@0.2.0
// Package references should be written in the main file.
#:package Humanizer.Core@3.0.1

[assembly: RefFile("common.cs")]

var data = new CommonData(123456);
data.Print();

