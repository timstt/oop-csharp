using System;

namespace SmartKitchen
{
    public class AiSoftwareCore
    {
        public void ProcessData()
        {
            Service.Print("Ядро ШІ: Перерахунок матриці КБЖВ...");
        }
        public double CalculateCalories(double protein, double fat, double carbs)
        {

            Service.Print("Ядро ШІ: Запуск алгоритму розрахунку енергетичної цінності...");

            double totalCalories = (protein * 4) + (fat * 9) + (carbs * 4);

            Service.Print($"Ядро ШІ: Обчислено! Білки: {protein}г, Жири: {fat}г, Вуглеводи: {carbs}г.");
            Service.Print($"Ядро ШІ: Загальна калорійність страви становить {totalCalories} ккал.");

            return totalCalories;
        }
    }
}