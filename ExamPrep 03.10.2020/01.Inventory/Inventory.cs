namespace _01.Inventory
{
    using _01.Inventory.Interfaces;
    using _01.Inventory.Models;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Inventory : IHolder
    {
        private List<IWeapon> weapons;
        public Inventory()
        {
            weapons = new List<IWeapon>();
        }
        public int Capacity => weapons.Count;

        public void Add(IWeapon weapon)
        {
            weapons.Add(weapon);
        }

        public void Clear()
        {
            weapons.Clear();
        }

        public bool Contains(IWeapon weapon)
        {
           return weapons.Contains(weapon);
        }

        public void EmptyArsenal(Category category)
        {
           var ammoToClear = weapons.Where(a=>a.Category.Equals(category)).ToList();
            foreach (var ammo in ammoToClear)
            {
                ammo.Ammunition = 0;
            }
            
        }

        public bool Fire(IWeapon weapon, int ammunition)
        {
            if (!weapons.Contains(weapon))
            {
                throw new InvalidOperationException("Weapon does not exist in inventory!");
            }
            if (ammunition<=weapon.Ammunition)
            {
                weapon.Ammunition -= ammunition;
                return true;
            }
            else
            {
                return false;
            }
        }

        public IWeapon GetById(int id)
        {
            return weapons.Where(w=>w.Id.Equals(id)).FirstOrDefault();
        }

        public IEnumerator GetEnumerator()
        {
           return weapons.GetEnumerator();
        }

        public int Refill(IWeapon weapon, int ammunition)
        {
            if (!weapons.Contains(weapon))
            {
                throw new InvalidOperationException("Weapon does not exist in inventory");
            }
            
            if (ammunition<=weapon.MaxCapacity)
            {

            weapon.Ammunition = weapon.MaxCapacity - ammunition;
            }
            return weapon.Ammunition;
        }

        public IWeapon RemoveById(int id)
        {
            
               var result = weapons.Where(w => w.Id == id).First();
            if (result==null)
            {
                throw new InvalidOperationException("Weapon does not exist in inventory!");
            }
            weapons.Remove(result);
            return result;
            
        }

        public int RemoveHeavy()
        {
            return weapons.RemoveAll(w=>w.Category)
        }

        public List<IWeapon> RetrieveAll()
        {
            return new List<IWeapon>(weapons);
        }

        public List<IWeapon> RetriveInRange(Category lower, Category upper)
        {
            var result = new List<IWeapon>();
            foreach (var item in weapons)
            {
                if (item.Category >= lower && item.Category <= upper)
                {
                    result.Add(item);
                }
            }
                return result.ToList();
        }

        public void Swap(IWeapon firstWeapon, IWeapon secondWeapon)
        {
            if (weapons.Contains(firstWeapon) && weapons.Contains(secondWeapon))
            {


                int firstEntityIndex = weapons.IndexOf(firstWeapon);

                int secondEntityIndex = weapons.IndexOf(secondWeapon);


                var temp = weapons[firstEntityIndex];
                weapons[firstEntityIndex] = weapons[secondEntityIndex];
                weapons[secondEntityIndex] = temp;
            }
            else
            {
                throw new InvalidOperationException("Weapon does not exist in inventory!");
            };
        }
    }
}
