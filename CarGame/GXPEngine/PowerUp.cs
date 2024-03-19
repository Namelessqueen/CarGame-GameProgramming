using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
    internal class PowerUp : Sprite
    {
        public static bool isPowerUpActive;
        private float powerUpTimer;
        private float SecondsOfPowerUp = 5;
        private float travelSpeed = 4;
        float posX;
        float posY;
        public PowerUp() : base("Hourglass.png")
        {
            SetOrigin(width / 2, height / 2);
            SetXY((Utils.Random(-1, 2) * Enemy.gridSize),-height);
            scale= 1.2f;
            posX = game.width / 2 + (Utils.Random(-1, 2) * Enemy.gridSize);
        }
        
        void Update()
        {
            OffSrceenCheck();
            PowerUpPowers();

        }

        void PowerUpPowers()
        {
            posY += travelSpeed;
            rotation += 0.5f;
            SetXY(posX, posY);

            if (isPowerUpActive)
            {
                SetXY(game.width - width, game.height -  height);
                scale = 3f;
                alpha = 0.8f;
                powerUpTimer += Time.deltaTime / 1000f;

                if (powerUpTimer > SecondsOfPowerUp)
                {
                    isPowerUpActive = false;
                    powerUpTimer = 0;
                    Destroy();
                }
            }
        }
        void OffSrceenCheck()
        {
            if (y - height > game.height)
            {
                LateDestroy();
            }
        }

    }
}
