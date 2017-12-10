To debug the addin do the following:

1) Copy UpdateUserType - For Testing.addin to your %Documents%\<Visual Studio Version Dir\Addins directory.
2) Edit UpdateUserType and modify the <Assembly> element to contain the full path to the \bin\debug binary.
3) In the addin's properties go to the Debug tab and do the following:
     a) Select Start external program and set to devenv.exe (<VSDir>\Common7\IDE\devenv.exe)
     b) For Command line arguments use 
               /resetaddin UpdateUserType.Connect
     c) For Working directory use the path to devenv.exe
4) Start the debugger.
5) The .addin file causes the addin to reinitialize and add its commands to the Tools menu.
