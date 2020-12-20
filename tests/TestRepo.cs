using System;
using Minify.Model;
using Xunit;
using System.Linq;
using Bogus;
using Bogus.DataSets;

namespace Minify.Tests
{
    public class UnitTest1
    {
        Repository repository;
        public UnitTest1()
        {
             repository = new Repository();
             Repository.collection = new Faker<MinifyData>()
                 .RuleFor(data => data.Key, faker => faker.Lorem.Word())
                 .RuleFor(data => data.Url, faker => faker.Internet.Url())
                 .Generate(5);

        }
        [Fact]
        public void TestAddRepo()
        {
            var addFake = new Faker<MinifyData>()
                .RuleFor(data => data.Key, faker => faker.Lorem.Word())
                .RuleFor(data => data.Url, faker => faker.Internet.Url())
                .Generate();
            repository.Add(addFake);
            Assert.Equal(expected: 6, Repository.collection.Count());
            Assert.Contains(addFake, Repository.collection);
        }
        [Fact]
        public void TestDeleteRepo()
        {
            var DeleteFake = Repository.collection.FirstOrDefault();
            repository.Delete(DeleteFake.Key);
            Assert.Equal(expected: 4, Repository.collection.Count());
            Assert.DoesNotContain(DeleteFake, Repository.collection);
        }

        [Fact]
        public void TestGetRepo()
        {
            
            var GetFake = repository.Get(Repository.collection.FirstOrDefault().Key);
            Assert.Equal(GetFake, Repository.collection.FirstOrDefault());
        }
        
        [Fact]
        public void TestGetAllRepo()
        {
            
            var GetAllFake = repository.Get();
            Assert.Equal(GetAllFake, Repository.collection);
        }
    }
}
