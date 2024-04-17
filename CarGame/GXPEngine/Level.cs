using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiledMapParser;
using GXPEngine;

internal class Level : GameObject
{
    Player player;
    float nextCar = 5f;
    float powerUpsTimer = 0;

    canvas canvas = null;
    Sound music;
    int mainFrequency;
    public SoundChannel channel;
    Background grassImage;

    public Level() 
    {
        
        player = new Player();
        Background lanesImage = new Background("lanes.jpg", 1.2f);
        grassImage = new Background("Grass.png", 1.5f);

        player.SetXY(game.width / 2, game.height - player.height);

        AddChild(grassImage);
        AddChild(lanesImage);
        AddChild(player);

        music = new Sound("music-for-arcade-style-game-146875.mp3", true);
        channel = music.Play();
    }

    void Update()
    {
        if (canvas == null) canvas = game.FindObjectOfType<canvas>();
        SFX();
        SpawnEnemy();
        SpawnPowerUp();
    }

    void SFX()
    {
        channel.Volume = 0.1f;
        mainFrequency = 44100 + 500*canvas.levelChange(0);
        if (TimerPowerUp.isTimerActive) channel.Frequency = mainFrequency/2;
        else if (ShrinkPowerUp.isShrinkActive) channel.Frequency = mainFrequency * 1.15f;
        else channel.Frequency = mainFrequency;
        

    }

    void SpawnEnemy()
    {
        nextCar += Time.deltaTime / 1000f;
        if (nextCar > 7f - (float)canvas.levelChange(0) / 3)
        {
            EnemySegmants enemy = new EnemySegmants(Utils.Random(0, 8));
            AddChild(enemy);
            Console.WriteLine("new car");
            nextCar = 0;
        }
            
    }
    void SpawnPowerUp()
    {
        if(!ShrinkPowerUp.isShrinkActive && !TimerPowerUp.isTimerActive) powerUpsTimer += Time.deltaTime / 1000f;
        Random rand = new Random();
        int number = rand.Next(1, 4);
        if (powerUpsTimer > 12f)
        {
            if (number == 1)
            {
                TimerPowerUp timerPowerUp = new TimerPowerUp();
                AddChild(timerPowerUp);
            }
            if (number == 2)
            {
                HealtPowerUp PowerUp = new HealtPowerUp();
                AddChild(PowerUp);
            }
            if(number == 3)
            {
                ShrinkPowerUp PowerUp = new ShrinkPowerUp();
                AddChild(PowerUp);
            }
            powerUpsTimer = 0;
        }
           
    }
}

