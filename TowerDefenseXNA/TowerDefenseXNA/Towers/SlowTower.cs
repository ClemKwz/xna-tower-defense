﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;

namespace TowerDefenseXNA
{
    public class SlowTower : Tower
    {
        // Defines how fast an enemy will move when hit.
        private float speedModifier;
        // Defines how long this effect will last.
        private float modifierDuration;
        SoundEffect bulletAudio;

        public float ModifierDuration
        {
            get { return modifierDuration; }
            set { modifierDuration = value; }
        }

        public float SpeedModifier
        {
            get { return speedModifier; }
            set { speedModifier = value; }
        }

        public SlowTower(Texture2D texture, Texture2D bulletTexture, Texture2D rangeTexture, Vector2 position, SoundEffect bulletAudio)
            : base(texture, bulletTexture, rangeTexture, position)
        {
            this.damage = 5; // Set the damage
            this.cost = 25;   // Set the initial cost
            this.radius = 80; // Set the radius
            this.bulletAudio = bulletAudio;

            this.speedModifier = 0.6f;
            this.modifierDuration = 2.0f;
            this.name = "SlowTower";
        }

        

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (bulletTimer >= 2.75f && target != null)
            {
                Bullet bullet = new Bullet(bulletTexture, Vector2.Subtract(center,
                    new Vector2(bulletTexture.Width / 2)), rotation, 6, damage);
                bulletAudio.Play();
                bulletList.Add(bullet);
                bulletTimer = 0;
            }

            for (int i = 0; i < bulletList.Count; i++)
            {
                Bullet bullet = bulletList[i];

                bullet.SetRotation(rotation);
                bullet.Update(gameTime);

                if (!IsInRange(bullet.Center))
                    bullet.Kill();

                // If the bullet hits a target,
                if (target != null && Vector2.Distance(bullet.Center, target.Center) < 12)
                {
                    // destroy the bullet and hurt the target.
                    target.CurrentHealth -= bullet.Damage;
                    bullet.Kill();

                    // Apply our speed modifier if it is better than
                    // the one currently affecting the target :
                    if (target.SpeedModifier <= speedModifier)
                    {
                        target.SpeedModifier = speedModifier;
                        target.ModifierDuration = modifierDuration;
                    }
                }

                if (bullet.IsDead())
                {
                    bulletList.Remove(bullet);
                    i--;
                }
            }
        }
    }
}
