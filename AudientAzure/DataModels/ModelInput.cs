﻿using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace AudientAzure.DataModels
{
    public class ModelInput
    {
        [ColumnName("genre"), LoadColumn(0)]
        public string Genre { get; set; }


        [ColumnName("mfcc0"), LoadColumn(1)]
        public float Mfcc0 { get; set; }


        [ColumnName("mfcc1"), LoadColumn(2)]
        public float Mfcc1 { get; set; }


        [ColumnName("mfcc2"), LoadColumn(3)]
        public float Mfcc2 { get; set; }


        [ColumnName("mfcc3"), LoadColumn(4)]
        public float Mfcc3 { get; set; }


        [ColumnName("mfcc4"), LoadColumn(5)]
        public float Mfcc4 { get; set; }


        [ColumnName("mfcc5"), LoadColumn(6)]
        public float Mfcc5 { get; set; }


        [ColumnName("mfcc6"), LoadColumn(7)]
        public float Mfcc6 { get; set; }


        [ColumnName("mfcc7"), LoadColumn(8)]
        public float Mfcc7 { get; set; }


        [ColumnName("mfcc8"), LoadColumn(9)]
        public float Mfcc8 { get; set; }


        [ColumnName("mfcc9"), LoadColumn(10)]
        public float Mfcc9 { get; set; }


        [ColumnName("mfcc10"), LoadColumn(11)]
        public float Mfcc10 { get; set; }


        [ColumnName("mfcc11"), LoadColumn(12)]
        public float Mfcc11 { get; set; }


        [ColumnName("mfcc12"), LoadColumn(13)]
        public float Mfcc12 { get; set; }


        [ColumnName("mfcc13"), LoadColumn(14)]
        public float Mfcc13 { get; set; }


        [ColumnName("mfcc14"), LoadColumn(15)]
        public float Mfcc14 { get; set; }


        [ColumnName("mfcc15"), LoadColumn(16)]
        public float Mfcc15 { get; set; }


        [ColumnName("mfcc16"), LoadColumn(17)]
        public float Mfcc16 { get; set; }


        [ColumnName("mfcc17"), LoadColumn(18)]
        public float Mfcc17 { get; set; }


        [ColumnName("mfcc18"), LoadColumn(19)]
        public float Mfcc18 { get; set; }


        [ColumnName("mfcc19"), LoadColumn(20)]
        public float Mfcc19 { get; set; }


        [ColumnName("mfcc20"), LoadColumn(21)]
        public float Mfcc20 { get; set; }


        [ColumnName("mfcc21"), LoadColumn(22)]
        public float Mfcc21 { get; set; }


        [ColumnName("mfcc22"), LoadColumn(23)]
        public float Mfcc22 { get; set; }


        [ColumnName("mfcc23"), LoadColumn(24)]
        public float Mfcc23 { get; set; }


        [ColumnName("energy"), LoadColumn(25)]
        public float Energy { get; set; }


        [ColumnName("rms"), LoadColumn(26)]
        public float Rms { get; set; }


        [ColumnName("zcr"), LoadColumn(27)]
        public float Zcr { get; set; }


        [ColumnName("entropy"), LoadColumn(28)]
        public float Entropy { get; set; }


        [ColumnName("centroid"), LoadColumn(29)]
        public float Centroid { get; set; }


        [ColumnName("spread"), LoadColumn(30)]
        public float Spread { get; set; }


        [ColumnName("flatness"), LoadColumn(31)]
        public float Flatness { get; set; }


        [ColumnName("noiseness"), LoadColumn(32)]
        public float Noiseness { get; set; }


        [ColumnName("roloff"), LoadColumn(33)]
        public float Roloff { get; set; }


        [ColumnName("crest"), LoadColumn(34)]
        public float Crest { get; set; }


        [ColumnName("decrease"), LoadColumn(35)]
        public float Decrease { get; set; }


        [ColumnName("spectral_entropy"), LoadColumn(36)]
        public float Spectral_entropy { get; set; }


    }
}
