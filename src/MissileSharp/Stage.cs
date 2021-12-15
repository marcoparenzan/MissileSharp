using GameConsole.Core;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace MissileSharp
{
    public partial class Stage : IStage
    {
        int score_count;
        int lives_count;
        int cities_count;
        int bunkers_count;
        HiddenEnemySprite hiddenEnemy = default;
        CrossHairSprite crossHair = default;
        CitySprite[] cities = new CitySprite[6];
        BunkerSprite[] bunkers = new BunkerSprite[3];
        AlliedMissileSprite[] alliedMissiles = new AlliedMissileSprite[256];
        int nextFreeAlliedMissile;
        EnemyMissileSprite[] enemyMissiles = new EnemyMissileSprite[256];
        int nextFreeEnemyMissile;

        public void SetMouseTrigger(Vec v)
        {
            if (crossHair.MouseTrigger == default) return;
            crossHair.MouseTrigger.Set(v);
        }

        public void ResetMouseTrigger()
        {
            if (crossHair.MouseTrigger == default) return;
            crossHair.MouseTrigger.Reset();
        }

        public void SetFireTrigger(int v)
        {
            if (bunkers[v].FireTrigger == default) return;
            bunkers[v].FireTrigger.Set();
        }

        public void ResetFireTrigger(int v)
        {
            if (bunkers[v].FireTrigger == default) return;
            bunkers[v].FireTrigger.Reset();
        }
        
        public Stage()
        {
            Resources();

        }

        public void Initialize()
        {
            lives_count = 3;
            score_count = 0;
            cities_count = 6;
            bunkers_count = 3;

            hiddenEnemy = new HiddenEnemySprite(10);
            Initialize(ref hiddenEnemy);
            crossHair = new CrossHairSprite((0, 0));
            Initialize(ref crossHair);
            cities = new[]
            {
                new CitySprite((166, 582)),
                new CitySprite((274, 587)),
                new CitySprite((356, 581)),
                new CitySprite((555, 584)),
                new CitySprite((674, 569)),
                new CitySprite((780, 588))
            };
            for (var i = 0; i < cities.Length; i++)
            {
                Initialize(i, ref cities[i]);
            }
            bunkers = new[]
            {
                new BunkerSprite((79, 633)),
                new BunkerSprite((468, 639)),
                new BunkerSprite((909, 633))
            };
            for (var i = 0; i < bunkers.Length; i++)
            {
                Initialize(i, ref bunkers[i]);
            }
            for (var i = 0; i < alliedMissiles.Length; i++)
            {
                alliedMissiles[i].Next = i + 1;
            }
            // the last one will be "free"
            nextFreeAlliedMissile = 0;
            for (var i = 0; i < enemyMissiles.Length; i++)
            {
                enemyMissiles[i].Next = i + 1;
            }
            // the last one will be "free"
            nextFreeEnemyMissile = 0;
        }

        public void Render(Graphics g)
        {
            g.DrawImage(background, 0, 0);
            Render(ref hiddenEnemy, g);
            Render(ref crossHair, g);
            for (var i = 0; i < cities.Length; i++)
            {
                Render(i, ref cities[i], g);
            }
            for (var i = 0; i < bunkers.Length; i++)
            {
                Render(i, ref bunkers[i], g);
            }
            for (var i = 0; i < alliedMissiles.Length; i++)
            {
                Render(i, ref alliedMissiles[i], g);
            }
            for (var i = 0; i < enemyMissiles.Length; i++)
            {
                Render(i, ref enemyMissiles[i], g);
            }
            g.DrawString($"{score_count}", f, Brushes.White, 900, 8);
            g.DrawString($"{lives_count}", f, Brushes.White, 900, 18);
        }

        public void Update(int ms)
        {
            Update(ms, ref hiddenEnemy);
            Update(ms, ref crossHair);
            for (var i = 0; i < cities.Length; i++)
            {
                Update(ms, i, ref cities[i]);
            }
            for (var i = 0; i < bunkers.Length; i++)
            {
                Update(ms, i, ref bunkers[i]);
            }
            for (var i = 0; i < alliedMissiles.Length; i++)
            {
                Update(ms, i, ref alliedMissiles[i]);
            }
            for (var i = 0; i < enemyMissiles.Length; i++)
            {
                Update(ms, i, ref enemyMissiles[i]);
            }
        }
    }
}
