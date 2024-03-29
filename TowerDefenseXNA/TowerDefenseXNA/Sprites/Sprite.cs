﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefenseXNA
{
    public class Sprite
    {
        // Declaration 
        protected Texture2D texture;
        protected Vector2 position;
        protected Vector2 center;
        protected Vector2 origin;
        protected float rotation;
        protected Rectangle bounds;
        protected Vector2 velocity;

        // Use for knowing the position of the sprite
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        // Use for kwnowing the center of the sprite
        public Vector2 Center
        {
            get { return center; }
            set { center = value; }
        }

        // Use for kwnowing the boundaries of the sprite
        public Rectangle Bounds
        {
            get { return bounds; }
            set { bounds = value; }
        }


        // Constructor
        public Sprite(Texture2D tex, Vector2 pos)
        {
            texture = tex;
            position = pos;
            velocity = Vector2.Zero;
            bounds = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            center = new Vector2(position.X + texture.Width / 2, position.Y + texture.Height / 2);
            origin = new Vector2(texture.Width / 2, texture.Height / 2);
        }

        
        // Methods

        // Update the sprite
        public virtual void Update(GameTime gameTime)
        {
            this.center = new Vector2(position.X + texture.Width / 2,
            position.Y + texture.Height / 2);
        }


        // Draw a sprite
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Begin();
            spriteBatch.Draw(texture, center, null, Color.White, rotation, origin, 1.0f, SpriteEffects.None, 0);
            //spriteBatch.End();
        }

        public virtual void Draw(SpriteBatch spriteBatch, Color color)
        {
            spriteBatch.Draw(texture, center, null, color, rotation,
                origin, 1.0f, SpriteEffects.None, 0);
        }
    }
}
