# Architecture
Custom design patterns for fast using in own projects

## Content
* [Entry point](#entry-point)
* [Service Locator](#service-locator)
* [State Machine](#state-machine)
* [Object Pool](#object-pool)
* [Reactive Property](#reactive-property)

## Entry point
### How it works?
Before loading any scene, the Entry point calls the "AutoRun" method using the RuntimeInitializeOnLoadMethod attribute, where it sets the main settings of the application, for example, the target frame rate or SleepTimeout for a mobile device if the game is running on it. 

Also in this method, after configuring the application, an instance of the game entry point is created, in which a UI is created that must be saved after passing the scenes, for example, the loading screen (used DontDestroyOnLoad).
The game then checks which scene should load first. The "RunGame" method loads the specified scene regardless of which scene the game is launched in the Unity editor. If you started from the plugins scene, "RunGame" will not load your game.

## Service locator
### How it work?
Before using the service, you must register it in the Service Locator. You can do this from anywhere in the code, if your service exists.  But it is recommended to do it in one place, like Bootstrap. And you can get registered services in any client. This is bad for encapsulation, but good for convenience. I use Service Locator for my own small projects. 

Most importantly, do not forget to unregistration of the service if you no longer use it. For example, if you need to register concrete services for a concrete scene, you can create a monobehaviour script in which you will register all services at startup for the current scene and unregister them in the onDestroy method, which will start when switching the scene.

