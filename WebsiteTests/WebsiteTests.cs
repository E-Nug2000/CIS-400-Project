using System;
using Xunit;
using Website.Pages;
using TheFlyingSaucer.Data;
using TheFlyingSaucer.Data.Entrees;
using Microsoft.Extensions.Logging;

namespace WebsiteTests
{
    public class MockLogger : ILogger<IndexModel>
    {
        public IDisposable BeginScope<TState>(TState state)
        {
            throw new NotImplementedException();
        }

        public bool IsEnabled(LogLevel level)
        {
            throw new NotImplementedException();
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            throw new NotImplementedException();
        }
    }

    public class WebsiteTests
    {
        [Fact]
        public void SearchForTermInName()
        {
            MockLogger ml = new MockLogger();
            IndexModel model = new IndexModel(ml);
            model.OnGet("Crashed Saucer", null, null, null, null, null);
            Assert.Contains(model.Items, item => item is CrashedSaucer);
        }
        [Fact]
        public void SearchForTermInDescription()
        {
            MockLogger ml = new MockLogger();
            IndexModel model = new IndexModel(ml);
            model.OnGet("A stack of thick-sliced french toast, served with whipped cream, butter and your choice of syrup.", null, null, null, null, null);
            Assert.Contains(model.Items, item => item is CrashedSaucer);
        }
        [Fact]
        public void SearchForTermInNotInDescriptionOrName()
        {
            MockLogger ml = new MockLogger();
            IndexModel model = new IndexModel(ml);
            model.OnGet("-5 points if you are missing a test for a search term not found in either a name or description", null, null, null, null, null);
            Assert.Empty(model.Items);
        }
        [Fact]
        public void SearchForEmptyString()
        {
            MockLogger ml = new MockLogger();
            IndexModel model = new IndexModel(ml);
            model.OnGet("", null, null, null, null, null);
            Assert.NotEmpty(model.Items);
        }
        [Fact]
        public void AllItemsAboveMinimumCalories()
        {
            MockLogger ml = new MockLogger();
            IndexModel model = new IndexModel(ml);
            model.OnGet(null, null, 50, null, null, null);
            Assert.DoesNotContain(model.Items, item => item.Calories < 50);
        }
        [Fact]
        public void AllItemsBelowMaximumCalories()
        {
            MockLogger ml = new MockLogger();
            IndexModel model = new IndexModel(ml);
            model.OnGet(null, null, null, 500, null, null);
            Assert.DoesNotContain(model.Items, item => item.Calories > 500);
        }
        [Fact]
        public void AllItemsBetweenMinimumAndMaximumCalories()
        {
            MockLogger ml = new MockLogger();
            IndexModel model = new IndexModel(ml);
            model.OnGet(null, null, 50, 500, null, null);
            Assert.DoesNotContain(model.Items, item => item.Calories > 500);
            Assert.DoesNotContain(model.Items, item => item.Calories < 50);
        }
        [Fact]
        public void AllItemsAboveMinimumPrice()
        {
            MockLogger ml = new MockLogger();
            IndexModel model = new IndexModel(ml);
            model.OnGet(null, null, null, null, 1.50, null);
            Assert.DoesNotContain(model.Items, item => item.Price < (decimal)1.50);
        }
        [Fact]
        public void AllItemsBelowMaximumPrice()
        {
            MockLogger ml = new MockLogger();
            IndexModel model = new IndexModel(ml);
            model.OnGet(null, null, null, null, null, 2.50);
            Assert.DoesNotContain(model.Items, item => item.Price > (decimal)2.50);
        }
        [Fact]
        public void AllItemsBetweenMinimumAndMaximumPrice()
        {
            MockLogger ml = new MockLogger();
            IndexModel model = new IndexModel(ml);
            model.OnGet(null, null, null, null, 1.50, 2.50);
            Assert.DoesNotContain(model.Items, item => item.Price < (decimal)1.50);
            Assert.DoesNotContain(model.Items, item => item.Price > (decimal)2.50);
        }
    }
}
