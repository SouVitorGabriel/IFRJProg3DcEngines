using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace MoonPatrolXNA
{
    class Player : GameObject
    {
        int minX = 50;
        int maxX = 600;

        bool jumping = false;

        float jumpForce = 0;
        float inicialPositionY = 0;
        public Player(ContentManager content, string path, Point position, Point size) : base (content, path, position, size)
        {
            inicialPositionY = position.Y;
        }

        public override void Update(GameTime gameTime)
        {
            Move(gameTime);

            if (Keyboard.GetState().IsKeyDown(Keys.Up) && !jumping)
            {
                Jump();

            }
            if (jumping)
            {
                this.SetPositionY(Position.Y - (int)(jumpForce * gameTime.ElapsedGameTime.TotalSeconds));
                jumpForce -= 200 * (float)gameTime.ElapsedGameTime.TotalSeconds;
                Console.WriteLine("força: " + jumpForce);

                if ((int)(jumpForce * gameTime.ElapsedGameTime.TotalSeconds) < 1
                    && jumpForce > -1)
                {
                    jumpForce = -1;
                }

                if (Position.Y > inicialPositionY)
                {
                    SetPositionY( (int)inicialPositionY);
                    jumping = false;
                    jumpForce = 0;
                }
            }
        }

        public void Move(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                this.SetPositionX(Position.X - gameTime.ElapsedGameTime.Milliseconds / 10);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                this.SetPositionX(Position.X + gameTime.ElapsedGameTime.Milliseconds / 10);
            }

            if (Position.X > maxX)
                this.SetPositionX(maxX);

            if (Position.X < minX)
                this.SetPositionX(minX);
        }

        public void Jump()
        {
            jumping = true;
            jumpForce = 200;
        }
    }
}
