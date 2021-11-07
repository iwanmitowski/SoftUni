using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public interface IMission
    {
        public string CodeName { get; }
        public MissionState MissionState { get; }
        public void CompleteMission();
    }
}
