using System;
using System.Collections.Generic;

namespace PrototypePatternGame
{
    public class Character : ICloneable
    {
        public string Name { get; set; }
        public string Class { get; set; }
        public int Level { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }
        public int Armor { get; set; }
        public int Speed { get; set; }
        public string Weapon { get; set; }

        public Character(string name, string @class, int level, int health, int damage, int armor, int speed, string weapon)
        {
            Name = name;
            Class = @class;
            Level = level;
            Health = health;
            Damage = damage;
            Armor = armor;
            Speed = speed;
            Weapon = weapon;
        }

        public Character Clone() => (Character)this.MemberwiseClone();

        object ICloneable.Clone() => this.Clone();

        public void ShowInfo()
        {
            Console.WriteLine($"[ {Name} ] Класс: {Class} | Уровень: {Level} | Оружие: {Weapon}");
            Console.WriteLine($"       HP: {Health} | Урон: {Damage} | Броня: {Armor} | Скорость: {Speed}");
            Console.WriteLine(new string('-', 55));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Character warriorProt = new Character("Базовый Воин", "Воин", 1, 500, 80, 100, 5, "Меч");
            Character mageProt = new Character("Базовый Маг", "Маг", 1, 250, 150, 30, 7, "Посох");
            Character archerProt = new Character("Базовый Лучник", "Лучник", 1, 300, 100, 50, 10, "Лук");

            List<Character> squad = new List<Character>();

            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine("       СОЗДАНИЕ ПЕРСОНАЖА    ");
                Console.WriteLine("");
                Console.WriteLine("1 — Создать Воина");
                Console.WriteLine("2 — Создать Мага");
                Console.WriteLine("3 — Создать Лучника");
                Console.WriteLine("4 — Показать прототипы");
                Console.WriteLine("0 — Выход");
                Console.WriteLine("");
                Console.Write("Ваш выбор: ");

                string choice = Console.ReadLine();
                Console.Clear();

                Character current = null;

                if (choice == "1") current = warriorProt.Clone();
                else if (choice == "2") current = mageProt.Clone();
                else if (choice == "3") current = archerProt.Clone();
                else if (choice == "4")
                {
                    Console.WriteLine(" ПРОТОТИПЫ ");
                    warriorProt.ShowInfo();
                    mageProt.ShowInfo();
                    archerProt.ShowInfo();
                    continue;
                }
                else if (choice == "0") break;
                else continue;

                Console.Write($"Введите имя для нового {current.Class}а: ");
                current.Name = Console.ReadLine();
                squad.Add(current);

                Console.Clear();
                Console.WriteLine(" СОЗДАННЫЙ ПЕРСОНАЖ ");
                current.ShowInfo();
            }
        }
    }
}
