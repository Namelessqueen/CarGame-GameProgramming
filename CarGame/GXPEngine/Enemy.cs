using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

using GXPEngine;
using GXPEngine.Core;


internal class Enemy : AnimationSprite
{
   Vector2 position;
    public static float gridSize = 130;
    float speed = 2 + ((float)Utils.Random(1, 3)/10);
    private float powerUpSpeed;

    canvas canvas = null;

    public Enemy(Vector2 pPosition) : base("enemy_cars.png",3,1)
    {
        position = pPosition;
        SetXY(-250, -250);
        SetOrigin(width / 2, height / 2);
        this.scale = 0.5f;
        this.rotation = 180;
        SetFrame(Utils.Random(0,3));
       //posX = game.width / 2 + (Utils.Random(-1, 2) * gridSize);
    }
    void Update()
    {
        if (canvas == null) canvas = game.FindObjectOfType<canvas>();
        OffScreenCheck();
        SetXY(position.x, position.y);
        position.y += speed * powerUpSpeed * (1+canvas.levelChange(0)/5);
        if (TimerPowerUp.isTimerActive) powerUpSpeed = 0.5f;
        else  powerUpSpeed = 1f;
    }

    void OffScreenCheck()
    {
        if(y - height > game.height)
        {
            canvas.pointsChange(1);
            LateDestroy();
        }
    }
}
internal class EnemySegmants : GameObject
{

    public static float gridSize = 130;
    int segmantCase;

    public EnemySegmants(int pSegmantCase)
    {
        segmantCase = pSegmantCase;
        Segmants();
    }

    void Segmants()
    {
        switch (segmantCase)
        {
            case 0:
                // The number times the grid size is wich lane (number from -1 to 1)
                AddChild(new Enemy(new Vector2(game.width/2 + (-1 * gridSize), -100)));
                AddChild(new Enemy(new Vector2(game.width / 2 + (0 * gridSize), -275)));

                break;
            case 1:
                // The number times the grid size is wich lane (number from -1 to 1)
                AddChild(new Enemy(new Vector2(game.width / 2 + (1 * gridSize), -100)));
                AddChild(new Enemy(new Vector2(game.width / 2 + (0 * gridSize), -275)));

                break;
            case 2:
                // The number times the grid size is wich lane (number from -1 to 1)
                AddChild(new Enemy(new Vector2(game.width / 2 + (1 * gridSize), -100)));
                AddChild(new Enemy(new Vector2(game.width / 2 + (0 * gridSize), -275)));
                AddChild(new Enemy(new Vector2(game.width / 2 + (1 * gridSize), -400)));
                AddChild(new Enemy(new Vector2(game.width / 2 + (-1 * gridSize), -700)));

                break;
            case 3:
                // The number times the grid size is wich lane (number from -1 to 1)
                AddChild(new Enemy(new Vector2(game.width / 2 + (-1 * gridSize), -100)));
                AddChild(new Enemy(new Vector2(game.width / 2 + (0 * gridSize), -275)));
                AddChild(new Enemy(new Vector2(game.width / 2 + (-1 * gridSize), -400)));
                AddChild(new Enemy(new Vector2(game.width / 2 + (1 * gridSize), -700)));
                break;
            case 4:
                // The number times the grid size is wich lane (number from -1 to 1)
                AddChild(new Enemy(new Vector2(game.width / 2 + (-1 * gridSize), -100)));
                AddChild(new Enemy(new Vector2(game.width / 2 + (1 * gridSize), -100)));

                break;
            case 5:
                // The number times the grid size is wich lane (number from -1 to 1)
                AddChild(new Enemy(new Vector2(game.width / 2 + (-1 * gridSize), -350)));
                AddChild(new Enemy(new Vector2(game.width / 2 + (-1 * gridSize), -100)));
                break;
            case 6:
                // The number times the grid size is wich lane (number from -1 to 1)
                AddChild(new Enemy(new Vector2(game.width / 2 + (0 * gridSize), -350)));
                AddChild(new Enemy(new Vector2(game.width / 2 + (0 * gridSize), -100)));
                break;
            case 7:
                // The number times the grid size is wich lane (number from -1 to 1)
                AddChild(new Enemy(new Vector2(game.width / 2 + (1 * gridSize), -350)));
                AddChild(new Enemy(new Vector2(game.width / 2 + (1 * gridSize), -100)));
                break;
        }
    }
}



