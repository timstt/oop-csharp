using System;

namespace SmartKitchen
{
    public class SmartScales
    {
        public void AutoWeigh()
        {
            Service.Print("Розумні ваги: Масу інгредієнтів визначено автоматично.");
        }

        // НОВИЙ МЕТОД: Обчислення загальної ваги з перевіркою ліміту
        public double CalculateTotalWeight(double[] ingredientsWeights)
        {
            double totalWeight = 0;
            double maxLimit = 5000.0; // Максимальна вага 5000 грамів (5 кг)

            foreach (double weight in ingredientsWeights)
            {
                totalWeight += weight;
            }

            Service.Print($"Розумні ваги: Загальна маса продуктів на столі — {totalWeight} г.");

            if (totalWeight > maxLimit)
            {
                Service.Print("Розумні ваги: УВАГА! Перевищено допустиме навантаження на стіл!");
            }

            return totalWeight;
        }
    }
}