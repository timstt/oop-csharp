using System;

namespace SmartKitchen
{
    // Клас SmartKitchenTable успадковується від базового класу SmartDevice (реалізація Інтеграції/Успадкування)
    public class SmartKitchenTable : SmartDevice
    {
        // === ДЕЛЕГАТ ДЛЯ ПОДІЙ (Версія 4) ===
        // Делегат виступає "суворим контрактом". Він каже: "Будь-який метод, який хоче реагувати на мої події, 
        // ПОВИНЕН нічого не повертати (void) і приймати один рядок (string details)".
        public delegate void KitchenEventHandler(string details);

        // === 1. ЗАКРИТІ ПОЛЯ (Backing Fields) ===
        // Інкапсуляція: ми ховаємо реальні дані в приватні змінні, щоб зовнішній код 
        // не міг їх зламати чи змінити в обхід наших правил.
        private string _userProfile;

        // Поля для об'єктів КОМПОЗИЦІЇ (жорсткий зв'язок)
        private AiSoftwareCore _ai;
        private SmartScales _scales;
        private FoodQualitySystem _qualitySystem;

        // Поля для об'єктів АГРЕГАЦІЇ (слабкий зв'язок)
        private HyperspectralCamera _camera;
        private BuiltInStove _stove;
        private MultiTouchDisplay _display;
        private ArProjector _projector;
        private WirelessDock _dock;
        private CulinaryPredictionModule _predictionModule;
        private NeuroCulinaryInterface _neuroInterface;
        private HolographicChef _holoChef;
        private HealthAnalyzer _healthAnalyzer;

        // === 2. ПУБЛІЧНІ АКСЕСОРИ (Властивості) ===
        // Це "двері" до наших закритих полів. Через get ми віддаємо значення, через set - записуємо.
        public string UserProfile
        {
            get
            {
                return _userProfile;
            }
            set
            {
                _userProfile = value;
            }
        }

        // Аксесори для Композиції
        public AiSoftwareCore AI
        {
            get { return _ai; }
            set { _ai = value; }
        }

        public SmartScales Scales
        {
            get { return _scales; }
            set { _scales = value; }
        }

        public FoodQualitySystem QualitySystem
        {
            get { return _qualitySystem; }
            set { _qualitySystem = value; }
        }

        // Аксесори для Агрегації
        public HyperspectralCamera Camera
        {
            get { return _camera; }
            set { _camera = value; }
        }

        public BuiltInStove Stove
        {
            get { return _stove; }
            set { _stove = value; }
        }

        public MultiTouchDisplay Display
        {
            get { return _display; }
            set { _display = value; }
        }

        public ArProjector Projector
        {
            get { return _projector; }
            set { _projector = value; }
        }

        public WirelessDock Dock
        {
            get { return _dock; }
            set { _dock = value; }
        }

        public CulinaryPredictionModule PredictionModule
        {
            get { return _predictionModule; }
            set { _predictionModule = value; }
        }

        public NeuroCulinaryInterface NeuroInterface
        {
            get { return _neuroInterface; }
            set { _neuroInterface = value; }
        }

        public HolographicChef HoloChef
        {
            get { return _holoChef; }
            set { _holoChef = value; }
        }

        public HealthAnalyzer HealthAnalyzer
        {
            get { return _healthAnalyzer; }
            set { _healthAnalyzer = value; }
        }

        // === 3. ПОДІЇ (Events) ===
        // Стіл виступає Видавцем (Publisher). Він лише "оголошує" ці події, 
        // а хто на них підпишеться - столу байдуже (Слабке зв'язування).
        public event KitchenEventHandler OnScanStarted;
        public event KitchenEventHandler OnBadProductDetected;
        public event KitchenEventHandler OnDnaAnalyzed;
        public event KitchenEventHandler OnNutritionCalculated;
        public event KitchenEventHandler OnNeuroActivated;

        // === 4. КОНСТРУКТОР ===
        // Спрацьовує один раз під час створення об'єкта столу через оператор new.
        public SmartKitchenTable(
            HyperspectralCamera camera, BuiltInStove stove, MultiTouchDisplay display,
            ArProjector projector, WirelessDock dock, CulinaryPredictionModule predictionModule,
            NeuroCulinaryInterface neuroInterface, HolographicChef holoChef, HealthAnalyzer healthAnalyzer)
        {
            // Ініціалізація властивостей, успадкованих від SmartDevice
            ID = "101";
            Model = "SmartKitchen FX-9000";
            WorkMode = "Очікування";
            UserProfile = "Гість";

            // КОМПОЗИЦІЯ: Стіл САМ створює ці об'єкти всередині себе (через new).
            // Якщо стіл видалити, ці об'єкти теж зникнуть. Вони - невіддільна частина столу.
            AI = new AiSoftwareCore();
            Scales = new SmartScales();
            QualitySystem = new FoodQualitySystem();

            // АГРЕГАЦІЯ: Пристрої прийшли вже готові ззовні (через параметри конструктора).
            // Стіл просто зберігає посилання на них. Якщо стіл видалити, ці пристрої продовжать існувати.
            Camera = camera;
            Stove = stove;
            Display = display;
            Projector = projector;
            Dock = dock;
            PredictionModule = predictionModule;
            NeuroInterface = neuroInterface;
            HoloChef = holoChef;
            HealthAnalyzer = healthAnalyzer;
        }

        // === 5. ПЕРЕВИЗНАЧЕННЯ БАЗОВИХ МЕТОДІВ (Поліморфізм) ===
        // Ключове слово override вказує, що ми даємо конкретну реалізацію абстрактним методам базового класу.
        public override void Init()
        {
            Service.Print("Кухонний стіл: Ініціалізація систем...");
        }

        public override void SelfDiag()
        {
            Service.Print("Кухонний стіл: Самодіагностика...");
        }

        // Віртуальний метод (virtual) можна доповнити. base.SwitchMode викликає логіку предка.
        public override void SwitchMode(string mode)
        {
            base.SwitchMode(mode);
            Service.Print("Кухонний стіл: Додаткові налаштування режиму застосовано.");
        }

        // === 6. ОСНОВНИЙ СЦЕНАРІЙ (Use Case) ===
        // Об'єкти moodSensor, recipeGen та foodScanner передаються сюди як параметри методу.
        // Це зв'язок АСОЦІАЦІЯ: вони потрібні столу лише на час виконання цього конкретного методу.
        public void ExecuteScenario(UserMoodSensor moodSensor, RecipeGenerator recipeGen, FoodStructureScanner foodScanner)
        {
            Service.Print($"\n=== ЗАПУСК СЦЕНАРІЮ ДЛЯ КОРИСТУВАЧА: ===");

            Dock.ChargeDevices();
            // Знак ?. (Null-conditional operator) перевіряє, чи є підписники на подію.
            // Якщо є (не null), викликається Invoke(), що "вистрілює" подію.
            OnNeuroActivated?.Invoke("Фіксація фокусу уваги на страві.");
            NeuroInterface.ReadBrainWaves();
            moodSensor.AnalyzeMood();

            OnDnaAnalyzed?.Invoke("Аналіз ДНК на лактозу.");
            HealthAnalyzer.ScanBioProfile();

            OnScanStarted?.Invoke("Продукти покладено на стіл.");
            Camera.CaptureSpectrum();
            foodScanner.ScanInternalStructure();

            OnBadProductDetected?.Invoke("Виявлено гнилий томат.");
            QualitySystem.CheckFreshness();
            recipeGen.GenerateAlternative();

            OnNutritionCalculated?.Invoke("Білків: 40г, Жирів: 20г, Вуглеводів: 15г");
            AI.ProcessData();
            PredictionModule.PredictTrends();

            Display.RenderInterface();
            Projector.ShowSteps();
            Projector.ArAssistant();
            HoloChef.DisplayChef();

            Scales.AutoWeigh();
            Stove.AutoCook();

            Service.Print("=== СЦЕНАРІЙ УСПІШНО ЗАВЕРШЕНО ===");
            SwitchMode("Енергозбереження");
        }
    }
}