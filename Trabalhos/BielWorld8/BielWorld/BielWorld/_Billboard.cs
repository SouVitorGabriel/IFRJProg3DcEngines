using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BielWorld
{
    public class _Billboard : _Quad
    {
        private float distance;
        private Vector3 center;

        public _Billboard(GraphicsDevice device, Game game, string textureName, string texture2Name, Vector3 position, Vector2 size, _WallOrientation orientation) 
            : base(device, game, textureName, texture2Name, position, size, orientation)
        {

        }

        public void Update(_Camera camera)
        {
            distance = Vector3.Distance(camera.getPosition(), center);

            world = Matrix.Identity;
            world = Matrix.CreateRotationY(MathHelper.ToRadians(camera.getRotation().Y));
            CreateTranslation(center.X, center.Y, center.Z);
        }

        public float getDistance()
        {
            return this.distance;
        }

        public void setCenter(Vector3 center)
        {
            this.center = center;
        }
    }
}
