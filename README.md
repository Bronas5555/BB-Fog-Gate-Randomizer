# BB Fog Gate Randomizer

A WIP Fog gate Randomizer inspired by the Fog Gate Randomizers for [Elden Ring](https://www.nexusmods.com/eldenring/mods/3295) and [Dark Souls 1](https://www.nexusmods.com/darksoulsremastered/mods/165).

## General Idea
Fog Gates are permanent now and traversing them sends you to another randomly choosen Fog Gate. The warps are static, meaning they don't change. Traversing Gate A will always send you to Gate B and vice versa.

## Features
* Choose between Gates: Randomize All, or exclude the DLC
* Allow Boss Fight Escape: Don't require beating the Boss in order to use the Fog gates in it's arena
* Scale Bosses: To accommodate the new progression path, scale Boss damage and HP
* Scaling Difficulty: Choose between Easy, Normal and hard scaling
* Different Win Conditions:
	* Find and defeat Margo's Wet Nurse in order to access the Gherman fight.
	* Find and defeat all Bosses in the Game.
	* Find and defeat all Bosses that are not optional in the normal Game.
* Save, Load and Share Presets as .json Files.
* Graphical Spoiler Logs: Text File with the progression path intended by the Randomizer.
* Tracker: A interactive tracker showing you where to go from the current Fog Gate.

## Installation
#### Step 0: Prerequisites
This tutorial assumes you already have Bloodborne set up with shadPS4 (preferably with BB Launcher).
#### Step 1: Downloading the Randomizer and its dependencies
Download the Randomizer app from the [Releases page](https://github.com/Bronas5555/BB-Fog-Gate-Randomizer/releases).
To function, the Randomizer needs the app [DarkScript3](https://github.com/AinTunez/DarkScript3/releases)
Download it as well.
#### Step 2: Extracting Archives
Extract the BB Fog Gate Randomizer Archive anywhere you want.
Now extract DarkScript3 to the Directory `binarys` inside the Randomizer.
``` Folder Structure
	BB Fog Gate Randomizer
	├── binarys
	│	├── Ressources
	│	│	└── ...
	│	└── DarkScript3.exe
	└──...
```
#### Step 3: Configuring the Randomizer
Start the Randomizer Application and adjust the Settings to your liking. Continue by choosing or generating a seed and pressing Randomize. Randomizing can take a little while.

<details>
	<summary>Step3.1: For Linux users</summary>
	Unfortunately there isn't a native version of DarkScript for Linux. However, the Randomizer supports running DarkScript3 through wine. As long as wine is installed, is in your `PATH` and you have installed the .NET 6.0 Desktop and ASP.NET Runtimes everything should just work. 
	Test wine by running:
	
	`wine --version`
	
	If the command isn't found wine isn't installed or not in your path.
</details>

#### Step 4: Installing the Mod.
The Randomizer works by generating a Mod File for your exact settings. In the bottom right there's a button `Open Generated Mod Folder`. It opens a Directory containing your mod File.
#### Step 4.1: Installation with BB Launcher (Recommended)
Open BB Launcher and press `Open Mods Folder`. Copy and Paste the Folder `Fog Gate Randomizer` over to the BB Launcher Mod Folder. Now it can be activated in BB Launcher's Mod Manager. This method is preferred, because it doesn't touch your game files.
#### Step 4.2: Manual Installation (Not recommended)
Open your Bloodborne installation Directory. 
You should have two Directorys `CUSAxxxx` and `CUSAxxxx-patch`.  Copy and overwrite the files from the generated Mod Directory into your `CUSAxxxx-patch` Directory. It is recommended to Back up the `CUSAxxxx-patch` Directory, before overwriting any files.

## Spoiler Logs

Example Spoiler Log: 
``` Spoiler Log
Seed: -434454074
└── [Go] Central Yharnam: Metal Gate after Iosefkas Clinic Clinic Side 
    └── [Warp] Forbidden Woods: MPG at Beginning of Forbidden Woods, towards Woods (Reward: ForbiddenWoodsAccess)
        ├── [Go] Forbidden Woods: Shadows of Yharnam Entrance 
        │   └── [Warp] Cathedral Ward: MPG before Church Before Yahar'gul towards Church
        │       ├── [Go] Yahar'gul Unseen Village: MPG at Beginning of Yahar''gul, towards Sacrificial Church (Requires: RomDefeated) 
        │       │   └── [Warp] Yahar'gul Unseen Village: The One Reborn Arena Entrance
        │       │       └── [Go] Yahar'gul Unseen Village: The One Reborn Arena Exit 
        │       │           └── [Warp] Hemwick Charnel Lane: Witch of Hemwick Arena Exit (Reward: WitchOfHemwickDefeated)
        │       │               └── [Go] Hemwick Charnel Lane: Witch of Hemwick Arena Entrance 
        │       │                   └── [Warp] Nightmare Of Mensis: Micolash Arena Entrance
        │       │                       ├── [Go] Nightmare Of Mensis: Micolash Bridge Arena Exit 
        │       │                       │   └── [Warp] Cathedral Ward: MPG Before Old Yharnam Lantern Towards Old Yharnam
        │       │                       │       └── [Go] Old Yharnam: Old Yharnam MPG To Staircase 
        │       │                       │           └── [Warp] Yahar'gul Unseen Village: MPG Hypogean Goal Cave to Darkbeast Paarl, towards Darkbeast Paarl
        │       │                       │               └── [Go] Old Yharnam: Darkbeast Paarl Entrance 
        │       │                       │                   └── [Warp] Nightmare Of Mensis: Margo's Wet Nurse Arena Entrance
        ...
```
### Reading Spoiler Logs
- < Boss Name> Arena Entrance means inside the Boss Arena at the normal Entrance
- < Boss Name> Entrance means outside the Boss Arena at the normal Entrance
- < Boss Name> Arena Exit means inside the Boss Arena fat the Exit
- < Boss Name> Exit means outside the Boss Arena at the Exit
 - (Reward: < Reward Name> Here an item can be obtained, which unlocks a Fog Gate elsewhere.
 - (Requires: < Name> Here an item is needed, which can be obtained elsewhere.
 - Each fog Gate Name starts whit the Map name it is in. Confusingly, the Lecture Building is contained within the Byrgenwerth Map File.
 - [Go] Before a Gate Name means you reach this gate by walking from another gate.
 - [Warp] Before a Gate Name means you will be warped here by the gate above.
 - (Loop) at the End of a gate Name means it can be reached from another path. To follow it in the spoiler log, search for the same name in the file. There the path will be expanded.

## Credits and Thanks
#### Development Apps
* [Smithbox] (https://github.com/vawser/Smithbox) Amazing Tool for editing and viewing FromSoftware Map Files.
* [DarkScript3] (https://github.com/AinTunez/DarkScript3) Amazing IDE for editing FromSoftware EMEVD Event Scripts.
#### Ressources
* [Souls Modding Wiki] (https://www.soulsmodding.com/doku.php?id=start) Amazing ressources for learning to Mod FromSoftware Games.
* [Bloodborne Wiki] (https://www.bloodborne-wiki.com/p/index.html) Very helpful wiki with Item IDs and information about the game.

* [ShadPS4] (https://shadps4.net/) for allowing for easy testing for mods and allowing Bloodborne to be run on PC.
* [BB Launcher] (https://github.com/rainmakerv3/BB_Launcher) for making an awesome Launcher and Mod Manager for Bloodborne.




