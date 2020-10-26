using OceanAirdrop;
using System.Collections.Generic;
using TimeTracker.Data;

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
