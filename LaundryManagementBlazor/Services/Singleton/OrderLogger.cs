namespace LaundryManagmentSystem.Singleton
{
    public sealed class OrderLogger
    {
        private static OrderLogger? _instance;

        // Lazily-resolved reference to avoid circular constructor dependency
        private static Func<string, DateTime, bool>? _addLog;

        private OrderLogger() { }

        public static OrderLogger GetInstance()
        {
            if (_instance == null)
                _instance = new OrderLogger();
            return _instance;
        }

        // Called once at startup by LaundryAppService
        public void Initialize(object appService)
        {
            if (appService is LaundryManagementBlazor.Services.LaundryAppService svc)
                _addLog = (msg, ts) => { svc.AddLog(msg); return true; };
        }

        public void Log(string message)
        {
            _addLog?.Invoke(message, DateTime.Now);
        }

    }//end of class OrderLogger
}//end of namespace LaundryManagmentSystem.Singleton
