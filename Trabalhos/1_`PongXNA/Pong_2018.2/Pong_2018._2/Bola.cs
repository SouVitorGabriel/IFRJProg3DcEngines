using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pong_2018._2
{
    class Bola
    {
        float x, y, speedX, speedY;
        public Texture2D textura { get; set; }
        Game game;
        public Bola(float x, float y, int speedX, float speedY, Game game)
        {
            this.x = x;
            this.y = y;
            this.speedX = speedX;
            this.speedY = speedY;
            this.game = game;
        }

        public void Update()
        {

        }

        public void Draw()
        {

        }

    }
}
