using System;

namespace SmartKitchen
{
    // === ВЕРСІЯ 2: INHERITANCE (Успадкування) ===
    // Абстрактний базовий клас для всіх smart-пристроїв
    public abstract class SmartDevice
    {
        // 1. Закриті приватні поля (Backing Fields)
        private string _id;
        private string _model;
        private string _workMode;

        // 2. Класичні властивості (Аксесори)
        public string ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        public string Model
        {
            get
            {
                return _model;
            }
            set
            {
                _model = value;
            }
        }

        public string WorkMode
        {
            get
            {
                return _workMode;
            }
            set
            {
                _workMode = value;
            }
        }

        // 3. Абстрактні методи, які обов'язково має реалізувати похідний клас
        public abstract void Init();
        public abstract void SelfDiag();

        // 4. Віртуальний метод, який можна доповнити у похідному класі
        public virtual void SwitchMode(string mode)
        {
            WorkMode = mode;
            Service.Print($"[SmartDevice] Перехід у режим '{WorkMode}'.");
        }
    }
}