namespace ChampionshipProblem.Classes.ResultClasses
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Die Klasse repräsentiert das Ergebnis des Algorithmus, ob ein Verein noch Meister werden kann.
    /// </summary>
    public class ChampionComputationalResult : IComputationalResult
    {
        #region ctors
        /// <summary>
        /// Konstruktor zum Erstellen des ChampionComputationalResult.
        /// </summary>
        public ChampionComputationalResult()
        {
            this.ComputationalStanding = new List<LeagueStandingEntry>();
            this.MissingRemainingMatches = new List<RemainingMatch>();
        }

        /// <summary>
        /// Konstruktor zum Erstellen des ChampionComputationalResult.
        /// </summary>
        /// <param name="computationalStanding">Das ausgerechnete Ergebnis.</param>
        public ChampionComputationalResult(List<LeagueStandingEntry> computationalStanding)
        {
            this.ComputationalStanding = computationalStanding;
            this.MissingRemainingMatches = new List<RemainingMatch>();
        }

        /// <summary>
        /// Konstruktor zum Erstellen des ChampionComputationalResult.
        /// </summary>
        /// <param name="computationalStanding">Das ausgerechnete Ergebnis.</param>
        /// <param name="missingRemainingMatches">Die Spiele.</param>
        public ChampionComputationalResult(List<LeagueStandingEntry> computationalStanding, List<RemainingMatch> missingRemainingMatches)
        {
            this.ComputationalStanding = computationalStanding;
            this.MissingRemainingMatches = missingRemainingMatches;
            this.ComputeWinPercentages();
        }
        #endregion

        #region CanWinChampionship
        /// <summary>
        /// Ob der Verein die Meisterschaft gewinnen kann.
        /// </summary>
        public bool? CanWinChampionship { get; set; }
        #endregion

        #region ComputationalStanding
        /// <summary>
        /// Die Tabelle, welche aus der Berechnung resultiert.
        /// </summary>
        public List<LeagueStandingEntry> ComputationalStanding { get; private set; }
        #endregion

        #region MissingRemainingMatches
        /// <summary>
        /// Die Liste der fehlenden Spiele mit den Ergebnissen.
        /// </summary>
        public List<RemainingMatch> MissingRemainingMatches { get; set; }
        #endregion

        #region NeededGoalDifference
        /// <summary>
        /// Die benötigte Tordifferenz.
        /// </summary>
        public int? NeededGoalDifference { get; set; }
        #endregion

        #region B365Percentage
        /// <summary>
        /// Prozentuale Gewinnwahrscheinlichkeit von B365.
        /// </summary>
        public decimal B365Percentage { get; private set; }
        #endregion

        #region BSPercentage
        /// <summary>
        /// Prozentuale Gewinnwahrscheinlichkeit von Blue Square.
        /// </summary>
        public decimal BSPercentage { get; private set; }
        #endregion

        #region BWPercentage
        /// <summary>
        /// Prozentuale Gewinnwahrscheinlichkeit von Bet & Win.
        /// </summary>
        public decimal BWPercentage { get; private set; }
        #endregion

        #region GBPercentage
        /// <summary>
        /// Prozentuale Gewinnwahrscheinlichkeit von Gamebookers.
        /// </summary>
        public decimal GBPercentage { get; private set; }
        #endregion

        #region IWPercentage
        /// <summary>
        /// Prozentuale Gewinnwahrscheinlichkeit von Interwetten.
        /// </summary>
        public decimal IWPercentage { get; private set; }
        #endregion

        #region LBPercentage
        /// <summary>
        /// Prozentuale Gewinnwahrscheinlichkeit von Ladbrokes.
        /// </summary>
        public decimal LBPercentage { get; private set; }
        #endregion

        #region PSPercentage
        /// <summary>
        /// Prozentuale Gewinnwahrscheinlichkeit von Pinnacle.
        /// </summary>
        public decimal PSPercentage { get; private set; }
        #endregion

        #region SJPercentage
        /// <summary>
        /// Prozentuale Gewinnwahrscheinlichkeit von Snow James.
        /// </summary>
        public decimal SJPercentage { get; private set; }
        #endregion

        #region VCPercentage
        /// <summary>
        /// Prozentuale Gewinnwahrscheinlichkeit von VC Bet.
        /// </summary>
        public decimal VCPercentage { get; private set; }
        #endregion

        #region WHPercentage
        /// <summary>
        /// Prozentuale Gewinnwahrscheinlichkeit von William Hill.
        /// </summary>
        public decimal WHPercentage { get; private set; }
        #endregion

        #region ComputeWinPercentages
        /// <summary>
        /// Methode zum Ermitteln der Siegwahrscheinlichkeiten der Wettquoten.
        /// </summary>
        public void ComputeWinPercentages()
        {
            B365Percentage = 100;
            BSPercentage = 100;
            BWPercentage = 100;
            GBPercentage = 100;
            IWPercentage = 100;
            LBPercentage = 100;
            PSPercentage = 100;
            SJPercentage = 100;
            VCPercentage = 100;
            WHPercentage = 100;

            foreach (RemainingMatch remainingMatch in this.MissingRemainingMatches)
            {
                switch (remainingMatch.MatchResult)
                {
                    case MatchResult.WinHome:
                        B365Percentage *= (remainingMatch.B365H.HasValue && remainingMatch.B365H.Value != 0) ? 1 / remainingMatch.B365H.Value : 0;
                        BSPercentage *= (remainingMatch.BSH.HasValue && remainingMatch.BSH.Value != 0) ? 1 / remainingMatch.BSH.Value : 0;
                        BWPercentage *= (remainingMatch.BWH.HasValue && remainingMatch.BWH.Value != 0) ? 1 / remainingMatch.BWH.Value : 0;
                        GBPercentage *= (remainingMatch.GBH.HasValue && remainingMatch.GBH.Value != 0) ? 1 / remainingMatch.GBH.Value : 0;
                        IWPercentage *= (remainingMatch.IWH.HasValue && remainingMatch.IWH.Value != 0) ? 1 / remainingMatch.IWH.Value : 0;
                        LBPercentage *= (remainingMatch.LBH.HasValue && remainingMatch.LBH.Value != 0) ? 1 / remainingMatch.LBH.Value : 0;
                        PSPercentage *= (remainingMatch.PSH.HasValue && remainingMatch.PSH.Value != 0) ? 1 / remainingMatch.PSH.Value : 0;
                        SJPercentage *= (remainingMatch.SJH.HasValue && remainingMatch.SJH.Value != 0) ? 1 / remainingMatch.SJH.Value : 0;
                        VCPercentage *= (remainingMatch.VCH.HasValue && remainingMatch.VCH.Value != 0) ? 1 / remainingMatch.VCH.Value : 0;
                        WHPercentage *= (remainingMatch.WHH.HasValue && remainingMatch.WHH.Value != 0) ? 1 / remainingMatch.WHH.Value : 0;
                        break;
                    case MatchResult.WinGuest:
                        B365Percentage *= (remainingMatch.B365A.HasValue && remainingMatch.B365A.Value != 0) ? 1 / remainingMatch.B365A.Value : 0;
                        BSPercentage *= (remainingMatch.BSA.HasValue && remainingMatch.BSA.Value != 0) ? 1 / remainingMatch.BSA.Value : 0;
                        BWPercentage *= (remainingMatch.BWA.HasValue && remainingMatch.BWA.Value != 0) ? 1 / remainingMatch.BWA.Value : 0;
                        GBPercentage *= (remainingMatch.GBA.HasValue && remainingMatch.GBA.Value != 0) ? 1 / remainingMatch.GBA.Value : 0;
                        IWPercentage *= (remainingMatch.IWA.HasValue && remainingMatch.IWA.Value != 0) ? 1 / remainingMatch.IWA.Value : 0;
                        LBPercentage *= (remainingMatch.LBA.HasValue && remainingMatch.LBA.Value != 0) ? 1 / remainingMatch.LBA.Value : 0;
                        PSPercentage *= (remainingMatch.PSA.HasValue && remainingMatch.PSA.Value != 0) ? 1 / remainingMatch.PSA.Value : 0;
                        SJPercentage *= (remainingMatch.SJA.HasValue && remainingMatch.SJA.Value != 0) ? 1 / remainingMatch.SJA.Value : 0;
                        VCPercentage *= (remainingMatch.VCA.HasValue && remainingMatch.VCA.Value != 0) ? 1 / remainingMatch.VCA.Value : 0;
                        WHPercentage *= (remainingMatch.WHA.HasValue && remainingMatch.WHA.Value != 0) ? 1 / remainingMatch.WHA.Value : 0;
                        break;
                    case MatchResult.Tie:
                        B365Percentage *= (remainingMatch.B365D.HasValue && remainingMatch.B365D.Value != 0) ? 1 / remainingMatch.B365D.Value : 0;
                        BSPercentage *= (remainingMatch.BSD.HasValue && remainingMatch.BSD.Value != 0) ? 1 / remainingMatch.BSD.Value : 0;
                        BWPercentage *= (remainingMatch.BWD.HasValue && remainingMatch.BWD.Value != 0) ? 1 / remainingMatch.BWD.Value : 0;
                        GBPercentage *= (remainingMatch.GBD.HasValue && remainingMatch.GBD.Value != 0) ? 1 / remainingMatch.GBD.Value : 0;
                        IWPercentage *= (remainingMatch.IWD.HasValue && remainingMatch.IWD.Value != 0) ? 1 / remainingMatch.IWD.Value : 0;
                        LBPercentage *= (remainingMatch.LBD.HasValue && remainingMatch.LBD.Value != 0) ? 1 / remainingMatch.LBD.Value : 0;
                        PSPercentage *= (remainingMatch.PSD.HasValue && remainingMatch.PSD.Value != 0) ? 1 / remainingMatch.PSD.Value : 0;
                        SJPercentage *= (remainingMatch.SJD.HasValue && remainingMatch.SJD.Value != 0) ? 1 / remainingMatch.SJD.Value : 0;
                        VCPercentage *= (remainingMatch.VCD.HasValue && remainingMatch.VCD.Value != 0) ? 1 / remainingMatch.VCD.Value : 0;
                        WHPercentage *= (remainingMatch.WHD.HasValue && remainingMatch.WHD.Value != 0) ? 1 / remainingMatch.WHD.Value : 0;
                        break;
                    default:
                        throw new Exception("Unkown match result type.");
                }
            }
        }
        #endregion
    }
}
