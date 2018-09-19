using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace BielWorld
{
    
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private Matrix world;

        _Screen screen;
        _Camera camera;
        _Quad ground;

        _Quad wall;
        float angle;

        _House house;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
        }
        
        protected override void Initialize()
        {
            this.world = Matrix.Identity;
            this.screen = _Screen.GetInstance();
            this.screen.SetWidth(graphics.PreferredBackBufferWidth);
            this.screen.SetHeight(graphics.PreferredBackBufferHeight);

            this.camera = new _Camera();
            this.wall = new _Quad(GraphicsDevice, this, Color.Black, new Vector3(-5.5f, 4f, 0), new Vector2(3f, 8f));

            this.ground = new _Quad(GraphicsDevice, this, Color.SaddleBrown, new Vector3(0, 0, 0), new Vector2(50, 50));
            this.ground.CreateRotation("X", -90);

            this.house = new _House(GraphicsDevice, this, new Vector3(-5, 0, 0), new Vector2(0, 0));

            
            base.Initialize();
        }
        

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            
        }

        protected override void UnloadContent()
        {

        }
        
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            this.ground.Update(gameTime);
            this.wall.Update(gameTime);
            this.wall.CreateTranslation(12, 0, 0);
            this.wall.CreateRotation("y", angle);
            
            angle += 2f;


            this.house.Update(gameTime);

            //this.house.SetMatrixIndetity();
            //this.house.CreateTranslation(10f, 0, 0);
            //this.house.CreateScale(1f, 1f, 1f);
            //this.house.CreateRotation("y", 90f);
            
            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            RasterizerState rs = new RasterizerState();
            rs.CullMode = CullMode.None;
            //rs.FillMode = FillMode.Solid;
            //rs.FillMode = FillMode.WireFrame;
            this.GraphicsDevice.RasterizerState = rs;

            this.ground.Draw(this.camera);
            //this.wall.Draw(this.camera);
            this.house.Draw(this.camera);

            base.Draw(gameTime);
        }
    }
}
