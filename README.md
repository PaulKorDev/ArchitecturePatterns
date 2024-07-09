# Architecture
Custom design patterns for fast using in own projects

## Content
* [Entry point](#entry-point)
* [Service Locator](#service-locator)
* [State Machine](#state-machine)
* [Object Pool](#object-pool)
* [Custom Event](#custom-event)
* [Reactive Property](#reactive-property)

## Entry point
### How it works?
Before loading any scene, the Entry point calls the "AutoRun" method using the RuntimeInitializeOnLoadMethod attribute, where it sets the main settings of the application, for example, the target frame rate or SleepTimeout for a mobile device if the game is running on it. 

Also in this method, after configuring the application, an instance of the game entry point is created, in which a UI is created that must be saved after passing the scenes, for example, the loading screen (used DontDestroyOnLoad).
The game then checks which scene should load first. The "RunGame" method loads the specified scene regardless of which scene the game is launched in the Unity editor. If you started from the plugins scene, "RunGame" will not load your game.

## Service Locator
### How it works?
Before using the service, you must register it in the Service Locator. You can do this from anywhere in the code, if your service exists.  But it is recommended to do it in one place, like Bootstrap. And you can get registered services in any client. This is bad for encapsulation, but good for convenience. I use Service Locator for my own small projects. Best architecture solve is DI, most popular plugin for Unity it's Zenject.  

Most importantly, do not forget to unregistration of the service if you no longer use it. For example, if you need to register concrete services for a concrete scene, you can create a monobehaviour script in which you will register all services at startup for the current scene and unregister them in the onDestroy method, which will start when switching the scene.

## State Machine
### How it works?
Before instantiating a state machine, you need to create concrete states. Your concrete states must be inherited from a concrete abstract base state. All your states must contain an Entry method and inherit from IService. If you need to use Update or FixedUpdate, your base state must inherit from ILogicState and IPhysicState respectively. 
### Example
In the “ExampleStateMachine” folder you can see what classes were created and their hierarchy. On the scene with the same name you can test my StateMachine.

## Object Pool
### What it can?
I tried to make my ObjectPool universal, so it has many functions. You can set pool limits, set the AutoExpand flag, get lists and the count of active, free or all objects.
### Additional flexibility
To create an object, PoolObject receives a FactoryMethod from the constructor. The PoolObject also receives ReturnEffect and GetEffect methods, because sometimes you may need more functionality than just SetActive, for example, initialize the object just before receiving it.
### Example
In the “ExampleObjectPool” folder you can see how I created concrete object pool for conrete object. On the scene with the same name you can test my ObjectPool, creating objects with click.

## Custom Event
### How it works?
This works like usual events, but you can set priority when subscribing of listener, and listeners will be called in order of priority.
### Syntax
CustomEvent can take from 0 to 4 parameters, if you need more, you can add a new class to CustomEvent.cs

Initialization: CustomEvent<int, string> myEvent = new CustomEvent<int, string>(); 

Subscribe: myEvent.Subscribe(MyMethod, 1);

Unsubsribe: myEvent.Unsubscribe(MyMethod);

Invoke: myEvent.Trigger(intVar1, stringVar2);

## Reactive Property
I copied this code from somewhere, but it's better to use UniRx for serious projects.
### How it works?
Create variable with type of reactive class and add listener for created variable.
### Minuses
It does not work with reference type variables, because they change "from the inside".
