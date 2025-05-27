using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using JuicyDI.Attributes;

namespace JuicyDI
{
    public class GameSequenceController
    {
        public GameSequenceController(List<ISequence> sequenceElements)
        {
            var sortedSequence = sequenceElements
                .OrderBy(type => type.GetType().GetCustomAttribute<SequenceParticipant>().Number)
                .ToList();

            for (int i = 0; i < sortedSequence.Count; i++)
            {
                sortedSequence[i].MethodStart();
            }
        }
    }
}