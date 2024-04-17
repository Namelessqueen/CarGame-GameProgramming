using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

using GXPEngine;
using TiledMapParser;

internal class canvas : EasyDraw
{
    Player player;
    Level level;

    public int currentHealth = 3;
    int currentLevel = 1;
    int currentpoints = 0;

    float alphaTimer;
    public bool alphaBool = false;
    int textAlpha = 255;

    int textY = 30;

    public static Font gameFont = new Font("Pixelify Sans", 16);

    public canvas() : base(Game.main.width, Game.main.height)
    {

    }
     
    void Update()
    {
        player = game.FindObjectOfType<Player>();
        level = game.FindObjectOfType<Level>();
        if (player == null) return;
        TextFont(gameFont);
        TextAlign(CenterMode.Center, CenterMode.Center);
        ShapeAlign(CenterMode.Center, CenterMode.Center);


        HealthText();
        if(currentHealth < 1)
        {
            ((MyGame)game).Gameover();
            level.channel.Stop();
            TimerPowerUp.isTimerActive = false;
            ShrinkPowerUp.isShrinkActive = false;
        }
        PointsText();
        levelText();
        AplhaChange();
    }

    void HealthText()
    {
        
        Fill(0,255,0); Rect(60, textY, 110,30);
        Fill(0); Text("Health: " + healthChange(0), 60, textY);
    }

    void PointsText()
    {
        Fill(0,255,0); Rect(game.width - 60, textY, 110,30);
        Fill(0); Text("Points: " + pointsChange(0), game.width-60, textY);
    }

    void levelText()
    {
        Fill(0, 255, 0); Rect(game.width/2, textY, 100, 30);
        Fill(0, textAlpha); Text("Level: " + levelChange(0), game.width/2, textY);

        if (pointsChange(0) > Mathf.Pow(levelChange(0),2))
        {
            levelChange(1);
            alphaBool = true;
        }
    }

    void AplhaChange()
    {
        if (alphaBool == true)
        {
            alphaTimer += Time.deltaTime / 1000f;
            textAlpha = (int)(255 * Mathf.Abs(Mathf.Cos(Time.time / 700f)));
            if (alphaTimer > 5)
            {
                alphaTimer = 0;
                alphaBool = false;
            }
        }
        else textAlpha = 255;
    }

    public int healthChange(int pChange)
    {
        int Change = pChange;
        currentHealth += Change;
        return currentHealth;
    }

    public int levelChange(int pChange)
    {
        int Change = pChange;
        currentLevel += Change;
        return currentLevel;
    }

    public int pointsChange(int pChange)
    {
        int Change = pChange;
        currentpoints += Change;
        return currentpoints;
    }
}

