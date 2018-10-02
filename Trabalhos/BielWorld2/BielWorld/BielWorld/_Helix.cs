using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BielWorld
{
    class _Helix
    {
        private Game game;
        private GraphicsDevice device;
        private Matrix world;

        private _Quad[] sides;

        public  _Helix(GraphicsDevice graphicDevice, Game game, int type = 0)
        {
            Color color = Color.Blue;
            this.game = game;
            this.device = graphicDevice;
            this.world = Matrix.Identity;

            if (type == 0)
            {
                this.sides = new _Quad[]
                {
                    new _Quad(this.device, this.game, Color.Red, new Vector3(0,0,0), new Vector2(0.5f, 3f), _WallOrientation.East),
                    new _Quad(this.device, this.game, Color.Red, new Vector3(0,0,0), new Vector2(3f, 0.5f), _WallOrientation.East),
                    new _Quad(this.device, this.game, Color.Red, new Vector3(0,0,0), new Vector2(0.5f, 3f), _WallOrientation.West),
                    new _Quad(this.device, this.game, Color.Red, new Vector3(0,0,0), new Vector2(3f, 0.5f), _WallOrientation.West),
                };
            }
            if (type == 1)
            {
                this.sides = new _Quad[]
                {
                    new _Quad(this.device, this.game, Color.Red, new Vector3(0,0,0), new Vector2(16f, 1f), _WallOrientation.Up),
                    new _Quad(this.device, this.game, Color.Red, new Vector3(0,0,0), new Vector2(1f, 16f), _WallOrientation.Down),
                    new _Quad(this.device, this.game, Color.Red, new Vector3(0,0,0), new Vector2(16f, 1f), _WallOrientation.Down),
                    new _Quad(this.device, this.game, Color.Red, new Vector3(0,0,0), new Vector2(1f, 16f), _WallOrientation.Up),
                };
            }
        }

        public void Update()
        {
            foreach (_Quad w in sides)
            {
                w.SetMatrixIndetity();
            }
        }

        public void Draw(_Camera camera)
        {
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
