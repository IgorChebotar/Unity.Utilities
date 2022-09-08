# SimpleMan.Utilities [Download](https://github.com/IgorChebotar/Utilities/releases)
Standard utilities for any project on Unity engine. 

**Author:** Igor-Valerii Chebotar
**Email:**  igor.valerii.chebotar@gmail.com

## Requirements
* [Sirenix - Odin Inspector](https://assetstore.unity.com/packages/tools/utilities/odin-inspector-and-serializer-89041#description "* Sirenix - Odin Inspector")

## How to install plugin?
Open installer by the click on Tools -> Simple Man -> Master Installer -> [Plugins' name] -> Click 'Install' button. If you don't have one or more of the plugins this plugin depends on, you must install it first.


## Coroutines as MonoBehavior extensions
create and execute coroutine by one line of code.

### Methods
| Function name | Description                    |
| ------------- | ------------------------------ |
| Delay      | Invoke target method after delay       |
| DestroyAfter  | Destroy game object after delay    |
| DestroyComponentAfter      | Destroy component after delay       |
| WaitFrames     | Invoke target method  after certain number of frames    |
| WaitUntill      | Invoke target method after condition completed     |
| RepeatUntill      | Call target method while condition is not complete       |
| RepeatForever      | Call target method each frame or with delay forever      |

### C# Examples
```C# 
//Call 'DoAction' method after 3 seconds
this.Delay(3, DoAction);
```
```C# 
//Destroy game object after 3 seconds
this.DestroyAfter(3);
```

```C# 
//Call 'DoAction' method after 3 seconds with parameter
this.Delay(3, ( ) =>DoAction("Hello!"));
```


## Value checkers
Gives ability to check the value without using 'if' keyword and throw an exception or print log to constole if check was failed. 

### C# Examples
```C# 
//Check the "Health" value and call the "Death" method if it is zero, 
Health.IfEqualZero().Execute(Death);

//Check the "Armor" value and print message 'Armor is broken' to the console if it less than 0.5, . 
Armor.IfLessThan(0.5f).PrintLog(gameObject.name, "Armor is broken");

//Check the 'HealthBar' class reference and throw and exception if it is null
HealthBar.IfNull().ThrowException(gameObject.name, "Health isn't exist");
```



## Execute once system
Gives ability to execute method only one time per frame, no matter how many calls was received. 

### Methods
| Function name | Description                    |
| ------------- | ------------------------------ |
| ExecuteOncePerFrame      | Execute target method. Ignore other execution calls for this method in current frame.|

### C# Examples
```C# 
//Will be called once 
ExecuteOnceSystem.ExecuteOncePerFrame(DoAction)
ExecuteOnceSystem.ExecuteOncePerFrame(DoAction)
ExecuteOnceSystem.ExecuteOncePerFrame(DoAction)
```
```C# 
//Works also with parameters
ExecuteOnceSystem.ExecuteOncePerFrame(( ) => DoAction("Hello"))
```


## State machine
Make your state machine based on the 'StateMachine' class. It simple! The state machine supports up to 3 arguments in each state and custom tick range.

```C# 
//Create state machine for the Game class
StateMachine<Game> _localStateMachine = new StateMachine<Game>()
{
	this,
    new InitialState<Game>(this),
    new LoadPlayerProgressState(this, _playerProgressService),
    new LoadingState(this, _sceneManagerService),
    new GameLoopState(this, _playerFactory, _uiFactory, _playerProgressService),
    new EndGameState(this, _playerProgresService, _uiFactory)
});

//Start state machine from the initial state
_localStateMachine.SwitchState<InitialState>();
```

```C# 
//Switch state with the string parameter
_localStateMachine.SwitchState<LoadingState, string>(sceneName);
```

## Collection extensions
### Methods
| Function name | Description                    |
| ------------- | ------------------------------ |
|AddUnique      | Works with list, queue, stack and dictionary. Ignore *Add* action if collection already contains element|
|Except | Returns collection without element|
|Validate | Returns collection without null elements|
|NullCheck | Throws an exeption when at least one element is null|
|ForEach | Make action for each element in collection|
|Random | Gives random element in collection|

### C# Examples
```C# 
//Add element only if it isn't exist in collection
List<GameObject> targetsList = new List<GameObject>();
gameObjectList.AddUnique(targetObject);
```

## Transform extensions
### Methods
| Function name | Description                    |
| ------------- | ------------------------------ |
| GetChildren      | Return array of direct children transforms|
| GetChildrenOfType      | Return array of direct children that have certain component|
| DestroyChildren      | Destroy all children of current transform|
| DestroyChildrenImmediate      | Destroy all children of current transform (for editor mode)|

### C# Examples
```C# 
//Get children array
Transform[] children = transform.GetChildren();
```
```C# 
//Get children array with 'Health' component
Health[] children = transform.GetChildrenOfType<Health>();
```



## Object extensions
### Methods
| Function name | Description                    |
| ------------- | ------------------------------ |
| ThrowNullReferenceException      | Throws specified exception with name of the object caller |
| ThrowArgumentNullException      | Throws specified exception with name of the object caller|
| ThrowInvalidOperationException      | Throws specified exception with name of the object caller|
| ThrowArgumentOutOfRangeException      | Throws specified exception with name of the object caller|
| ThrowIndexOutOfRangeException      | Throws specified exception with name of the object caller|
| ThrowMustBeChildOfException      | Throws specified exception with name of the object caller|
| PrintLogRequestReceived      | Throws specified exception with name of the object caller|
| PrintLogValueChanged      | Throws specified exception with name of the object caller|
| PrintLog      | Print debug log message with name of the object caller|
| PrintWarning      | Print debug log warning message with name of the object caller|
| SetPrefix      | Set prefix to the target game object|
| GetNameWithoutPrefix      | Returns name of the target game object without prefix|
| With      | Pseudo-builder |
| ToScene      | Move object to the target scene |


### C# Examples
```C# 
//Throw exception
if(_health == null)
	this.ThrowNullReferenceException("Component 'Health' not exist");
```
```C# 
//Game object name will look like this '[Player]PreviousName'
this.SetPrefix("Player");
```


## Component extensions
### Methods
| Function name | Description                    |
| ------------- | ------------------------------ |
| TryGetComponentInChildren      | Return true if at least one child of this object have certain component|
| TryGetComponentInParent      |  Return true if at least one parent of this object have certain component|

### C# Examples
```C# 
//Throws exception if parent object don't have 'Animator' component
if(TryGetComponentInParent<Animator>(out Animator animator) == false)
	this.ThrowMustBeChildOfException("Animator");
```

## Base types extensions
### Methods
| Function name | Description                    |
| ------------- | ------------------------------ |
| (string) ToSplitPascalCase| SadButTrue -> Sad But True|
| (string) WithoutSpaces| Sad But True -> SadButTrue|
| (float, int) ClampPositive      | Return closest positive value |
| (string) FirstCharToUpper      | Return string with upper first character |
| (Vector2) XY2XZ      | Return Vector3 as projection of XY plane to XZ |
| (Vector3) XZ2XY      | Return Vector2 as projection of XZ plane to XY. Y value will be ignored |
| (Color) Invert      | Return inverted color |
| (Color) MaxAlpha      | Return the same color with maximum alpha |
| (Color) MinAlpha      | Return the same color with zero alpha |
| (Matrix4x4) ExtractRotation      | Return Quaternion rotation value from transform matrix |
| (Matrix4x4) ExtractPosition      | Return Vector3 position value from transform matrix |
| (Matrix4x4) ExtractScale      | Return Vector3 scale value from transform matrix |

### C# Examples
```C# 
//Get projection of position on XY plane
Vector2 position2D = transform.position.XZ2XY();
```

```C# 
//Health can not be negative, so clamp it.
public float Health
{
	get => _health;
	set => _health = value.ClampPositive();
}
```

## Mathematics
### Methods
| Function name | Description                    |
| ------------- | ------------------------------ |
|GetClosest      | Return closest Transform or other component to target point |
|GetPointsOnCircle      | Return array with points positions |
|GetPointOnCircle      | Return point position on circle by angle |

### C# Examples
```C# 
//Get items around
IInteractable[] items = GetAvailableItems();

//Get closest interactable item to player
Vector3 playerPosition = transform.position;
IInteractable closestItem = Mathematics.GetClosest(playerPosition, items);
```

```C# 
//Get angle between horizontal axes and mouse input
float inputAngle = Vector2.Angle(inputAxes, Vector2.right)

//Set top down crosshair position
_crosshair.transform.position = 
	Mathematics.GetPointOnCircle(
		transform.position, 
		_crosshairDistance,
		inputAngle).
		XY2XZ();
}
```



## Ranges
Serializable int and float ranges stucts for using in inspector or in code.

### Properties
| Property name | Description                    |
| ------------- | ------------------------------ |
|Min      | Clamped from negative infinity to max value |
|Max      | Clamped from min value to positive infinity |


### Methods
| Function name | Description                    |
| ------------- | ------------------------------ |
|IntRange      | Return true if value is in the range|
|Clamp      | Return clamped value to current range|

### C# Examples
```C# 
//Pair attack time range where 0 - first frame of attack, 1 - last frame of attack.
FloatRange parryTime = new FloatRange(0.7f, 0.9f);
```



