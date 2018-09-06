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
        int maxX = 300;
        public Player(ContentManager content, string path, Point position, Point size) : base (content, path, position, size)
        {

        }

        public override void Update(GameTime gameTime)
        {
            Move(gameTime);

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {

            }
        }

        public void Move(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                collider.X -= 1 * gameTime.ElapsedGameTime.Milliseconds / 10;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                collider.X += 1 * gameTime.ElapsedGameTime.Milliseconds / 10;
            }

            if (collider.X > maxX)
                collider.X = maxX;

            if (collider.X < minX)
                collider.X = minX;
        }

        public void Jump()
        {

        }
    }
}
