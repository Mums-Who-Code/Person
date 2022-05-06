// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using FluentAssertions;
using Force.DeepCloner;
using Moq;
using PersonApp.ConsoleApp.Models.Persons;
using System.Collections.Generic;
using Xunit;

namespace PersonApp.Tests.unit.Services.Foundations.Persons
{
    public partial class PersonServiceTests
    {
        [Fact]
        public void ShouldRetrieveAllPersons()
        {
            //given
            List<Person> randomPersons = CreateRandomPersons();
            List<Person> persistedPersons = randomPersons;
            List<Person> expectedPersons = persistedPersons.DeepClone();

            this.storageBrokerMock.Setup(broker =>
                broker.SelectAllPersons())
                    .Returns(persistedPersons);

            //when
            List<Person> actualPersons =
                this.personService.RetrieveAllPersons();

            //then
            actualPersons.Should().BeEquivalentTo(expectedPersons);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectAllPersons(), 
                   Times.Once);
           
            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}