using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GXPEngine;

internal class Player : Sprite
{
    private float Speed = 6;
    public Player() : base("pink_cars.png")
    {
        SetOrigin(width/2, height/2);
        this.scaleX = 0.5f;
        this.scaleY = 0.35f;

          
    }
    void Update()
    {
        movement();
        collisionPlayer();


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
                //Console.WriteLine("GAME OVER");
            }
            else if(col is PowerUp)
            {
                PowerUp PowerUp = (PowerUp)col;
                PowerUp.isPowerUpActive = true;
                PowerUp.SetXY(0,0);
            }
        }

    }


}


