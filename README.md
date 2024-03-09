Tutorial for how to use:

1) Install BepInEx
2) Put CupPatcher.dll inside of your BepInEx/patchers directory
3) Put CustomData.cs in your project somewhere, doesn't matter
4) Call CustomData.Initialize() when your mod is loaded
5) You can start to put data using CustomData.PutForSlot() somewhere after PlayerData is initialized (I think it's when you enter your save but I'm not sure, I had some bugs with it)
6) Whenever you want you can use CustomData.GetForSlot() to get a string containing the value of your data
