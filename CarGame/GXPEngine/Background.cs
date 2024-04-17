using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GXPEngine;

internal class Background : Sprite
{
    public Background(string ImageFile, float pScale) : base(ImageFile, false, false)
    {

        SetOrigin(width / 2, height / 2);
        this.scale = pScale;
        SetXY(game.width/ 2, game.height / 2);
    }
}

