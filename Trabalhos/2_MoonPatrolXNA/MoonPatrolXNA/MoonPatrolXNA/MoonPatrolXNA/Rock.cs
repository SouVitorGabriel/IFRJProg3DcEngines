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
    class Rock : GameObject
    {
        public Rock(ContentManager content, string texturePath, Point position, Point size)  : base (content, texturePath, position, size)
        {

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            this.SetPositionX(Position.X - gameTime.ElapsedGameTime.Milliseconds / 5);
        }
    }
}
