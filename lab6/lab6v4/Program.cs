using System;
using System.Text;

namespace SmartKitchen
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Service.Print("=== ЛАБОРАТОРНА РОБОТА: ВЕРСІЯ 4 (ФІНАЛЬНА) ===");

            // 1. Агрегація
            var camera = new HyperspectralCamera();
            var stove = new BuiltInStove();
            var display = new MultiTouchDisplay();
            var projector = new ArProjector();
            var dock = new WirelessDock();
            var predictionModule = new CulinaryPredictionModule();
            var neuroInterface = new NeuroCulinaryInterface();
            var holoChef = new HolographicChef();
            var healthAnalyzer = new HealthAnalyzer();

            // 2. Створення столу
            var smartTable = new SmartKitchenTable(
                camera, stove, display, projector, dock,
                predictionModule, neuroInterface, holoChef, healthAnalyzer);


            // 3. Асоціація
            var moodSensor = new UserMoodSensor();
            var recipeGen = new RecipeGenerator();
            var foodScanner = new FoodStructureScanner();

            // === 4. ПІДПИСКА НА ПОДІЇ (Event Handlers) ===
            smartTable.OnScanStarted += (details) =>
            {
                Service.Print($"[ПОДІЯ]: {details} -> Активація камер.");
            };

            smartTable.OnBadProductDetected += (details) =>
            {
                Service.Print($"[ПОДІЯ]: {details} -> Оновлення рецепту.");
            };

            smartTable.OnDnaAnalyzed += (details) =>
            {
                Service.Print($"[ПОДІЯ]: {details} -> Коригування меню.");
            };

            smartTable.OnNutritionCalculated += (details) =>
            {
                Service.Print($"[ПОДІЯ]: {details} -> Пропозиція балансу.");
            };

            smartTable.OnNeuroActivated += (details) =>
            {
                Service.Print($"[ПОДІЯ]: {details} -> Навчання ШІ.");
            };

            // 5. Запуск
            smartTable.Init();
            smartTable.SwitchMode("Активний");
            smartTable.ExecuteScenario(moodSensor, recipeGen, foodScanner);

            // === 6. ОБРОБКА ВИКЛЮЧНИХ СИТУАЦІЙ У MAIN (Версія 3) ===
            Service.Print("\n=== СИМУЛЯЦІЯ ОБРОБКИ ВИКЛЮЧНИХ СИТУАЦІЙ В MAIN ===");

            string[] errorTypes =
            {
                "DnaConflict", "SpoiledFood", "MoodSensorFail",
                "NeuroOverload", "CloudFail", "ScaleError",
                "UserAway", "UnknownProduct"
            };

            foreach (var err in errorTypes)
            {
                try
                {
                    // Штучно генеруємо помилку
                    throw new SmartKitchenException("Збій системи", err);
                }
                catch (SmartKitchenException ex)
                {
                    Service.Print($"[ВИНЯТОК ЗЛОВЛЕНО В MAIN]: {ex.Message}: {ex.ErrorType}");
                    string handlingAction = "";

                    switch (ex.ErrorType)
                    {
                        case "DnaConflict":
                            handlingAction = "Запит на підтвердження. Конфлікт генетичного аналізу.";
                        break;

                        case "SpoiledFood":
                            handlingAction = "Блокування приготування, пропозиція замінників.";
                            break;

                        case "MoodSensorFail":
                            handlingAction = "Повторне зчитування, увімкнення релакс-музики.";
                            break;

                        case "NeuroOverload":
                            handlingAction = "Відключення нейрозв’язку, перехід на голосове керування.";
                            break;

                        case "CloudFail":
                            handlingAction = "Перехід у режим офлайн-кухаря.";
                            break;

                        case "ScaleError":
                            handlingAction = "Повторне зважування, відміна дії.";
                            break;

                        case "UserAway":
                            handlingAction = "Призупинення процесу, збереження страви.";
                            break;

                        case "UnknownProduct":
                            handlingAction = "Запит на ручне введення.";
                            break;
                    }

                    Service.Print($"ОБРОБКА: {handlingAction}\n---");
                }
            }

            Console.ReadLine();
        }
    }
}