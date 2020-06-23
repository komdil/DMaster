namespace DMaster.Model.Helpers
{
    public static class Global
    {
        static MainContext mainContext;
        public static MainContext MainContext
        {
            get
            {
                if (mainContext == null)
                {
                    mainContext = new MainContext();
                }
                return mainContext;
            }
        }
    }
}
