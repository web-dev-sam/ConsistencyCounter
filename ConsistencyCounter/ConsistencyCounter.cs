using CountersPlus.Counters.Custom;
using CountersPlus.Counters.Interfaces;
using IPA.Config.Data;
using ModestTree;
using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using Zenject;

namespace ConsistencyCounter
{
    public class ConsistencyCounter : BasicCustomCounter
    {
        [Inject] ScoreController scoreController;

        private readonly bool SHOW_LABEL = Config.Instance.EnableLabel;
        private readonly bool SEPARATE_HANDS = Config.Instance.SeparateSaber;
        private readonly int DECIMALS = Config.Instance.DecimalPrecision;
        private readonly string LABEL_TEXT = "Acc Consistency";
        private readonly float LABEL_FONT_SIZE = Config.Instance.LabelFontSize;
        private readonly float FIGURE_FONT_SIZE = Config.Instance.FigureFontSize;
        private readonly bool INCLUDE_SWING = Config.Instance.IncludeSwingScore;

        private readonly float posX = Config.Instance.OffsetX;
        private readonly float posY = Config.Instance.OffsetY;
        private readonly float posZ = Config.Instance.OffsetZ;
        private TMP_Text leftCounterText;
        private TMP_Text rightCounterText;

        private readonly List<double> leftAccuracyList = new List<double>();
        private readonly List<double> rightAccuracyList = new List<double>();
        private readonly List<double> combinedAccuracyList = new List<double>();

        public override void CounterInit()
        {
            if (SHOW_LABEL)
            {
                TMP_Text label = CanvasUtility.CreateTextFromSettings(Settings, new Vector3(posX, posY, posZ));
                label.text = LABEL_TEXT;
                label.fontSize = LABEL_FONT_SIZE;
            }

            Vector3 leftOffset = new Vector3(posX, posY - .2f, posZ);
            TextAlignmentOptions leftAlign = TextAlignmentOptions.Top;
            if (SEPARATE_HANDS)
            {
                rightCounterText = CanvasUtility.CreateTextFromSettings(Settings, new Vector3(posX + .2f, posY - .2f, posZ));
                rightCounterText.lineSpacing = -26;
                rightCounterText.fontSize = FIGURE_FONT_SIZE;
                rightCounterText.text = "100.0";
                rightCounterText.alignment = TextAlignmentOptions.TopLeft;

                leftOffset = new Vector3(posX - .2f, posY - .2f, posZ);
                leftAlign = TextAlignmentOptions.TopRight;
            }

            leftCounterText = CanvasUtility.CreateTextFromSettings(Settings, leftOffset);
            leftCounterText.lineSpacing = -26;
            leftCounterText.fontSize = FIGURE_FONT_SIZE;
            leftCounterText.text = "100.0";
            leftCounterText.alignment = leftAlign;

            scoreController.scoringForNoteFinishedEvent += ScoreController_scoringForNoteFinishedEvent;
        }


        private void ScoreController_scoringForNoteFinishedEvent(ScoringElement scoringElement)
        {
            if (!(scoringElement is GoodCutScoringElement goodCut))
            {
                return;
            }

            int cutDistance = goodCut.cutScoreBuffer.centerDistanceCutScore;
            int totalCut = goodCut.cutScoreBuffer.cutScore;
            bool isLeftHandEvent = goodCut.noteData.colorType == ColorType.ColorA;
            bool isRelevantNoteEvent =
                goodCut.noteData.scoringType == NoteData.ScoringType.Normal ||
                goodCut.noteData.scoringType == NoteData.ScoringType.BurstSliderHead;

            if (isRelevantNoteEvent)
            {
                List<double> handAccuracyList = isLeftHandEvent ? leftAccuracyList : rightAccuracyList;
                handAccuracyList.Add(INCLUDE_SWING ? totalCut : cutDistance);
                combinedAccuracyList.Add(INCLUDE_SWING ? totalCut : cutDistance);
            }

            if (!SEPARATE_HANDS)
            {
                leftCounterText.text = GetStandardDeviation(combinedAccuracyList).ToString($"F{DECIMALS}");
                return;
            }

            if (isLeftHandEvent)
                leftCounterText.text = GetStandardDeviation(leftAccuracyList).ToString($"F{DECIMALS}");
            else rightCounterText.text = GetStandardDeviation(rightAccuracyList).ToString($"F{DECIMALS}");
        }

        private double GetStandardDeviation(List<double> values)
        {
            if (values.IsEmpty()) return 100.0;

            double average = values.Average();
            double sumOfSquares = values.Sum(x => Math.Pow(x - average, 2));
            double standardDeviation = Math.Sqrt(sumOfSquares / values.Count);
            double normalizedNoSwingStandardDeviation = (7.5f - standardDeviation) * 100f / 7.5f;
            double normalizedWithSwingStandardDeviation = (57.5f - standardDeviation) * 100f / 57.5f;
            return INCLUDE_SWING ? normalizedWithSwingStandardDeviation : normalizedNoSwingStandardDeviation;
        }

        public void OnNoteMiss(NoteData data) { }

        public void OnNoteCut(NoteData data, NoteCutInfo info) { }

        public override void CounterDestroy() {
            leftCounterText = null;
            rightCounterText = null;
            scoreController.scoringForNoteFinishedEvent -= ScoreController_scoringForNoteFinishedEvent;
        }

    }
}
