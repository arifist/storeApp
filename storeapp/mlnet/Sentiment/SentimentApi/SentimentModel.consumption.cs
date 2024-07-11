﻿// This file was auto-generated by ML.NET Model Builder. 
using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
public partial class SentimentModel
{
    /// <summary>
    /// model input class for SentimentModel.
    /// </summary>
    #region model input class
    public class ModelInput
    {
        [ColumnName(@"Label")]
        public bool Label { get; set; }

        [ColumnName(@"Text")]
        public string Text { get; set; }

    }

    #endregion

    /// <summary>
    /// model output class for SentimentModel.
    /// </summary>
    #region model output class
    public class ModelOutput
    {
        [ColumnName("PredictedLabel")]
        public bool Prediction { get; set; }

        public float Score { get; set; }

        // The probability calculated by calibrating the score of having true as the label.
        public float Probability { get; set; }
    }

    #endregion

    private static string MLNetModelPath = Path.GetFullPath("SentimentModel.zip");

    public static readonly Lazy<PredictionEngine<ModelInput, ModelOutput>> PredictEngine = new Lazy<PredictionEngine<ModelInput, ModelOutput>>(() => CreatePredictEngine(), true);

    /// <summary>
    /// Use this method to predict on <see cref="ModelInput"/>.
    /// </summary>
    /// <param name="input">model input.</param>
    /// <returns><seealso cref=" ModelOutput"/></returns>
    public static ModelOutput Predict(ModelInput input)
    {
        var predEngine = PredictEngine.Value;
        return predEngine.Predict(input);
    }

    private static PredictionEngine<ModelInput, ModelOutput> CreatePredictEngine()
    {
        var mlContext = new MLContext();
        ITransformer mlModel = mlContext.Model.Load(MLNetModelPath, out var _);
        return mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);
    }
}
