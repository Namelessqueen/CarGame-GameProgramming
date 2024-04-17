using GXPEngine.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using TiledMapParser;

internal class PowerUp : Sprite
{
   
    private float travelSpeed = 4;
    Player player;
    float posX;
    float posY;

    public PowerUp(string pFilename = "square.png") : base(pFilename)
    {
        SetOrigin(width / 2, height / 2);
        SetXY((Utils.Random(-1, 2) * Enemy.gridSize),-height);
        scale= 1.2f;
        posX = game.width / 2 + (Utils.Random(-1, 2) * Enemy.gridSize);
        
    }

    protected virtual void Update()
    {
        OffSrceenCheck();
        Move();
    }
    public void OffSrceenCheck()
    {
        if (y - height > game.height)
        {
            Console.WriteLine("Power up deleted");
            LateDestroy();
        }
    }
    public void Move()
    {
        posY += travelSpeed;
        rotation += 0.5f;
        SetXY(posX, posY);
    }
   
}

class TimerPowerUp : PowerUp
{
    private float powerUpTimer;
    private float SecondsOfPowerUp = 5;
    public static bool isTimerActive;
    public TimerPowerUp(string pImage = "Hourglass.png") : base(pImage)
    {

    }
    void Update()
    {
        base.Update();
        PowerUpCooldown();
    }

    public void PowerUpCooldown()
    {
        if (isTimerActive)
        {
            SetXY(game.width - width, game.height - height);
            alpha = 0.8f;
            powerUpTimer += Time.deltaTime / 1000f;
            if (powerUpTimer > SecondsOfPowerUp)
            {
                isTimerActive = false;
                powerUpTimer = 0;
            }
        }
    }
}
class HealtPowerUp : PowerUp
{
    public HealtPowerUp(string pImage = "health.png") : base(pImage)
    {

    }
}
class ShrinkPowerUp : PowerUp
{
    private float powerUpTimer;
    private float SecondsOfPowerUp = 8;
    public static bool isShrinkActive;

    Player player;

    public ShrinkPowerUp(string pImage = "Shrink.png") : base(pImage)
    {
        this.scale = 0.1f;
        player = game.FindObjectOfType<Player>();
    }
  
    void Update()
    {
        base.Update();
        PowerUpCooldown();
    }

    public void PowerUpCooldown()
    {
        if (isShrinkActive)
        {
            SetXY(game.width - width, game.height - height);
            alpha = 0.8f;
            powerUpTimer += Time.deltaTime / 1000f;
            player.scaleX = 0.3f;
            player.scaleY = 0.1f;
            if (powerUpTimer > SecondsOfPowerUp)
            {
                isShrinkActive = false;
                powerUpTimer = 0;
            }
        }
    }
}

