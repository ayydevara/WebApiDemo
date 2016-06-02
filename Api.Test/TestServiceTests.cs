using System;
using System.Collections.Generic;
using Autofac;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Services;
using Xunit;
using Xunit.Sdk;

namespace Api.Test
{
    [TestClass]
    public class TestServiceTests : TestBase
    {
        private readonly IContainer _container;
        public TestServiceTests()
        {
            var builder = new ContainerBuilder();
            var testMock = new Mock<ITestService>(MockBehavior.Default);
            testMock.Setup(a => a.GetTestValues()).Returns(new List<string>() {"Hello"});
            testMock.Setup(a => a.GetValue(It.IsAny<string>()))
                .Returns("test");
            builder.Register(ctx => testMock.Object);
            _container= builder.Build();
        }

        [Fact]
        public void GetValues_Should_return_valid_list()
        {
            using (var scope = _container.BeginLifetimeScope())
            {
                var service = scope.Resolve<ITestService>();

                service.GetTestValues().Should().BeAssignableTo<IEnumerable<string>>();
            }
        }

        [Fact]
        public void GetValues_should_contain_hello_in_list()
        {
            using (var scope = _container.BeginLifetimeScope())
            {
                var service = scope.Resolve<ITestService>();

                service.GetTestValues().Should().Contain(a => a.Contains("Hello"));
            }
        }

        [Fact]
        public void GetValues_should_not_be_null()
        {
            using (var scope = _container.BeginLifetimeScope())
            {
                var service = scope.Resolve<ITestService>();

                service.GetTestValues().Should().NotBeNull();
            }
        }

        [Fact]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetValue_should_throw_exception_for_unknown_keys()
        {
            using (var scope = _container.BeginLifetimeScope())
            {
                var service = scope.Resolve<ITestService>();
                service.GetValue(null);
            }
        }

        [Fact]
        public void GetValue_should_return_test_for_valid_key()
        {
            using (var scope = _container.BeginLifetimeScope())
            {
                var service = scope.Resolve<ITestService>();
                service.GetValue("t");
            }
        }


    }


    public abstract class TestBase
    {
        public virtual ContainerBuilder RegisterDependencies(ContainerBuilder builder)
        {
            return builder;
        }
    }
}
