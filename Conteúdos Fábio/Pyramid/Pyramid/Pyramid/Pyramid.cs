using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pyramid
{
    public class Pyramid
    {
        VertexPositionColor[] verts;
        VertexBuffer vBuffer;

        Matrix world;

        short[] index;
        IndexBuffer iBuffer;

        Game game;

        BasicEffect effect;

        //sentido horario (mão)

        public Pyramid(Game game)
        {
            this.game = game;

            this.verts = new VertexPositionColor[]
            {
                new VertexPositionColor(new Microsoft.Xna.Framework.Vector3(0,1,0), Color.DarkOrange),
                new VertexPositionColor(new Microsoft.Xna.Framework.Vector3(-1,0,1), Color.DarkOrange),
                new VertexPositionColor(new Microsoft.Xna.Framework.Vector3(1,0,1), Color.DarkOrange),
                new VertexPositionColor(new Microsoft.Xna.Framework.Vector3(1,0,-1), Color.DarkOrange),
                new VertexPositionColor(new Microsoft.Xna.Framework.Vector3(-1,0,-1), Color.DarkOrange)
            };


            this.vBuffer.SetData<VertexPositionColor>(this.verts);

            index = new short[]
            {
                0,2,1,
                0,3,2,
                0,4,3,
                0,1,4,
                1,2,3,
                1,3,4,
            };

            iBuffer = new IndexBuffer(game.GraphicsDevice, IndexElementSize.SixteenBits

            this.world = Matrix.Identity;
            this.effect = new BasicEffect;
        }

        public void Update()
        {

        }


        public void Draw()
        {
            effect.World = this.world;
        }

    }
}