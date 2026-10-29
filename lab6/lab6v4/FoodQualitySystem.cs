using System;

namespace SmartKitchen
{
    public class FoodQualitySystem
    {
        public void CheckFreshness()
        {
            Service.Print("Система якості: Хімічний аналіз свіжості завершено.");
        }

        // НОВИЙ МЕТОД: Математичний розрахунок відсотка свіжості
        public int CalculateFreshnessPercentage(int shelfLifeDays, int daysPassed)
        {
            if (daysPassed >= shelfLifeDays)
            {
                Service.Print("Система якості: КРИТИЧНО! Термін придатності продукту вичерпано. Рівень свіжості: 0%.");
                return 0;
            }

            // Математична пропорція для визначення відсотка
            int freshness = ((shelfLifeDays - daysPassed) * 100) / shelfLifeDays;

            Service.Print($"Система якості: Продукт свіжий на {freshness}%.");

            return freshness;
        }
    }
}