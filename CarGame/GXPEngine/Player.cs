using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GXPEngine;
using TiledMapParser;

internal class Player : Sprite
{
    private float Speed = 6;
    float colorTimer;
    bool isHit = false;
    bool isHealth = false;

    canvas canvas = null;

    Sound crashSound;
    Sound healthSound;
    SoundChannel channel;



    public Player() : base("pink_cars.png")
    {
        SetOrigin(width/2, height/2);
        SetXY(game.width / 2, game.height / 1.5f);
        crashSound = new Sound("clank-car-crash-collision-6206.mp3");
        healthSound = new Sound("coin-upaif-14631.mp3");

    }


    void Update()
    {
       if(canvas == null) canvas = game.FindObjectOfType<canvas>();
        movement();
        collisionPlayer();
        ColorChange();
        ScaleChange();
        SFX();
    }

    void movement()
    {
        //SetXY(posX, posY);
        float distPlayerX = game.width / 2 - x;
        float distEdge = Enemy.gridSize + 20;

            if (Input.GetKey(Key.LEFT) && distPlayerX < distEdge)
            {Move(-Speed, 0);}
            if (Input.GetKey(Key.RIGHT) && -distPlayerX < distEdge)
            { Move(Speed, 0);}
            if (Input.GetKey(Key.UP) && 0 < y - height/2)
            { Move(0, -Speed); }
            if (Input.GetKey(Key.DOWN) && game.height > y + height / 2)
            { Move(0, Speed); }

    }
    
    void collisionPlayer()
    {
        GameObject[] collisions = GetCollisions();
        for (int i = 0; i < collisions.Length; i++)
        {
            GameObject col = collisions[i];

            if(col is Enemy)
            {
                canvas.healthChange(-1);
                col.LateDestroy();
                isHit = true;
            }
            else if(col is TimerPowerUp)
            {
                TimerPowerUp Timer = (TimerPowerUp)col;
                TimerPowerUp.isTimerActive = true;
            }
            else if (col is HealtPowerUp)
            {
                HealtPowerUp Health = (HealtPowerUp)col;
                canvas.healthChange(1);
                Health.LateDestroy();
                isHealth = true;
            }
            else if (col is ShrinkPowerUp)
            {
                ShrinkPowerUp Shrink = (ShrinkPowerUp)col;
                ShrinkPowerUp.isShrinkActive = true;

            }
        }
    }

    void SFX()
    {
        if (isHit) { channel = crashSound.Play(); channel.Volume = 0.5f; }

        if(isHealth) healthSound.Play(); isHealth = false;
    }
    void ScaleChange()
    {
        this.scaleX = 0.5f;
        this.scaleY = 0.3f;
    }
    void ColorChange()
    {

        if (isHit == true)
        {
            colorTimer += Time.deltaTime / 1000f;
            this.SetColor(255, 0, 0);
            

            if (colorTimer > 0.2f)
            {
                colorTimer = 0;
                isHit = false;
            }
        }
        else this.SetColor(1, 1, 1);
    }

}


