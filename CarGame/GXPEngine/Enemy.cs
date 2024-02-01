using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

using GXPEngine;


internal class Enemy : AnimationSprite
{
    float posX;
    float posY = -100; 
    public static float gridSize = 130;
    float speed = 2 + (Utils.Random(1, 3)/2);
    private float powerUpSpeed;

    public Enemy() : base("enemy_cars.png",3,1)
    {
        SetXY(-250, -250);
        SetOrigin(width / 2, height / 2);
        this.scale = 0.5f;
        this.rotation = 180;
        SetFrame(Utils.Random(0,3));
        posX = game.width / 2 + (Utils.Random(-1, 2) * gridSize);
    }
    public void Update()
    {
        OffScreenCheck();
        SetXY(posX, posY);
        posY += speed * powerUpSpeed;
        if (PowerUp.isPowerUpActive)
        {
            powerUpSpeed = 0.5f;
        }
        else
        {
            powerUpSpeed = 1f;
        }
        
    }

    void OffScreenCheck()
    {
        //LevelData data = ((MyGame)game).LevelData;
        if(y - height > game.height)
        {
            //LevelData.point++;
            LateDestroy();
        }
    }
}
