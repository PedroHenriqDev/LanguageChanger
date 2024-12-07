using Xunit;
using LanguageChanger.Entities;

namespace LanguageChanger.Tests
{
    public class LanguageTrackerTests
    {
        private readonly LanguageTracker _langTracker = new LanguageTracker(new LanguageTrackerConfig());

        [Fact]
        public void GetText_WhenAllParamsIsValid_ShouldReturnValue()
        {
            string? message = _langTracker.GetText("Message", fileName: "Default");

            Assert.NotNull(message);
        }

        [Fact]
        public void GetTexts_WhenAllParamsIsValid_ShouldReturnValue()
        {
            Dictionary<string, string?> messages = _langTracker.GetTexts("Conditions", fileName: "Default");

            Assert.NotNull(messages);
            Assert.Contains("Must contains", messages.Values);
            Assert.True(messages.Count >= 0);
        }
    }
}
