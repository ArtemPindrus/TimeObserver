using TimeObserver.Models.Reminders;

namespace TimeObserver.Tests {
    public class IntervalReminderTests {
        [Fact]
        public void TriggersAtRightTimeWithNoElapsedTime() {
            IntervalReminder intervalReminder = new(TimeSpan.FromSeconds(5));

            Check();

            intervalReminder.Reset();

            Check();

            void Check() {
                Assert.True(intervalReminder.Update(TimeSpan.FromSeconds(5)));
                Assert.True(intervalReminder.Update(TimeSpan.FromSeconds(10)));
                Assert.True(intervalReminder.Update(TimeSpan.FromSeconds(15)));
                Assert.False(intervalReminder.Update(TimeSpan.FromSeconds(5)));
                Assert.False(intervalReminder.Update(TimeSpan.FromSeconds(10)));
                Assert.False(intervalReminder.Update(TimeSpan.FromSeconds(19)));
            }
        }

        [Fact]
        public void TriggersAtRightTimeWithElapsedTime() {
            IntervalReminder intervalReminder = new(TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(15));

            Assert.False(intervalReminder.Update(TimeSpan.FromSeconds(5)));
            Assert.False(intervalReminder.Update(TimeSpan.FromSeconds(10)));
            Assert.False(intervalReminder.Update(TimeSpan.FromSeconds(15)));
            Assert.False(intervalReminder.Update(TimeSpan.FromSeconds(5)));
            Assert.False(intervalReminder.Update(TimeSpan.FromSeconds(10)));
            Assert.True(intervalReminder.Update(TimeSpan.FromSeconds(20)));

            intervalReminder.Reset();

            Assert.True(intervalReminder.Update(TimeSpan.FromSeconds(5)));
            Assert.True(intervalReminder.Update(TimeSpan.FromSeconds(10)));
            Assert.True(intervalReminder.Update(TimeSpan.FromSeconds(15)));
            Assert.False(intervalReminder.Update(TimeSpan.FromSeconds(5)));
            Assert.False(intervalReminder.Update(TimeSpan.FromSeconds(10)));
            Assert.True(intervalReminder.Update(TimeSpan.FromSeconds(20)));
        }
    }
}