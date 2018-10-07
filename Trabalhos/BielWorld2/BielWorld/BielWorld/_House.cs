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

        public _House(GraphicsDevice graphicDevice, Game game)
        {
            Color color = Color.Blue;
            this.game = game;
            this.device = graphicDevice;
            this.world = Matrix.Identity;

            walls = new _Quad[]
            {
                //porta
                new _Quad(this.device, this.game, Color.Red, new Vector3(-1.5f, 3f, 0), new Vector2(3f, 6f), _WallOrientation.South), //porta

                new _Quad(this.device, this.game, color, new Vector3(0,7f,0), new Vector2(3,2), _WallOrientation.South), //parede frente; acima
                new _Quad(this.device, this.game, color, new Vector3(-3.5f,4f,0), new Vector2(4f,8), _WallOrientation.South), //parede frente; esquerda
                new _Quad(this.device, this.game, color, new Vector3(3.5f,4f,0), new Vector2(4f,8f), _WallOrientation.South), //parece frente; direita
                
                //parede esquerda
                new _Quad(this.device, this.game, color, new Vector3(-5.5f,4f,-1.5f), new Vector2(3f,8f), _WallOrientation.West), //parede esquerda; 1
                new _Quad(this.device, this.game, Color.DeepPink, new Vector3(0,4,-1.5f), new Vector2(3f,4f), _WallOrientation.West), //janela esquer,da; 1
                new _Quad(this.device, this.game, Color.DeepPink, new Vector3(0,4,1.5f), new Vector2(3f,4f), _WallOrientation.West), //janela 2
                new _Quad(this.device, this.game, color, new Vector3(-5.5f,4,-11.5f), new Vector2(5f,4f), _WallOrientation.West), // parede meio da esquerda
                new _Quad(this.device, this.game, color, new Vector3(-5.5f,7,-11f), new Vector2(16f,2f), _WallOrientation.West), // parede meio da esquerda
                new _Quad(this.device, this.game, color, new Vector3(-5.5f,1,-11f), new Vector2(16f,2f), _WallOrientation.West), // parede meio da esquerda
                new _Quad(this.device, this.game, color, new Vector3(-5.5f,4,-20.5f), new Vector2(3f,8f), _WallOrientation.West), // parede meio da esquerda
                new _Quad(this.device, this.game, Color.DeepPink, new Vector3(0,-2,0f), new Vector2(5f ,4f), _WallOrientation.West), // janela

                //parede direita
                new _Quad(this.device, this.game, color, new Vector3(5.5f,4f,-1.5f), new Vector2(3f,8f), _WallOrientation.East), //parede  1
                new _Quad(this.device, this.game, Color.DeepPink, new Vector3(0,4,-1.5f), new Vector2(3f,4f), _WallOrientation.East), //janela  1
                new _Quad(this.device, this.game, Color.DeepPink, new Vector3(0,4,1.5f), new Vector2(3f,4f), _WallOrientation.East), //janela 2
                new _Quad(this.device, this.game, color, new Vector3(5.5f,4,-11.5f), new Vector2(5f,4f), _WallOrientation.East), // parede meio
                new _Quad(this.device, this.game, color, new Vector3(5.5f,7,-11f), new Vector2(16f,2f), _WallOrientation.East), // parede meio 
                new _Quad(this.device, this.game, color, new Vector3(5.5f,1,-11f), new Vector2(16f,2f), _WallOrientation.East), // parede meio
                new _Quad(this.device, this.game, color, new Vector3(5.5f,4,-20.5f), new Vector2(3f,8f), _WallOrientation.East), // parede meio
                new _Quad(this.device, this.game, Color.DeepPink, new Vector3(0,-2,0f), new Vector2(5f ,4f), _WallOrientation.East), // janela

                //parede trás
                new _Quad(this.device, this.game, color, new Vector3(0,4,-22f), new Vector2(11f ,8f), _WallOrientation.North), // parede de trás
                new _Quad(this.device, this.game, color, new Vector3(0,8,-11f), new Vector2(11f ,22f), _WallOrientation.Up), // teto
            };
        }

        public void Update(GameTime gameTime)
        {
            foreach (_Quad w in walls)
            {
                w.SetMatrixIndetity();
            }

            //walls[0].CreateTranslation(0, 0, 2f);
            //walls[0].CreateRotation("y", number);
            walls[0].CreateTranslation(1.5f, 0, 0);

            //walls[4].CreateRotation("y", 90f);
            //walls[4].CreateTranslation(0, 4f, 0);
            //walls[4].CreateTranslation(-5.5f, 0, -1.5f);
            
            //translações da janelas da esquerda
            //walls[5].CreateRotation("y", number);
            walls[5].CreateTranslation(-5.5f, 0, -3f);

            //walls[6].CreateRotation("y", -1 * number);
            walls[6].CreateTranslation(-5.5f, 0, -9f);

            //walls[11].CreateRotation("z", -1 * number);
            walls[11].CreateTranslation(-5.5f, 6f, -16.5f);

            //tranlações das janelas da direita
            //walls[13].CreateRotation("y", number);
            walls[13].CreateTranslation(5.5f, 0, -3f);

            //walls[14].CreateRotation("y", -1 * number);
            walls[14].CreateTranslation(5.5f, 0, -9f);

            //walls[19].CreateRotation("z", -1 * number);
            walls[19].CreateTranslation(5.5f, 6f, -16.5f);

            number += 2f;
        }

        public void Draw(_Camera camera)
        {
            foreach(_Quad w in walls)
            {
                w.Draw(camera);
            }
        }

        #region Transforms
        public void CreateTranslation(float x, float y, float z)
        {
            this.world *= Matrix.CreateTranslation(x, y, z);

            foreach (_Quad w in walls)
            {
                w.SetMatrix(this.world);
            }
        }

        public void CreateRotation(_TransformOrientation orient, float valueDegrees)
        {
            float rValue = MathHelper.ToRadians(valueDegrees);
            if (orient == _TransformOrientation.X)
                this.world *= Matrix.CreateRotationX(rValue);

            else if (orient == _TransformOrientation.Y)
                this.world *= Matrix.CreateRotationY(rValue);

            else if (orient == _TransformOrientation.Z)
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
        #endregion
    }
}
