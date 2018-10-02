﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BielWorld
{
    public class _Quad
    {
        private Game game;
        private GraphicsDevice device;
        private Matrix world;
        private VertexPositionColor[] verts;
        private VertexBuffer buffer;
        private BasicEffect effect;

        private _WallOrientation wallOrientation;

        Vector3 v0;
        Vector3 v1;
        Vector3 v2;
        Vector3 v3;
        Vector3 v4;
        Vector3 v5;

        public _Quad(GraphicsDevice device, Game game, Color color, Vector3 position, Vector2 size, _WallOrientation orientation)
        {
            this.game = game;
            this.device = device;
            this.world = Matrix.Identity;

            switch (orientation)
            {
                case _WallOrientation.South:
                    isSouth(position, size);
                    break;
                case _WallOrientation.North:
                    isNorth(position, size);
                    break;
                case _WallOrientation.East:
                    isEast(position, size);
                    break;
                case _WallOrientation.West:
                    isWest(position, size);
                    break;
                case _WallOrientation.Up:
                    isUp(position, size);
                    break;
                case _WallOrientation.Down:
                    isDown(position, size);
                    break;
            }

            this.verts = new VertexPositionColor[]
            {
                new VertexPositionColor(v0, color),  //v0
                new VertexPositionColor(v1, color), //v1
                new VertexPositionColor(v2, color), //v2

                new VertexPositionColor(v3, color), //v3
                new VertexPositionColor(v4, color),   //v4
                new VertexPositionColor(v5, color), //v5
            };

            this.buffer = new VertexBuffer(this.device,
                                           typeof(VertexPositionColor),
                                           this.verts.Length,
                                           BufferUsage.None);
            this.buffer.SetData<VertexPositionColor>(this.verts);

            this.effect = new BasicEffect(this.device);
        }

        public void Update(GameTime gameTime)
        {

        }

        public virtual void Draw(_Camera camera)
        {
            this.device.SetVertexBuffer(this.buffer);

            effect.VertexColorEnabled = true;

            this.effect.World = this.world;

            this.effect.View = camera.GetView();
            this.effect.Projection = camera.GetProjection();

            foreach (EffectPass pass in this.effect.CurrentTechnique.Passes)
            {
                pass.Apply();

                this.device.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.TriangleList,
                                                                    this.verts, 0, this.verts.Length / 3);
            }
        }

        public void CreateTranslation(float x, float y, float z)
        {
            this.world *= Matrix.CreateTranslation(x, y, z);
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
        }

        public void CreateScale(float x, float y, float z)
        {
            this.world *= Matrix.CreateScale(x, y, z);
        }

        public void SetMatrix(Matrix matrix)
        {
                this.world = this.world * matrix;
        }

        public void SetMatrixIndetity()
        {
            this.world = Matrix.Identity;
        }

        public void isSouth(Vector3 position, Vector2 size)
        {
            v0 = new Vector3(position.X - (size.X /2), position.Y + (size.Y / 2), position.Z);
            v1 = new Vector3(position.X + (size.X / 2), position.Y + (size.Y / 2), position.Z);
            v2 = new Vector3(position.X - (size.X / 2), position.Y - (size.Y / 2), position.Z);

            v3 = v1;
            v4 = new Vector3(position.X + (size.X / 2), position.Y - (size.Y / 2), position.Z);
            v5 = v2;
        }

        public void isNorth(Vector3 position, Vector2 size)
        {
            v0 = new Vector3(position.X - (size.X / 2), position.Y + (size.Y / 2), position.Z);
            v1 = new Vector3(position.X - (size.X / 2), position.Y - (size.Y / 2), position.Z);
            v2 = new Vector3(position.X + (size.X / 2), position.Y + (size.Y / 2), position.Z);
            

            v3 = v1;
            v4 = new Vector3(position.X + (size.X / 2), position.Y - (size.Y / 2), position.Z);
            v5 = v2;
        }

        public void isEast(Vector3 position, Vector2 size)
        {
            v0 = new Vector3(position.X, position.Y + (size.Y / 2), position.Z + (size.X / 2));
            v1 = new Vector3(position.X, position.Y + (size.Y / 2), position.Z - (size.X / 2));
            v2 = new Vector3(position.X, position.Y - (size.Y / 2), position.Z + (size.X / 2));

            v3 = v1;
            v4 = new Vector3(position.X, position.Y - (size.Y / 2), position.Z - (size.X / 2));
            v5 = v2;
        }

        public void isWest(Vector3 position, Vector2 size)
        {
            v0 = new Vector3(position.X, position.Y + (size.Y / 2), position.Z + (size.X / 2));
            v1 = new Vector3(position.X, position.Y - (size.Y / 2), position.Z + (size.X / 2));
            v2 = new Vector3(position.X, position.Y + (size.Y / 2), position.Z - (size.X / 2));
            

            v3 = v1;
            v4 = new Vector3(position.X, position.Y - (size.Y / 2), position.Z - (size.X / 2));
            v5 = v2;
        }

        public void isUp(Vector3 position, Vector2 size)
        {
            v0 = new Vector3(position.X - (size.X / 2), position.Y, position.Z - (size.Y / 2));
            v1 = new Vector3(position.X + (size.X / 2), position.Y, position.Z - (size.Y / 2));
            v2 = new Vector3(position.X - (size.X / 2), position.Y, position.Z + (size.Y / 2));

            v3 = v1;
            v4 = new Vector3(position.X + (size.X / 2), position.Y, position.Z + (size.Y / 2));
            v5 = v2;
        }

        public void isDown(Vector3 position, Vector2 size)
        {
            v0 = new Vector3(position.X - (size.X / 2), position.Y, position.Z - (size.Y / 2));
            v1 = new Vector3(position.X - (size.X / 2), position.Y, position.Z + (size.Y / 2));
            v2 = new Vector3(position.X + (size.X / 2), position.Y, position.Z - (size.Y / 2));

            v3 = v1;
            v4 = new Vector3(position.X + (size.X / 2), position.Y, position.Z + (size.Y / 2));
            v5 = v2;
        }
    }
}
