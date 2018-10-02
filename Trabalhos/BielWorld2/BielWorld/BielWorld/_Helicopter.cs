using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BielWorld
{
    public class _Helicopter
    {
        private Game game;
        private GraphicsDevice device;
        private Matrix world;

        private _Quad[] sides;

        private _Helix backHelix, topHelix;

        private float angle;

        public _Helicopter(GraphicsDevice graphicDevice, Game game)
        {
            Color color = Color.Blue;
            this.game = game;
            this.device = graphicDevice;
            this.world = Matrix.Identity;

            this.sides = new _Quad[]
            {
                new _Quad(this.device, this.game, Color.DarkMagenta, new Vector3(0, 5.5f, 0), new Vector2(10, 5), _WallOrientation.South), //frente
                new _Quad(this.device, this.game, Color.LightCyan, new Vector3(0, 0, 0), new Vector2(10, 4.2f), _WallOrientation.South), //frente vidro
                new _Quad(this.device, this.game, Color.DarkGray, new Vector3(3.5f, 0.5f, -1), new Vector2(2, 1), _WallOrientation.South), //pe direito
                new _Quad(this.device, this.game, Color.DarkGray, new Vector3(-3.5f, 0.5f, -1), new Vector2(2, 1), _WallOrientation.South), //esquerdo
                new _Quad(this.device, this.game, Color.DarkGray, new Vector3(3.5f, 2, -4), new Vector2(1, 2), _WallOrientation.South),
                new _Quad(this.device, this.game, Color.DarkGray, new Vector3(-3.5f, 2, -4), new Vector2(1, 2), _WallOrientation.South),
                //lado esquerdo
                new _Quad(this.device, this.game, Color.DarkMagenta, new Vector3(-5, 5.5f, -6), new Vector2(12, 5), _WallOrientation.West),
                new _Quad(this.device, this.game, Color.DarkMagenta, new Vector3(-5, 9.5f, -7.5f), new Vector2(9, 3), _WallOrientation.West),
                new _Quad(this.device, this.game, Color.DarkMagenta, new Vector3(0,0,0), new Vector2(3.5f, 4.2f), _WallOrientation.West), //[8]
                new _Quad(this.device, this.game, Color.DarkGray, new Vector3(-4f, 2, -6), new Vector2(4, 2), _WallOrientation.West), //pes
                new _Quad(this.device, this.game, Color.DarkGray, new Vector3(-4.5f, 0.5f, -6), new Vector2(10, 1), _WallOrientation.West),
                new _Quad(this.device, this.game, Color.DarkGray, new Vector3(3f, 2, -6), new Vector2(4, 2), _WallOrientation.West),
                new _Quad(this.device, this.game, Color.DarkGray, new Vector3(2.5f, 0.5f, -6), new Vector2(10, 1), _WallOrientation.West),
               // 
                //lado direito
                new _Quad(this.device, this.game, Color.DarkMagenta, new Vector3(5, 5.5f, -6), new Vector2(12, 5), _WallOrientation.East),
                new _Quad(this.device, this.game, Color.DarkMagenta, new Vector3(5, 9.5f, -7.5f), new Vector2(9, 3), _WallOrientation.East),
                new _Quad(this.device, this.game, Color.DarkMagenta, new Vector3(0,0,0), new Vector2(3.5f, 4.2f), _WallOrientation.East), //[15]
                new _Quad(this.device, this.game, Color.DarkGray, new Vector3(4f, 2, -6), new Vector2(4, 2), _WallOrientation.East), //pes
                new _Quad(this.device, this.game, Color.DarkGray, new Vector3(4.5f, 0.5f, -6), new Vector2(10, 1), _WallOrientation.East),
                new _Quad(this.device, this.game, Color.DarkGray, new Vector3(-3f, 2, -6), new Vector2(4, 2), _WallOrientation.East),
                new _Quad(this.device, this.game, Color.DarkGray, new Vector3(-2.5f, 0.5f, -6), new Vector2(10, 1), _WallOrientation.East),

                 new _Quad(this.device, this.game, Color.DarkGray, new Vector3(3.5f, 0.5f, -11), new Vector2(2, 1), _WallOrientation.North), //pe direito
                new _Quad(this.device, this.game, Color.DarkGray, new Vector3(-3.5f, 0.5f, -11), new Vector2(2, 1), _WallOrientation.North), //esquerdo
                new _Quad(this.device, this.game, Color.DarkGray, new Vector3(3.5f, 2, -8), new Vector2(1, 2), _WallOrientation.North),
                new _Quad(this.device, this.game, Color.DarkGray, new Vector3(-3.5f, 2, -8), new Vector2(1, 2), _WallOrientation.North),

                new _Quad(this.device, this.game, Color.DarkGray, new Vector3(-3.5f, 1, -6), new Vector2(2, 10), _WallOrientation.Up),
                new _Quad(this.device, this.game, Color.DarkGray, new Vector3(3.5f, 1, -6), new Vector2(2, 10), _WallOrientation.Up),

                new _Quad(this.device, this.game, Color.DarkGray, new Vector3(-3.5f, 0, -6), new Vector2(2, 10), _WallOrientation.Down),
                new _Quad(this.device, this.game, Color.DarkGray, new Vector3(3.5f, 0, -6), new Vector2(2, 10), _WallOrientation.Down),

                new _Quad(this.device, this.game, Color.DarkGray, new Vector3(-3.5f, 1, -6), new Vector2(2, 10), _WallOrientation.Down),
                new _Quad(this.device, this.game, Color.DarkGray, new Vector3(3.5f, 1, -6), new Vector2(2, 10), _WallOrientation.Down),

                new _Quad(this.device, this.game, Color.DarkMagenta, new Vector3(0, 7f, -12), new Vector2(10, 8), _WallOrientation.North), //atras do 

                new _Quad(this.device, this.game, Color.DarkMagenta, new Vector3(-1, 6.5f, -17f), new Vector2(10, 3), _WallOrientation.West), //calda
                new _Quad(this.device, this.game, Color.DarkMagenta, new Vector3(1, 6.5f, -17f), new Vector2(10, 3), _WallOrientation.East), //calda
                new _Quad(this.device, this.game, Color.DarkMagenta, new Vector3(0, 8f, -17f), new Vector2(2, 10), _WallOrientation.Up), //calda cima
                new _Quad(this.device, this.game, Color.DarkMagenta, new Vector3(0, 5f, -17f), new Vector2(2, 10), _WallOrientation.Down), //calda baixo 

                new _Quad(this.device, this.game, Color.DarkMagenta, new Vector3(0, 6.4f, -22f), new Vector2(3f, 5f), _WallOrientation.South), //area da helice frente
                new _Quad(this.device, this.game, Color.DarkMagenta, new Vector3(0, 6.4f, -26.8f), new Vector2(3f, 5f), _WallOrientation.North), //area da helice atras
                new _Quad(this.device, this.game, Color.DarkMagenta, new Vector3(0, 6.4f, -22f), new Vector2(3f, 5f), _WallOrientation.North), //area da helice frente
                new _Quad(this.device, this.game, Color.DarkMagenta, new Vector3(0, 6.4f, -26.8f), new Vector2(3f, 5f), _WallOrientation.South), //area da helice atras
                new _Quad(this.device, this.game, Color.DarkMagenta, new Vector3(0, 8.9f, -24.4f), new Vector2(3f, 5f), _WallOrientation.Up), //area da helice cima
                new _Quad(this.device, this.game, Color.DarkMagenta, new Vector3(0, 4.1f, -24.4f), new Vector2(3f, 5f), _WallOrientation.Down), //area da helice abaixo
                new _Quad(this.device, this.game, Color.DarkMagenta, new Vector3(0, 8.9f, -24.4f), new Vector2(3f, 5f), _WallOrientation.Down), //area da helice cima
                new _Quad(this.device, this.game, Color.DarkMagenta, new Vector3(0, 4.1f, -24.4f), new Vector2(3f, 5f), _WallOrientation.Up), //area da helice abaixo
                

                new _Quad(this.device, this.game, Color.DarkMagenta, new Vector3(-1.5f, 4.2f, -24.4f), new Vector2(5, 0.5f), _WallOrientation.West), //area da helice abaixo
                new _Quad(this.device, this.game, Color.DarkMagenta, new Vector3(-1.5f, 8.7f, -24.4f), new Vector2(5, 0.5f), _WallOrientation.West), //area da helice acima
                new _Quad(this.device, this.game, Color.DarkMagenta, new Vector3(-1.5f, 6.4f, -22.15f), new Vector2(0.5f, 4.2f), _WallOrientation.West), //area da helice direita
                new _Quad(this.device, this.game, Color.DarkMagenta, new Vector3(-1.5f, 6.4f, -26.65f), new Vector2(0.5f, 4.2f), _WallOrientation.West), //area da helice esquerda

                new _Quad(this.device, this.game, Color.DarkMagenta, new Vector3(1.5f, 4.2f, -24.4f), new Vector2(5, 0.5f), _WallOrientation.East), //area da helice abaixo
                new _Quad(this.device, this.game, Color.DarkMagenta, new Vector3(1.5f, 8.7f, -24.4f), new Vector2(5, 0.5f), _WallOrientation.East), //area da helice acima
                new _Quad(this.device, this.game, Color.DarkMagenta, new Vector3(1.5f, 6.4f, -22.15f), new Vector2(0.5f, 4.2f), _WallOrientation.East), //area da helice direita
                new _Quad(this.device, this.game, Color.DarkMagenta, new Vector3(1.5f, 6.4f, -26.65f), new Vector2(0.5f, 4.2f), _WallOrientation.East), //area da helice esquerda

                new _Quad(this.device, this.game, Color.DarkMagenta, new Vector3(1.5f, 6.5f, -24.4f), new Vector2(5, 0.5f), _WallOrientation.East), //area da helice apoio
                new _Quad(this.device, this.game, Color.DarkMagenta, new Vector3(1.5f, 6.5f, -24.4f), new Vector2(5, 0.5f), _WallOrientation.West), //area da helice apoio

                new _Quad(this.device, this.game, Color.DarkMagenta, new Vector3(0, 11f, -7.5f), new Vector2(10, 9), _WallOrientation.Up), //teto
                new _Quad(this.device, this.game, Color.DarkMagenta, new Vector3(0, 3f, -6f), new Vector2(10, 12), _WallOrientation.Up), //assoalho 
            };

            this.backHelix = new _Helix(device, game);
            this.topHelix = new _Helix(device, game, 1);
        }

        public void Update()
        {
            this.backHelix.Update();
            this.topHelix.Update();
            angle += 5f;
            foreach (_Quad w in sides)
            {
                w.SetMatrixIndetity();
            }

            this.sides[1].SetMatrixIndetity();
            this.sides[1].CreateRotation(_TransformOrientation.X, -45);
            this.sides[1].CreateTranslation(0, 9.5f, -1.5f);

            this.sides[8].SetMatrixIndetity();
            this.sides[8].CreateRotation(_TransformOrientation.X, -45);
            this.sides[8].CreateTranslation(-5, 8.25f, -2.75f);

            this.sides[15].SetMatrixIndetity();
            this.sides[15].CreateRotation(_TransformOrientation.X, -45);
            this.sides[15].CreateTranslation(5, 8.25f, -2.75f);

            this.backHelix.SetMatrixIndetity();
            this.backHelix.CreateRotation(_TransformOrientation.X, angle);
            this.backHelix.CreateTranslation(1, 6.5f, -24.5f);

            this.topHelix.SetMatrixIndetity();
            this.topHelix.CreateRotation(_TransformOrientation.Y, angle);
            this.topHelix.CreateTranslation(0, 11.5f, -6f);


        }

        public void Draw(_Camera camera)
        {
            this.backHelix.Draw(camera);
            this.topHelix.Draw(camera);
            foreach (_Quad w in sides)
            {
                w.Draw(camera);
            }
        }

        #region Transforms
        public void CreateTranslation(float x, float y, float z)
        {
            this.world *= Matrix.CreateTranslation(x, y, z);

            foreach (_Quad w in sides)
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

            foreach (_Quad w in sides)
            {
                w.SetMatrix(this.world);
            }
        }

        public void CreateScale(float x, float y, float z)
        {
            this.world *= Matrix.CreateScale(x, y, z);

            foreach (_Quad w in sides)
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
