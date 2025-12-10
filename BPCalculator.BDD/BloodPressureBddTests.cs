using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPCalculator.BDD
{
    public class BloodPressureBddTests
    {
        private int _systolic;
        private int _diastolic;
        private BPCategory _result;

        // GIVEN
        private void GivenSystolicIs(int value)
        {
            _systolic = value;
        }

        private void GivenDiastolicIs(int value)
        {
            _diastolic = value;
        }

        // WHEN
        private void WhenBloodPressureIsCalculated()
        {
            var bp = new BloodPressure
            {
                Systolic = _systolic,
                Diastolic = _diastolic
            };

            _result = bp.Category;
        }

        // THEN
        private void ThenCategoryShouldBe(BPCategory expected)
        {
            Assert.Equal(expected, _result);
        }

        [Fact]
        public void Low_Blood_Pressure_Scenario()
        {
            GivenSystolicIs(90);
            GivenDiastolicIs(60);
            WhenBloodPressureIsCalculated();
            ThenCategoryShouldBe(BPCategory.Low);
        }

        [Fact]
        public void Ideal_Blood_Pressure_Scenario()
        {
            GivenSystolicIs(120);
            GivenDiastolicIs(80);
            WhenBloodPressureIsCalculated();
            ThenCategoryShouldBe(BPCategory.Ideal);
        }

        [Fact]
        public void PreHigh_Blood_Pressure_Scenario()
        {
            GivenSystolicIs(140);
            GivenDiastolicIs(90);
            WhenBloodPressureIsCalculated();
            ThenCategoryShouldBe(BPCategory.PreHigh);
        }

        [Fact]
        public void High_Blood_Pressure_Scenario()
        {
            GivenSystolicIs(150);
            GivenDiastolicIs(95);
            WhenBloodPressureIsCalculated();
            ThenCategoryShouldBe(BPCategory.High);
        }
    }
}
