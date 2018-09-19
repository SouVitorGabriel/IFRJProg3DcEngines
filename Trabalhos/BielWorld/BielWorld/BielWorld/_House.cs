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
                new _Quad(this.device, this.game, Color.Red, new Vector3(-1.5f, 0f, 0), new Vector2(3f,6f)), //porta

                new _Quad(this.device, this.game, color, new Vector3(0,7f,0), new Vector2(3f,2f)), //parede frente; acima
                new _Quad(this.device, this.game, color, new Vector3(-3.5f,4f,0), new Vector2(4f,8f)), //parede frente; esquerda
                new _Quad(this.device, this.game, color, new Vector3(3.5f,4f,0), new Vector2(4f,8f)), //parece frente; direita

                new _Quad(this.device, this.game, Color.Orange, new Vector3(0,0,0), new Vector2(3f,8f)), //parede esquerda; 1
                new _Quad(this.device, this.game, Color.HotPink, new Vector3(0,0,0), new Vector2(3f,4f)) //janela esquerda; 1

            };
        }

        public void Update(GameTime gameTime)
        {
            foreach (_Quad w in walls)
            {
                w.SetMatrixIndetity();
            }

            walls[0].SetMatrixIndetity();
            walls[0].CreateTranslation(0, 3f, 0);
            walls[0].CreateRotation("y", number);
            walls[0].CreateTranslation(1.5f, 0, 0);
            
            walls[4].SetMatrixIndetity();
            walls[4].CreateRotation("y", 90f);
            walls[4].CreateTranslation(0, 4f, 0);
            walls[4].CreateTranslation(-5.5f, 0, -1.5f);
            
            walls[5].SetMatrixIndetity();
            walls[5].CreateRotation("y", 90f);
            walls[5].CreateTranslation(0, 4f, 0);
            walls[5].CreateTranslation(-5.5f, 0, -4.5f);
            //walls[0].CreateTranslation(2.75f, 0, 0);
            number += 2f;
        }

        public void Draw(_Camera camera)
        {
            foreach(_Quad w in walls)
            {
                w.Draw(camera);
            }
        }

        public void CreateTranslation(float x, float y, float z)
        {
            this.world *= Matrix.CreateTranslation(x, y, z);

            foreach (_Quad w in walls)
            {
                w.SetMatrix(this.world);
            }
        }

        public void CreateRotation(string orient, float value)
        {
            float rValue = MathHelper.ToRadians(value);
            if (orient == "x" || orient == "X")
                this.world *= Matrix.CreateRotationX(rValue);

            else if (orient == "y" || orient == "Y")
                this.world *= Matrix.CreateRotationY(rValue);

            else if (orient == "z" || orient == "Z")
                this.world *= Matrix.CreateRotationZ(rValue);

            foreach (_Quad w in walls)
            {
                w.SetMatrix(this.world);
            }
        }

        public void CreateScale(float x, float y, float z)
        {
            this.world *= Matrix.CreateScale(x, y, z);

            foreach (_Quad w in walls)
            {
                w.SetMatrix(this.world);
            }
        }

        public void SetMatrix(Matrix matrix)
        {
            this.world = this.world * matrix;
        }

        public void SetMatrixIndetity()
        {
            this.world = Matrix.Identity;
        }
    }
}
