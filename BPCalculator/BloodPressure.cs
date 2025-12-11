using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace BPCalculator
{
    // BP categories
    public enum BPCategory
    {
        [Display(Name="Low Blood Pressure")] Low,
        [Display(Name="Ideal Blood Pressure")]  Ideal,
        [Display(Name="Pre-High Blood Pressure")] PreHigh,
        [Display(Name ="High Blood Pressure")]  High,
        [Display(Name = "Enter Valid Entries Please")] EnterValues,
        [Display(Name = "Diastolic Value Can Not Be Greater Than Systolic Value")] DiastolicCanNotBeGreaterThanSystolic
    };

    public class BloodPressure
    {
        public const int SystolicMin = 70;
        public const int SystolicMax = 190;
        public const int DiastolicMin = 40;
        public const int DiastolicMax = 100;

        [Range(SystolicMin, SystolicMax, ErrorMessage = "Invalid Systolic Value")]
        public int Systolic { get; set; }                       // mmHG

        [Range(DiastolicMin, DiastolicMax, ErrorMessage = "Invalid Diastolic Value")]
        public int Diastolic { get; set; }                      // mmHG

        // calculate BP category...
        public BPCategory Category
        {
            get
            {
                if(Diastolic ==0 && Systolic ==0)
                    return BPCategory.EnterValues;
                if(Diastolic > Systolic)
                    return BPCategory.DiastolicCanNotBeGreaterThanSystolic;
                if (Diastolic<=60 && Systolic<=90)
                    return BPCategory.Low;
                else if ((Diastolic > 60 && Diastolic <= 80) &&  (Systolic > 90 && Systolic <= 120))
                    return BPCategory.Ideal;
                else if ((Diastolic > 80 && Diastolic <= 90) && (Systolic > 120 && Systolic <= 140))
                    return BPCategory.PreHigh;
                else 
                    return BPCategory.High;
            }
        }

        public string HealthAdvice
        {
            get
            {
                return Category switch
                {
                    BPCategory.Low => "Your blood pressure is low. Stay hydrated and consult a doctor if you feel dizzy.",
                    BPCategory.Ideal => "Your blood pressure is ideal. Keep maintaining a healthy lifestyle.",
                    BPCategory.PreHigh => "Your blood pressure is slightly high. Consider reducing salt and exercising.",
                    BPCategory.High => "Your blood pressure is high. Please consult a healthcare professional immediately.",
                    _ => ""
                };
            }
        }
    }
}
