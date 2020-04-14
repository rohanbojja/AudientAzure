using System;
using System.Collections.Generic;
using System.Text;
using MvvmHelpers;

namespace AudientAzure.DataModels
{
    public class Genre: ObservableObject
    {
        float _score;
        public float Score
        {
            get
            {
                return _score;
            }
            set
            {
                SetProperty(ref _score, value);
            }
        }

        string _label = String.Empty;
        public string Label
        {
            get
            {
                return _label;
            }
            set
            {
                SetProperty(ref _label, value);
            }
        }
    }
}
