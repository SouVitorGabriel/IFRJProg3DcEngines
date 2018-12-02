using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BielWorld
{
    class _HM
    {
        VertexPositionTexture[] verts;
        VertexBuffer vBuffer;
        int[] indices;
        IndexBuffer iBuffer;
        Texture2D colorTextureSnow, colorTexture;
        int row, column;
        Effect effect;
        Matrix world;
        Game game;
        Texture2D texHM;
        float time;

        GraphicsDevice device;

        public _HM(Game game, GraphicsDevice device)
        {
            this.row = 200;
            this.column = 200;
            this.device = device;
            this.game = game;

            //this.texHM = game.Content.Load<Texture2D>(@"TextureHM\" + textureWhite);
            this.texHM = this.game.Content.Load<Texture2D>(@"HMTextures\volcano6");
            Color[] tAux = new Color[texHM.Width * texHM.Height];
            texHM.GetData<Color>(tAux);


            this.verts = new VertexPositionTexture[row * column];

            for (int i = 0; i < this.row; i++)
            {
                for (int j = 0; j < this.column; j++)
                {

                    float u = j / (float)(column - 1);
                    float v = i / (float)(row - 1);

                    int _j = (int)(u * (texHM.Width - 1));
                    int _i = (int)(v * (texHM.Height - 1));
                    int _Y = _i * texHM.Width + _j;

                    verts[i * column + j] = new VertexPositionTexture(new Vector3(j - column / 2f, (tAux[_Y].B / 10f) * -1, i - row / 2f), new Vector2(u, v));
                }
            }

            this.vBuffer = new VertexBuffer(this.game.GraphicsDevice, typeof(VertexPositionColorTexture), this.verts.Length, BufferUsage.None);
            this.vBuffer.SetData<VertexPositionTexture>(this.verts);

            this.indices = new int[row * column * 2 * 3];

            int k = 0;
            for (int i = 0; i < this.row - 1; i++)
            {
                for (int j = 0; j < this.column - 1; j++)
                {
                    // 1o triangulo
                    this.indices[k++] = (short)(i * column + j); // V0
                    this.indices[k++] = (short)(i * column + (j + 1)); // V1
                    this.indices[k++] = (short)((i + 1) * column + j); // V2

                    // 2o triangulo
                    this.indices[k++] = (short)(i * column + (j + 1)); // V1
                    this.indices[k++] = (short)((i + 1) * column + (j + 1)); // V1
                    this.indices[k++] = (short)((i + 1) * column + j); // V2

                }
            }

            this.iBuffer = new IndexBuffer(this.game.GraphicsDevice, IndexElementSize.ThirtyTwoBits, this.indices.Length, BufferUsage.None);
            //SEMPRE LEMBRAR DE MUDAR A DESGRAÇA DO PROJETO PARA FUNCIONAR
            // https://blogs.msdn.microsoft.com/shawnhar/2010/03/12/reach-vs-hidef/
            // https://blogs.msdn.microsoft.com/shawnhar/2010/07/19/selecting-reach-vs-hidef/
            this.iBuffer.SetData<int>(this.indices);

            this.colorTexture = this.game.Content.Load<Texture2D>(@"Textures\ground");
            this.colorTextureSnow = this.game.Content.Load<Texture2D>(@"Textures\groundSnow");

            this.effect = game.Content.Load<Effect>(@"Effect\Effect2");

            this.world = Matrix.Identity;

            
        }

        public void Update(GameTime gameTime)
        {
            time += gameTime.ElapsedGameTime.Milliseconds * 0.0001f;
        }
        public void Draw(_Camera camera)
        {
            this.effect.CurrentTechnique = this.effect.Techniques["Technique1"];
            this.effect.Parameters["World"].SetValue(world);
            this.effect.Parameters["View"].SetValue(camera.GetView());
            this.effect.Parameters["Projection"].SetValue(camera.GetProjection());
            this.effect.Parameters["colorTexture"].SetValue(colorTexture);
            this.effect.Parameters["colorTextureSnow"].SetValue(colorTextureSnow);
            //this.effect.Parameters["t"].SetValue(time);

            foreach (EffectPass pass in this.effect.CurrentTechnique.Passes)
            {
                pass.Apply();

                game.GraphicsDevice.DrawUserIndexedPrimitives<VertexPositionTexture>(PrimitiveType.TriangleList, this.verts, 0, this.verts.Length, this.indices, 0, this.indices.Length / 3);
            }

        }
    }
}
