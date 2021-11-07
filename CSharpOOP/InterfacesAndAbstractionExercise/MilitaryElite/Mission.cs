using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Mission : IMission
    {
        public Mission(string codeName, string missionState)
        {
            CodeName = codeName;

            ParseMission(missionState);

        }

        public string CodeName { get; private set; }

        public MissionState MissionState { get; private set; }

        public void CompleteMission()
        {
            this.MissionState = MissionState.Finished;
        }
        private void ParseMission(string missionState)
        {

            var parsed = Enum.TryParse(missionState, out MissionState currentMissionState);

            if (!parsed)
            {
                throw new ArgumentException();
            }

            MissionState = currentMissionState;
        }
        public override string ToString()
        {
            return $"Code Name: {CodeName} State: {MissionState}";
        }
    }
}
