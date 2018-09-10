using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace MoonPatrolXNA
{
    class Pedra : GameObject
    {
        public Pedra(ContentManager content, string texturePath, Point position, Point size)  : base (content, texturePath, position, size)
        {

        }
    }
}
