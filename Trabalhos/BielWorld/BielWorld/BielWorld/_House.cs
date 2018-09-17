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

        private _Quad[] walls;

        private float number;

        public _House(GraphicsDevice device, Game game, Vector3 position, Vector2 size)
        {
            Color color = Color.Blue;
            this.game = game;
            this.device = device;
            this.world = Matrix.Identity;

            walls = new _Quad[]
            {
                new _Quad(this.device, this.game, Color.Red, new Vector3(0, 3f, 0), new Vector2(3f,6f)), //porta
                new _Quad(this.device, this.game, color, new Vector3(0,7f,0), new Vector2(3f,2f)), //parede acima
                new _Quad(this.device, this.game, color, new Vector3(-3.5f,4f,0), new Vector2(4f,8f)), //parede esquerda
                new _Quad(this.device, this.game, color, new Vector3(3.5f,4f,0), new Vector2(4f,8f)), //parece direita

                new _Quad(this.device, this.game, Color.Orange, new Vector3(-5.5f,4f,0), new Vector2(3f,8f)) //parede esquerda
            };
            
        }

        public void Update(GameTime gameTime)
        {
            walls[4].CreateRotation("y", 2f);
            number++;
        }

        public void Draw(_Camera camera)
        {
            foreach(_Quad w in walls)
            {
                w.Draw(camera);
            }
        }

    }
}
