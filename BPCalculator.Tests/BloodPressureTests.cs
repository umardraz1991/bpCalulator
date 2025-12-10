namespace BPCalculator.Tests
{
    public class BloodPressureTests
    {
        [Theory]
        [InlineData(90, 60, BPCategory.Low)]
        [InlineData(120, 80, BPCategory.Ideal)]
        [InlineData(140, 90, BPCategory.PreHigh)]
        [InlineData(150, 95, BPCategory.High)]
        public void Category_ReturnsExpectedCategory(
            int systolic,
            int diastolic,
            BPCategory expected)
        {
            // Arrange
            var bp = new BloodPressure
            {
                Systolic = systolic,
                Diastolic = diastolic
            };

            // Act
            var category = bp.Category;

            // Assert
            Assert.Equal(expected, category);
        }

        [Fact]
        public void Category_ReturnsEnterValues_WhenBothZero()
        {
            // Arrange
            var bp = new BloodPressure
            {
                Systolic = 0,
                Diastolic = 0
            };

            // Act
            var category = bp.Category;

            // Assert
            Assert.Equal(BPCategory.EnterValues, category);
        }

        [Fact]
        public void Category_ReturnsError_WhenDiastolicGreaterThanSystolic()
        {
            // Arrange
            var bp = new BloodPressure
            {
                Systolic = 100,
                Diastolic = 110
            };

            // Act
            var category = bp.Category;

            // Assert
            Assert.Equal(
                BPCategory.DiastolicCanNotBeGreaterThanSystolic,
                category);
        }

        [Theory]
        [InlineData(90, 60, "Your blood pressure is low. Stay hydrated and consult a doctor if you feel dizzy.")]
        [InlineData(120, 80, "Your blood pressure is ideal. Keep maintaining a healthy lifestyle.")]
        [InlineData(140, 90, "Your blood pressure is slightly high. Consider reducing salt and exercising.")]
        [InlineData(150, 95, "Your blood pressure is high. Please consult a healthcare professional immediately.")]
        public void HealthAdvice_MatchesCategoryMessage(
            int systolic,
            int diastolic,
            string expectedAdvice)
        {
            // Arrange
            var bp = new BloodPressure
            {
                Systolic = systolic,
                Diastolic = diastolic
            };

            // Act
            var advice = bp.HealthAdvice;

            // Assert
            Assert.Equal(expectedAdvice, advice);
        }
    }
}
