using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
    internal class LevelData
    {
        int currentPoints;
        int currentHealth;
        int levels;
        public int PointChange(int pChange)
        {
            int Change = pChange;
            currentPoints += Change;
            return currentPoints;
            
        }
        public int healthChange(int pChange)
        {
            int Change = pChange;
            currentHealth += Change;
            return currentHealth;

        }
        public int Level()
        {
            return levels;
        }
    }
}
