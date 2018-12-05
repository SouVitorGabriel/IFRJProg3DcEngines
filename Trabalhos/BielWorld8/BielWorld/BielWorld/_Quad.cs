using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace BielWorld
{
    public class _Quad
    {
        private Game game;
        private GraphicsDevice device;
        protected Matrix world;
        private VertexPositionTexture[] verts;
        private VertexBuffer buffer;

        private Effect effect;
        private BasicEffect basicEffect;

        private Texture2D texture, texture2;

        private float multi;
        private bool pode;

        Vector3 v0;
        Vector3 v1;
        Vector3 v2;
        Vector3 v3;
        Vector3 v4;
        Vector3 v5;

        public _Quad(GraphicsDevice device, Game game, string textureName, string texture2Name, Vector3 position, Vector2 size, _WallOrientation orientation)
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

            this.verts = new VertexPositionTexture[]
            {
                new VertexPositionTexture(v0, Vector2.Zero),  //v0
                new VertexPositionTexture(v1, Vector2.UnitX), //v1
                new VertexPositionTexture(v2, Vector2.UnitY), //v2

                new VertexPositionTexture(v3, Vector2.UnitX), //v3
                new VertexPositionTexture(v4, Vector2.One),   //v4
                new VertexPositionTexture(v5, Vector2.UnitY), //v5
            };

            this.buffer = new VertexBuffer(this.device,
                                           typeof(VertexPositionTexture),
                                           this.verts.Length,
                                           BufferUsage.None);
            this.buffer.SetData<VertexPositionTexture>(this.verts);

            this.basicEffect = new BasicEffect(this.device);

            this.effect = this.game.Content.Load<Effect>(@"Effect\Effect1");

            this.texture = this.game.Content.Load<Texture2D>(textureName);
            this.texture2 = this.game.Content.Load<Texture2D>(texture2Name);
            multi = 0;
            pode = false;
        }

        public void Update(GameTime gameTime)
        {
            
        }

        public virtual void Draw(_Camera camera)
        {
            if (multi >= 3 && !pode)
            {
                pode = true;
            }

            if (multi <= 0 && pode)
            {
                pode = false;
            }

            if (pode)
            {
                multi -= 0.003f;
            }
            else
            {
                multi += 0.003f;
            }
            

            this.device.SetVertexBuffer(this.buffer);

            //this.basicEffect.World = this.world;
            //this.basicEffect.View = camera.GetView();
            //this.basicEffect.Projection = camera.GetProjection();
            //this.basicEffect.TextureEnabled = true;
            //this.basicEffect.Texture = this.texture;

            this.effect.CurrentTechnique = this.effect.Techniques["Technique1"];
            this.effect.Parameters["World"].SetValue(this.world);
            this.effect.Parameters["View"].SetValue(camera.GetView());
            this.effect.Parameters["Projection"].SetValue(camera.GetProjection());
            this.effect.Parameters["colorTexture"].SetValue(this.texture);
            this.effect.Parameters["colorTextureSnow"].SetValue(this.texture2);
            //this.effect.Parameters["multi"].SetValue(this.multi);


            foreach (EffectPass pass in this.effect.CurrentTechnique.Passes)
            {
                pass.Apply();

                this.device.DrawUserPrimitives<VertexPositionTexture>(PrimitiveType.TriangleList,
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
