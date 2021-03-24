using System;

namespace Grimoire.Botting
{
    public interface IBotEngine
    {
        bool IsRunning
        {
            get;
            set;
        }

        int Index
        {
            get;
            set;
        }

        Configuration Configuration
        {
            get;
            set;
        }

        event Action<bool> IsRunningChanged;

        event Action<int> IndexChanged;

        event Action<Configuration> ConfigurationChanged;

        void Start(Configuration config);

        void Stop();
    }
}