using System;
using System.Collections.Generic;
using Autofac;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            builder.RegisterType<TestService>().As<ITestService>().InstancePerLifetimeScope();

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
        public void GetValues_should_return_hello_in_list()
        {
            using (var scope = _container.BeginLifetimeScope())
            {
                var service = scope.Resolve<ITestService>();

                service.GetTestValues().Should().Contain(a => a.Contains("Hello"));
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
