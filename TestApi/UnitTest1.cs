using EdgeExtensionsApi;
namespace TestApi
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var t = Extensions.GetExtensionDetail("eeagobfjdenkkddmbclomhiblgggliao").Result;
            Assert.That(t, Is.Not.Null);
        }

        [Test]
        public static void GetSuggestionsTest()
        {
            Assert.That(Extensions.GetSuggestions("pdf").Result, Is.Not.Null);
             
            Assert.ThrowsAsync<ArgumentNullException>(() => Extensions.GetSuggestions(null!));
            Assert.ThrowsAsync<ArgumentException>(() => Extensions.GetSuggestions(""));
        }
        
        [Test]
        public static void SearchTest()
        {
            Assert.That(Extensions.Search("pdf").Result, Is.Not.Null);

            Assert.ThrowsAsync<ArgumentNullException>(() => Extensions.Search(null!));
            Assert.ThrowsAsync<ArgumentException>(() => Extensions.Search(""));
        }
    }
}