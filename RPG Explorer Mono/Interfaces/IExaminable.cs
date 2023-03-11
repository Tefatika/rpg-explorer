using System;

namespace RPGExplorer.Interfaces
{
    class ExaminedEventArgs : EventArgs
    {
        public IPerceptor Perceptor { get; }

        public ExaminedEventArgs(IPerceptor perceptor = null) => Perceptor = perceptor;
    }

    interface IExaminable
    {
        event EventHandler<ExaminedEventArgs> Examined;

        void Examine(IPerceptor perceptor);
    }
}