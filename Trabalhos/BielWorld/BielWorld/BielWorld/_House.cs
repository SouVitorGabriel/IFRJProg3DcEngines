using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BielWorld
{
    public class _House
    {
        private Game game;
        private GraphicsDevice device;
        private Matrix world;

        public _House(GraphicsDevice device, Game game, Vector3 position, Vector2 size)
        {
            this.game = game;
            this.device = device;
            this.world = Matrix.Identity;

        }

        public void Draw()
        {

        }

    }
}
