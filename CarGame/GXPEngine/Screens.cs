using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GXPEngine;

internal class Screens : GameObject
{
    EasyDraw easydraw;
    Background background;
    Sprite titleText;
    string _image;


    public static Font gameFont = new Font("Pixelify Sans", 15);

    public Screens(string Image = "square.png", float scale = 1) : base() 
    {
         Font gameFont = new Font("Pixelify Sans", 15);
         titleText = new Sprite("Car-Game-17-4-2024 (2).png", false, false);
        
        _image = Image;
        background = new Background(Image, scale);
        easydraw = new EasyDraw(game.width, game.height);
        easydraw.TextAlign(CenterMode.Center, CenterMode.Center);
        easydraw.ShapeAlign(CenterMode.Center, CenterMode.Center);
        easydraw.TextFont(gameFont);
        easydraw.TextSize(30);

        titleText.SetOrigin(titleText.width / 2, 0);
        titleText.scale = 0.6f;
        titleText.SetXY(game.width/2, 0);

        AddChild(easydraw);
    }

 
    void Update()
    {
       
        int textAlpha = (int)(255 * Mathf.Abs(Mathf.Cos(Time.time / 700f)));

        easydraw.DrawSprite(background); easydraw.Stroke(0); easydraw.StrokeWeight(3); 
        easydraw.Fill(255);  easydraw.Rect(game.width / 2, game.height - 50,550,50); 
        easydraw.Fill(0, textAlpha);

        if (_image == "BeginScreen.jpeg") { easydraw.DrawSprite(titleText); easydraw.Text("Press Space to start", game.width / 2, game.height - 50); }
        else if (_image == "EndScreen.jpg"){ easydraw.Text("Press Space to try again", game.width / 2, game.height - 50); }
        else return;

        if (Input.GetKeyDown(Key.SPACE))
        {
            MyGame _game = game.FindObjectOfType<MyGame>();
            _game.loadLevel();
        }
    }
}

