using System;                                   // System contains a lot of default C# libraries 
using GXPEngine;                                // GXPEngine contains the engine
using System.Drawing;
using System.IO;                           // System.Drawing contains drawing tools such as Color definitions

public class MyGame : Game {

	Player player;
    float nextCar = 0;
    public MyGame() : base(800, 600, false, false, 1200,900)     
	{
		EasyDraw canvas = new EasyDraw(800, 600, false);
		player = new Player();
		Background lanes = new Background("lanes.jpg", 1.2f);
        Background grass = new Background("Grass.png", 1.5f);

       
        player.SetXY(width / 2, height - player.height);

        AddChild(grass);
        AddChild(lanes);
        AddChild(canvas);
        AddChild(player);
        Console.WriteLine("MyGame initialized");
	}

	void Update() 
	{

        SpawnEnemy();
        SpawnPowerUp();
    }

	void SpawnEnemy()
	{
        nextCar += Time.deltaTime / 1000f;
        if (nextCar > 3f)
        {
            Enemy enemy = new Enemy();
            AddChild(enemy);
            Console.WriteLine("new car");
            nextCar = 0;
        }
    }
    void SpawnPowerUp()
    {
        if(Input.GetKeyDown(Key.SPACE))
        {
            PowerUp powerUp = new PowerUp(1);
            AddChild(powerUp);
        }
    }


    static void Main()                          // Main() is the first method that's called when the program is run
	{
		new MyGame().Start();                   // Create a "MyGame" and start it
	}
}