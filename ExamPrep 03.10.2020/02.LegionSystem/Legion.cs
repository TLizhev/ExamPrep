namespace _02.LegionSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using _02.LegionSystem.Interfaces;
    using Wintellect.PowerCollections;

    public class Legion : IArmy
    {
        private OrderedSet<IEnemy> enemies;
        public Legion()
        {
            enemies = new OrderedSet<IEnemy>();
        }
        public int Size => enemies.Count;

        public bool Contains(IEnemy enemy)
        {
            return this.enemies.Contains(enemy);
        }

        public void Create(IEnemy enemy)
        {
            if (!enemies.Contains(enemy))
            {
            enemies.Add(enemy);

            }
        }

        public IEnemy GetByAttackSpeed(int speed)
        {
            return enemies.Where(e => e.AttackSpeed.Equals(speed)).FirstOrDefault();
        }

        public List<IEnemy> GetFaster(int speed)
        {
            var faster = new List<IEnemy>();
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i].AttackSpeed>speed)
                {
                    faster.Add(enemies[i]);
                }
            }
            return faster.ToList();
        }

        public IEnemy GetFastest()
        {
           return enemies.Min();
        }

        public IEnemy[] GetOrderedByHealth()
        {
            return enemies.OrderByDescending(e=>e.Health).ToArray();
        }

        public List<IEnemy> GetSlower(int speed)
        {
            var slower = new List<IEnemy>();
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i].AttackSpeed < speed)
                {
                    slower.Add(enemies[i]);
                }
            }
            return slower.ToList();
        }

        public IEnemy GetSlowest()
        {
            if (enemies.Count==0)
            {
                throw new InvalidOperationException("Legion has no enemies!");
            }
            else
            {

            return enemies.Max();
            }
        }

        public void ShootFastest()
        {
            if (enemies.Count == 0)
            {
                throw new InvalidOperationException("Legion has no enemies!");
            }
            
            enemies.RemoveFirst();
        }

        public void ShootSlowest()
        {
            if (enemies.Count == 0)
            {
                throw new InvalidOperationException("Legion has no enemies!");
            }
            enemies.RemoveLast();
        }
    }
}
