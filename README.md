# unity-third-person-camera
Unity Third Person Camera Script (C#). Compatible with Unity 5.x and newer versions (as of now up to 2020.3 LTS). Customizable and automatically collide camera with nearest wall so it can always show player

# Usage
If your player character/object is named **Player** for example. Then you will have to create an empty GameObject as a child of **Player**. You can name it anything. But it will be considered as **Screw** (which rotates around Y axis that's why called **Screw**). Again create an empty GameObject child of **Screw** which will be considered as **Handle**.(It moves around the X axis and it's a bit like the handle of machine gun or telescope which is why it's called **Handle**). Create another and final empty GameObject **CameraPlaceholder** (you can rename it to anything) and change it's position to the initial position of the camera (where you want the camera at it's initial position).

After that, add the script to player object. From the inspector set all the parameters according to your need. They are self-explanatory
