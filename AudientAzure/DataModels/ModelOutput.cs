﻿using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace AudientAzure.DataModels
{
    public class ModelOutput
    {
        // ColumnName attribute is used to change the column name from
        // its default value, which is the name of the field.
        [ColumnName("PredictedLabel")]
        public String Prediction { get; set; }
        public float[] Score { get; set; }
    }
}
