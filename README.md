# CAVEPainter
CAVE painter using networking with Unity.
Unity version: 5.3.5f1 (64 bits)

# Instructions to execute:
1. Open the project in the Unity editor and play it.
2. Create a server using the button "LAN Host".
3. Connect clients using the button "LAN Client (C)".
	- Set the host ip in the field next to the button (default "localhost").
4. Move around using the arrow keys.
5. Start painting using the key "1".
6. Optional: Stop the application using the key "Q".

# Changelog
* Networking added:
	- Host/Client created.

* Shourtcut added to paint:
	- Key: 1

* Brush painters created on server and clients using Unity networking.
	- To replicate the brush on the network the spline nodes information is send to the server and clients in the player behavior.

* Leap motion controller plugin added:
	- Use pinch gesture to paint with the playground spline.
	
* Assest updated:
	- getReal3D
	- Particle Playground

# Notes
* Initial version based on the CAVE painter created at the SER.

* The old components are inactive just for reference before deleting them.
	- old_Directional light
	- old_getRealPlayerController

* The main classes to replicate the brush behaviour using networking are:
	- PlayerBehaviour.cs
	- EmitWhileMoving.cs
	- BrushBehaviour
	
# TODO
* Check bugs for getReal3D plugin:
	- Spline nodes information isn't being sent to the networking server, and it's not being replicated on the clients.