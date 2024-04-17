using System;                                   // System contains a lot of default C# libraries 
using GXPEngine;                                // GXPEngine contains the engine
using System.Drawing;
using System.IO;
using System.Collections.Generic;                           // System.Drawing contains drawing tools such as Color definitions

public class MyGame : Game {

    Screens beginScreen;

    Sound gameOver;
    SoundChannel channel;

    public MyGame() : base(800, 600, false, false, 1200,900)     
	{
        beginScreen = new Screens("BeginScreen.jpeg", 0.8f);
        gameOver = new Sound("videogame-death-sound-43894.mp3");

        AddChild(beginScreen);

        Console.WriteLine("MyGame initialized");

	}

    void DestroyAll()
    {
        List<GameObject> list = GetChildren();
        foreach (GameObject obj in list)
        {
            obj.Destroy();
        }
    }

    public void loadLevel()
    {
        DestroyAll();
        if (channel != null) channel.Stop();
        AddChild(new Level());
        AddChild(new canvas());
    }

    public void Gameover()
    {
        DestroyAll();
        AddChild(new Screens("EndScreen.jpg", 0.9f));
        channel = gameOver.Play();
    }

    static void Main()                          // Main() is the first method that's called when the program is run
	{
		new MyGame().Start();                   // Create a "MyGame" and start it
	}
}