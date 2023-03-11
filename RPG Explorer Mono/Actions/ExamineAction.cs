using RPGExplorer.Interfaces;
using System;

namespace RPGExplorer.Actions
{
    class ExamineAction : IAction
    {
        // Inherited by IAction
        public void Execute() => Examinable.Examine(Perceptor);

        // ExamineAction
        private IExaminable Examinable { get; }
        private IPerceptor Perceptor { get; }

        public ExamineAction(IExaminable examinable, IPerceptor perceptor)
        {
            Examinable = examinable ?? throw new ArgumentNullException("[ExamineAction] - examinable was null.");
            Perceptor = perceptor ?? throw new ArgumentNullException("[ExamineAction] - perceptor was null.");
        }
    }
}